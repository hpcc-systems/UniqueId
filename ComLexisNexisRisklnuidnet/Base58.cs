/*
 * Company:     LexisNexis. All Rights Reserved.
 * Creator:     (RAJ) Sukhraj Singh
 * Date:        1/15/2019
 * Purposes:    port java version of LN UID Base58 to .NET for use in .NET applications and LNUID generator .Net
 * Comments:
 *
 */



using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace com.lexisnexis.risk.lnuidnet
{
    public class Base58
    {
        private static readonly char[] ALPHABET = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz".ToCharArray();
        private static readonly char ENCODED_ZERO = ALPHABET[0];
        private static readonly int[] INDEXES = new int[128];

        static Base58()
        {

            //initialize
            for (int i = 0; i < INDEXES.Length; i++)
            {
                INDEXES[i] = -1;
            }//for
            //
            for (int count = 0; count < ALPHABET.Length; count++)
            {
                INDEXES[ALPHABET[count]] = count;
            }//for
            
        }


        /// <summary>
        /// Encodes the given bytes as a base58 string (no checksum is appended).
        /// </summary>
        /// <param name="input"> the bytes to encode </param>
        /// <returns> the base58-encoded string </returns>
        public static string encode(sbyte[] input)
        {
            if (input.Length == 0)
            {
                return "";
            }
            // Count leading zeros.
            int zeros = 0;
            while (zeros < input.Length && input[zeros] == 0)
            {
                ++zeros;
            }

            // Convert base-256 digits to base-58 digits (plus conversion to ASCII characters)
           // input = Array.CopyTo(input, input.Length); // since we modify it in-place
            char[] encoded = new char[input.Length * 2]; // upper bound
            int outputStart = encoded.Length;
            for (int inputStart = zeros; inputStart < input.Length; )
            {
                encoded[--outputStart] = ALPHABET[divmod(input, inputStart, 256, 58)];
                if (input[inputStart] == 0)
                {
                    ++inputStart; // optimization - skip leading zeros
                }
            }
            // Preserve exactly as many leading encoded zeros in output as there were leading zeros in input.
            while (outputStart < encoded.Length && encoded[outputStart] == ENCODED_ZERO)
            {
                ++outputStart;
            }
            while (--zeros >= 0)
            {
                encoded[--outputStart] = ENCODED_ZERO;
            }
            // Return encoded string (including encoded leading zeros).
            return new string(encoded, outputStart, encoded.Length - outputStart);
        }


        /// <summary>
        /// Decodes the given base58 string into the original data bytes.
        /// </summary>
        /// <param name="input"> the base58-encoded string to decode </param>
        /// <returns> the decoded data bytes </returns>
        /// <exception cref="IllegalArgumentException"> if the given string is not a valid base58 string </exception>
        public static sbyte[] decode(string input)
        {
            if (input.Length == 0)
            {
                return new sbyte[0];
            }
            // Convert the base58-encoded ASCII chars to a base58 byte sequence (base58 digits).
            sbyte[] input58 = new sbyte[input.Length];
            for (int i = 0; i < input.Length; ++i)
            {
                char inputChar = input[i];
             
                int digit = inputChar < (char)128 ? INDEXES[inputChar] : -1;
                if (digit < 0)
                {
                    throw new System.ArgumentException("Illegal character " + inputChar + " at position " + i);
                }
                input58[i] = (sbyte)digit;
            }
            // Count leading zeros.
            int zeros = 0;
            while (zeros < input58.Length && input58[zeros] == 0)
            {
                ++zeros;
            }
            // Convert base-58 digits to base-256 digits.
            sbyte[] decoded = new sbyte[input.Length];
            int outputStart = decoded.Length;
            for (int inputStart = zeros; inputStart < input58.Length; )
            {
                decoded[--outputStart] = divmod(input58, inputStart, 58, 256);
                if (input58[inputStart] == 0)
                {
                    ++inputStart; // optimization - skip leading zeros
                }
            }
            // Ignore extra leading zeroes that were added during the calculation.
            while (outputStart < decoded.Length && decoded[outputStart] == 0)
            {
                ++outputStart;
            }
            // Return decoded data (including original number of leading zeros).
            return CopyOfRange(decoded, outputStart - zeros, decoded.Length);
                
        
        }

        private static sbyte[] CopyOfRange(sbyte[] inputArray, int StartPos, int Length)
        {
            if (inputArray == null) return null;
            if (inputArray.Length < Length) throw new Exception("Decode: CopyOfRange: length of input array is smalled than given length.");
            if (StartPos > Length) throw new Exception("Decode: CopyOfRange: given start position is greater than given length.");
            int arraySize = Length - StartPos;
            sbyte[] newArray = new sbyte[arraySize];

            int iC = 0;
            for (int i = StartPos; i < Length; i++)
            {
                newArray[iC] = inputArray[i];
                iC++;
            }//for
            return newArray;

        }//CopyOfRange



        /// <summary>
        /// Divides a number, represented as an array of bytes each containing a single digit
        /// in the specified base, by the given divisor. The given number is modified in-place
        /// to contain the quotient, and the return value is the remainder.
        /// </summary>
        /// <param name="number">     the number to divide </param>
        /// <param name="firstDigit"> the index within the array of the first non-zero digit
        ///                   (this is used for optimization by skipping the leading zeros) </param>
        /// <param name="base">       the base in which the number's digits are represented (up to 256) </param>
        /// <param name="divisor">    the number to divide by (up to 256) </param>
        /// <returns> the remainder of the division operation </returns>
        private static sbyte divmod(sbyte[] number, int firstDigit, int @base, int divisor)
        {
            // this is just long division which accounts for the base of the input digits
            int remainder = 0;
            for (int count = firstDigit; count < number.Length; count++)
            {                              
                int digit = (int)number[count] & 0xFF;
                int temp = remainder * @base + digit;
                number[count] = (sbyte)(temp / divisor);
                remainder = temp % divisor;
            }
            return (sbyte)remainder;
        }


    }//class
}//namespace

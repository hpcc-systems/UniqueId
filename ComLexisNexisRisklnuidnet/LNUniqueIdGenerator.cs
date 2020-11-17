/*
 * Company:     LexisNexis. All Rights Reserved.
 * Creator:     (RAJ) Sukhraj Singh
 * Date:        1/15/2019
 * Purposes:    port java version of LN UID generator to .NET for use in .NET applications.
 * Comments:
 *      - Performance: avg UID is generated from .01 to 005 ms. 
 *      - Multithread tested to be safe.
 *      - UID Collision tested for dupes with 10 mil UID generation with 10 concurrent threads several times with no dupes generated.
 */




using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace com.lexisnexis.risk.lnuidnet
{

    /// <summary>
    /// LN UID Generator Class.
    /// </summary>
    public class LNUniqueIdGenerator
    {

        private static String DATE_FORMAT1 = "yyyy-MM-dd HH:mm:ss.hhh";        
        private static readonly DateTime mEpochOrigin1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);



        public LNUniqueIdGenerator()
        {}//constructor


        /// <summary>
        /// Calculates and returns the time component of current time in sbyte format of lenght 8.
        /// </summary>
        /// <returns>sbyte</returns>
        private sbyte[] getTimeComponent()
        {
            long timeMilliSecs = (long)(System.DateTime.UtcNow - mEpochOrigin1970).TotalMilliseconds; 
            byte[] retBytes = BitConverter.GetBytes(timeMilliSecs);
            Array.Reverse(retBytes, 0, retBytes.Length);
            Array ora = (Array)retBytes;
            sbyte[] s_retBytes = Array.ConvertAll(retBytes, b => unchecked((sbyte)b));
            return s_retBytes;
                      

        }//getTimeComponent


        /// <summary>
        /// Generates a secure random number using RandomNumberGenerator in sbyte format of lenght 11.
        /// </summary>
        /// <returns>sbyte</returns>
        private sbyte[] getRandomComponent()
        {
            byte[] retBytes = new byte[11];
            System.Random random = new System.Random();
            RandomNumberGenerator oRNG = RandomNumberGenerator.Create();
            oRNG.GetBytes(retBytes);
            sbyte[] s_retBytes = Array.ConvertAll(retBytes, b => unchecked((sbyte)b));
            return s_retBytes;


        }//getRandomComponent


        /// <summary>
        /// Gets the time component in sbyte array to decode the LN UID.
        /// </summary>
        /// <param name="byteArray"></param>
        /// <param name="timepart"></param>
        /// <returns>sbyte</returns>
        private long getTimepart(sbyte[] byteArray, long timepart)
        {
            for (int i = 0; i < 5; i++)
            {
                timepart = (timepart << 8) + (byteArray[i] & 0xff);
            }
            return timepart;
        }


        /// <summary>
        /// Get Unique ID in binary format
        /// </summary>
        /// <returns>sbyte array length 15</returns>
        public sbyte[] getUniqueIdAsBinary()
        {
            sbyte[] transactionId = new sbyte[16];
            sbyte[] timeComponent = getTimeComponent();
            sbyte[] randomComponent = getRandomComponent();
            if (timeComponent.Length < 5) throw new Exception("LNUniqueIdGenerator: getUniqueIdAsBinary: length of time component is less than 5.");
            if (randomComponent.Length < 11) throw new Exception("LNUniqueIdGenerator: getUniqueIdAsBinary: length of random component is less than 11.");

            //get bytes from time component first 5 
            int iC = 0;
            for (int i = 3; i < timeComponent.Length; i++)
            {
                transactionId[iC] = timeComponent[i];
                iC++;
            }//for

            //get bytes from random component.
            for (int i = 0; i < randomComponent.Length; i++)
            {
                transactionId[5 + i] = randomComponent[i];

            }//for

            return transactionId;

        }//getUniqueIdAsBinary


        /// <summary>
        /// Return the time component in sbyte array format for the given full sbyte array.
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public string getTimeFromBinaryId(sbyte[] byteArray)
        {

            long timepart = getTimepart(byteArray, 0); 
            DateTime EpochOrigin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            DateTime mDateTime = EpochOrigin.AddMilliseconds(timepart + 1099511627776);

            return mDateTime.ToLocalTime().ToString(DATE_FORMAT1);

        }//getTimeFromBinaryId

        /// <summary>
        /// Returns LN UID in string format. 
        /// </summary>
        /// <returns>string</returns>
        public String getUniqueIdAsString() 
        {
         sbyte[] lnuid = getUniqueIdAsBinary();
        return Base58.encode(lnuid);
        }//getUniqueIdAsString







      


    }//class
}//namespace

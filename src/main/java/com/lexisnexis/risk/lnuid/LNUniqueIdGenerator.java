package com.lexisnexis.risk.lnuid;

import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.nio.ByteBuffer;
import java.security.SecureRandom;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Arrays;
import java.util.Date;
import java.util.Locale;
import java.util.logging.Logger;

import static java.util.logging.Level.SEVERE;


/**
 * This is an implementation of Globally Unique Transaction ID�s for LexisNexis Risk Solutions.
 * Note: This class currently generates unique id on OS's that supports device /dev/urandom.
 *
 * @author patwaras
 */
public class LNUniqueIdGenerator {
    private static final Logger LOGGER = Logger.getLogger("uniqueid");
    private static final File URANDOM_FILE = new File("/dev/urandom");
    public static final String DATE_FORMAT1 = "yyyy-MM-dd HH:mm:ss.SSS";
    public static final String DATE_FORMAT2 = "yyyy-MM-dd HH:mm:ss";
    private static final String WINDOWS = "win";
    private static final String OPERATING_SYSTEM = System.getProperty("os.name").toLowerCase(Locale.US);
    private static boolean isWindows() {
        return OPERATING_SYSTEM.indexOf(WINDOWS) >= 0;
    }

    /**
     * Get milliseconds since epoch .
     *
     * @return bytes
     */
    private byte[] getTimeComponent() {
        final long now = System.currentTimeMillis();
        final ByteBuffer buffer = ByteBuffer.allocate(Long.BYTES);
        buffer.putLong(now);
        return buffer.array();
    }

    /**
     * Generate random bytes to used in ID
     *
     * @return bytes
     */
    private byte[] getRandomComponent() {
        final byte[] bytes = new byte[11];
        synchronized (bytes) {
            if (isWindows()) {
                final SecureRandom random = new SecureRandom();
                random.nextBytes(bytes);
            } else {
                try {
                    final DataInputStream inputStream = new DataInputStream(new FileInputStream(URANDOM_FILE));
                    try {
                        inputStream.readFully(bytes);
                        return bytes;
                    } finally {
                        if (inputStream != null) {
                            inputStream.close();
                        }
                    }
                } catch (IOException error) {
                    throw new SecurityException("Failed to read from " + URANDOM_FILE, error);
                }
            }
        }
        return bytes;
    }

    /**
     * Get Unique ID in string format
     * Note: Bitcoin version of Base58 encoding is used
     *
     * @return String
     */
    public String getUniqueIdAsString() {
        final byte[] lnuid = getUniqueIdAsBinary();
        return bytesToBase58(lnuid);
    }

    /**
     * Get Unique ID in string format
     * Note: Bitcoin version of Base58 encoding is used
     *
     * @return String
     */
    public String getUniqueIdAsString(byte[] lnuid) {
        return bytesToBase58(lnuid);
    }

    /**
     * Get Unique ID in string format
     * Note: Bitcoin version of Base58 encoding is used
     *
     * @return String
     */
    public byte[] getBinaryUniqueIdFromStringFormat(String lnuidStr) {
        return base58Tobytes(lnuidStr);
    }


    /**
     * Get Unique ID in binary format
     *
     * @return bytes
     */
    public byte[] getUniqueIdAsBinary() {
        final byte[] transactionId = new byte[16];
        try {
            final byte[] timeComponent = getTimeComponent();
            final byte[] randomComponent = getRandomComponent();
            System.arraycopy(timeComponent, 3, transactionId, 0, 5);
            System.arraycopy(randomComponent, 0, transactionId, 5, 11);
        } catch (Exception error) {
            LOGGER.log(SEVERE, "Error @ getUniqueIdAsBinary", error);
        }
        return transactionId;
    }

    /**
     * Convert Binary Unique ID to Base58 encoded Unique ID
     *
     * @param bytes
     * @return string
     */
    private String bytesToBase58(byte[] bytes) {
        return Base58.encode(bytes);
    }

    /**
     * Convert Base58 encoded Unique ID to Binary Unique ID
     *
     * @param base58
     * @return bytes
     */
    private byte[] base58Tobytes(String base58) {
        return Base58.decode(base58);
    }

    /**
     * Get Date time component from Base58 encoded Unique ID
     *
     * @param lnuidStr
     * @return string
     */
    public String getTimeFromStringId(String lnuidStr) {
        final byte[] byteArray = Base58.decode(lnuidStr);
        return getTimeFromBinaryId(byteArray);
    }

    /**
     * Get Date time component from binary Unique ID
     *
     * @param byteArray
     * @return string
     */
    public String getTimeFromBinaryId(byte[] byteArray) {
        final long timepart = getTimepart(byteArray, 0);
        final Date date = new Date(timepart + 1099511627776L);
        final SimpleDateFormat formatter = new SimpleDateFormat(DATE_FORMAT1, Locale.US);
        return formatter.format(date);
    }
    private long getTimepart(byte[] byteArray, long timepart) {
        for (int i = 0; i < 5; i++) {
            timepart = (timepart << 8) + (byteArray[i] & 0xff);
        }
        return timepart;
    }

    /**
     * Provide possible range of Unique IDs in given DateTime range
     *
     * @param startDateStr in yyyy-MM-dd HH:mm:ss format
     * @param endDateStr   in yyyy-MM-dd HH:mm:ss format
     * @return string
     */
    public String getUniqueIdRangeForDateRange(String startDateStr, String endDateStr) {
        final SimpleDateFormat formatter = new SimpleDateFormat(DATE_FORMAT2, Locale.US);
        final byte[] startTransactionId = new byte[16];
        final byte[] endTransactionId = new byte[16];
        try {
            final Date startDate = formatter.parse(startDateStr);
            final Date endDate = formatter.parse(endDateStr);
            final ByteBuffer startBuffer = ByteBuffer.allocate(Long.BYTES);
            startBuffer.putLong(startDate.getTime());
            final ByteBuffer endBuffer = ByteBuffer.allocate(Long.BYTES);
            endBuffer.putLong(endDate.getTime());
            final byte[] startTimeCom = startBuffer.array();
            final byte[] endTimeCom = endBuffer.array();
            final byte[] startRandomCom = new byte[11];
            Arrays.fill(startRandomCom, (byte) 0x00);
            final byte[] endRandomCom = new byte[11];
            Arrays.fill(endRandomCom, (byte) 0xFF);
            System.arraycopy(startTimeCom, 3, startTransactionId, 0, 5);
            System.arraycopy(startRandomCom, 0, startTransactionId, 5, 11);
            System.arraycopy(endTimeCom, 3, endTransactionId, 0, 5);
            System.arraycopy(endRandomCom, 0, endTransactionId, 5, 11);
        } catch (ParseException error) {
            LOGGER.log(SEVERE, "Error @ getUniqueIdRangeForDateRange", error);
        }
        return "ID Range For " + startDateStr + " to " + endDateStr
                + " - Begin: " + bytesToBase58(startTransactionId) + "  End: "
                + bytesToBase58(endTransactionId);
    }
}
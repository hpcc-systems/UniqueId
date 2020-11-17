package com.lexisnexis.risk.lnuid;

import java.nio.charset.StandardCharsets;
import java.util.Arrays;
import java.util.Scanner;

import static com.lexisnexis.risk.lnuid.LNUniqueIdGenerator.DATE_FORMAT2;

public class Examplelnuid {
    /**
     * This main method provides sample use case of methods in UniqueIdGenerator class
     *
     * @param args
     */
    public static void main(String[] args) {
        final LNUniqueIdGenerator uuid = new LNUniqueIdGenerator();
        final Scanner scanner = new Scanner(System.in, StandardCharsets.UTF_8.name());
        try {
            System.out.format("Transaction id as String:" + uuid.getUniqueIdAsString());
            System.out.format("Transaction id as Binary:" + Arrays.toString(uuid.getUniqueIdAsBinary()));
            System.out.format("Time from Transaction id:" + uuid.getTimeFromStringId(uuid.getUniqueIdAsString()));
            System.out.format("Enter Range Start Date Time in format:" + DATE_FORMAT2);
            final String startDateStr = scanner.nextLine();
            System.out.format("Enter Range End Date Time in format:" + DATE_FORMAT2);
            final String endDateStr = scanner.nextLine();
            System.out.format(uuid.getUniqueIdRangeForDateRange(startDateStr, endDateStr));
        } finally {
            scanner.close();
        }
    }
}

/**
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in
 * compliance with the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software distributed under the License is
 * distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See
 * the License for the specific language governing permissions and limitations under the License.
 */

package com.lexisnexis.uniqueid;

import java.nio.charset.StandardCharsets;
import java.util.Arrays;
import java.util.Scanner;

import static com.lexisnexis.uniqueid.UniqueIdGenerator.DATE_FORMAT2;

public class UniqueIdGeneratorSample {
    /**
     * This main method provides sample use case of methods in UniqueIdGenerator class
     *
     * @param args
     */
    public static void main(String[] args) {
        final UniqueIdGenerator uuid = new UniqueIdGenerator();
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

<?php

use StephenHill\Base58;

class LNUniqueIdGenerator
{
	private $base58 = null;

	/**
	 * LNUniqueIdGenerator constructor.
	 */
	public function __construct()
	{
		date_default_timezone_set('GMT');
		$this->base58 = new Base58();
	}

	/**
	 * Get milliseconds since epoch .
	 * @param dateTime
	 * @return array
	 */
	private function getTimeComponent($dateTime = null)
	{
		$now = null;
		$timeStampArray = null;

		if ($dateTime != null) {
			$now = round($dateTime->format('U.u') * 1000);
		} else {
			$now = round(microtime(true) * 1000);

		}

		switch (PHP_INT_SIZE) {
			case 4:
				// For PHP 32 version as it generates 4 bytes only
				$padding = array_fill(0, 4, 0);
				$timeStampArray = array_merge($padding, unpack("c*", pack("N*", $now)));
				break;
			case 8:
				// For PHP 64 version as it generates 8 bytes
				$timeStampArray = unpack("c*", pack("J*", $now));
				break;
			default:
				//considering  PHP 64 bit as default case
				$timeStampArray = unpack("c*", pack("J*", $now));
				break;
		}
		return array_values($timeStampArray);
	}


	/**
	 * Get random byte array
	 *
	 * @return array
	 * @throws Exception
	 */
	function getRandomComponent()
	{
		$random_bytes = unpack('c*', random_bytes(11));
		return array_values($random_bytes);
	}

	/**
	 * Get Unique ID in string format
	 * Note: Bitcoin version of Base58 encoding is used
	 *
	 * @return String
	 */
	public function getUniqueIdAsString()
	{
		$bytes = $this->getUniqueIdAsBinary();
		return $this->bytesToBase58($bytes);
	}

	/**
	 * Get Base58 encoded string from byte array
	 * Note: Bitcoin version of Base58 encoding is used
	 *
	 * @return String
	 */
	public function getUniqueIdAsStringFromId($lnuid)
	{
		return bytesToBase58($lnuid);
	}

	/**
	 * Get byte array from base58 String Unique ID
	 * Note: Bitcoin version of Base58 encoding is used
	 *
	 * @return String
	 */
	public function getBinaryUniqueIdFromStringFormat($lnuidStr)
	{

		return $this->Base58ToBytes(lnuidStr);
	}


	/**
	 * Get Unique ID as Byte Array
	 *
	 * @return bytes
	 */
	public function getUniqueIdAsBinary()
	{

		try {
			$transactionId = array();
			$timeCom = $this->getTimeComponent();
			$randomCom = $this->getRandomComponent();


			for ($i = 0, $j = 3; $i < 5; $i++, $j++) {
				$transactionId[$i] = $timeCom[$j];
			}
			for ($i = 5, $j = 0; $i < 16; $i++, $j++) {
				$transactionId[$i] = $randomCom[$j];
			}

			return $transactionId;

		} catch (Exception $e) {

			$e->getTrace();
		}
		return null;

	}

	/**
	 * Convert Binary Unique ID to Base58 encoded Unique ID
	 *
	 * @param bytes
	 * @return string
	 */
	public function bytesToBase58($bytes)
	{
		$bytesString = pack('C*', ...$bytes);

		return $this->base58->encode($bytesString);
	}

	/**
	 * Convert Base58 encoded Unique ID to Binary Unique ID
	 *
	 * @param base58
	 * @return bytes
	 */
	public function Base58ToBytes($base58)
	{

		$byteArray = $this->base58->decode($base58);
		$byteArray = unpack('c*', $byteArray);
		return $byteArray;
	}

	/**
	 * Get Date time component from Base58 encoded Unique ID
	 *
	 * @param base58
	 * @return string
	 */
	public function getTimeFromStringId($lnuidStr)
	{
		$byteArray = $this->base58->decode($lnuidStr);
		return getTimeFromBinaryId($byteArray);

	}

	/**
	 * Get Date time component from Binary unique ID
	 *
	 * @param base58
	 * @return string
	 */
	public function getTimeFromBinaryId($byteArray)
	{
		switch (PHP_INT_SIZE) {
			case 4:
				return "Not implemented for 32 bit PHP";
			case 8:
				//Taking out time bytes
				$timePartArray = array_slice($byteArray, 0, 5);

				// Adding padding to make it 8 bytes time array
				// Java implementation achieve this by adding 1099511627776L to timepart -> Date date = new Date(timepart + 1099511627776L);
				$padding = array(0, 0, 1);
				$timeStampArray = array_values(array_merge($padding, $timePartArray));
				$timeMilli = (unpack('J*', pack('C*', ...$timeStampArray)))[1];
				//sprintf to retain after decimal zeros(e.g. 123.000 should not becomes 123) otherwise U.u will through errors
				$date = DateTime::createFromFormat('U.u', sprintf('%.3f', $timeMilli / 1000));
				$date->setTimezone(new DateTimeZone("EST"));
				$date = $date->format("Y-m-d H:i:s.u");
				return $date;
		}

	}

	/**
	 * Provide possible range of Unique IDs in given DateTime range
	 *
	 * @param $startDateStr In format yyyy-MM-dd HH:mm:ss
	 * @param $endDateStr  In format yyyy-MM-dd HH:mm:ss
	 * @return string
	 */
	public function getUniqueIdRangeForDateRange($startDateStr, $endDateStr)
	{
		switch (PHP_INT_SIZE) {
			case 4:
				return "Not implemented for 32 bit PHP";
			case 8:
				$startTransactionId = array();
				$endTransactionId = array();
				try {

					$startdate = DateTime::createFromFormat('Y-m-d H:i:s', $startDateStr);
					$endDate = DateTime::createFromFormat('Y-m-d H:i:s', $endDateStr);
					$startTimeCom = $this->getTimeComponent($startdate);
					$endTimeCom = $this->getTimeComponent($endDate);

					$startRandomCom = array_fill(0, 11, 0x00);
					$endRandomCom = array_fill(0, 11, 0xff);

					for ($i = 0, $j = 3; $i < 5; $i++, $j++) {
						$startTransactionId[$i] = $startTimeCom[$j];
					}
					for ($i = 5, $j = 0; $i < 16; $i++, $j++) {
						$startTransactionId[$i] = $startRandomCom[$j];
					}

					for ($i = 0, $j = 3; $i < 5; $i++, $j++) {
						$endTransactionId[$i] = $endTimeCom[$j];
					}
					for ($i = 5, $j = 0; $i < 16; $i++, $j++) {
						$endTransactionId[$i] = $endRandomCom[$j];
					}

				} catch (ParseException $parseException) {
					$parseException->getMessage();
				}
				return "ID Range For " . $startDateStr . " to " . $endDateStr
					. " - Begin: " . $this->bytesToBase58($startTransactionId) . "  End: "
					. $this->bytesToBase58($endTransactionId);
		}
	}
}
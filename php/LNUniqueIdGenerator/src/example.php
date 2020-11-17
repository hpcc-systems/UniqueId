<?php
/**
 * Created by PhpStorm.
 * User: joshan01
 * Date: 2/20/2019
 * Time: 3:05 PM
 */

require '..\vendor\autoload.php';

include "LNUniqueIdGenerator.php";


$idgenerater = new LNUniqueIdGenerator();
$idgenerater->getUniqueIdAsString();
// for 32 bit PHP generated id does not follow LN defined algorithm
print_r("GUID: ". $idgenerater->getUniqueIdAsString() . PHP_EOL);
// NOTE - Id generator is implemented by 64 bit PHP. for 32 bit versions "Not implemented for 32 bit PHP" will generate.
print_r("ID for date range \"2013-12-12 22:10:10\" , \"2014-12-12 22:10:10\" : ". $idgenerater->getUniqueIdRangeForDateRange("2013-12-12 22:10:10" , "2014-12-12 22:10:10" ));
#include "lnuid.h"
#include <ctime>
#include <iostream>
#include <stdio.h>
#include <string.h>
#include <vector>
#include <assert.h>
#include <stdio.h>
#include <time.h>
#include <sstream>

using namespace std;

/**
* Copyright (c) 2016 LexisNexis Inc.
* This is an sample use cases of UniqueIdGenerator Utility
* @author - Amol Patwardhan
* Created on: October 17, 2016
* Version: 1.0
*/

int main () {



	for (int i = 0; i < 1000000; i++) {

		ln_uid::createUniqueIdString();
		if (i % 10000 == 0)
			cout << i << endl;
	}

	std::string uniqueid = ln_uid::createUniqueIdString();


	cout <<  "Base58 encoded Unique id is " << uniqueid << endl;
	time_t timeStr = ln_uid::timeFromUniqueId(uniqueid.c_str());
	cout << "Time is  : " << timeStr << endl;
	
	struct tm tm;
	char sb[ 100 ];  
#ifdef __linux__ 
	localtime_r(&timeStr, &tm );
	sprintf(sb, "now: %4d-%02d-%02d %02d:%02d:%02d\n", tm.tm_year + 1900, tm.tm_mon + 1, tm.tm_mday,
		tm.tm_hour, tm.tm_min, tm.tm_sec);
#elif _WIN32
	localtime_s(&tm, &timeStr);
	sprintf_s(sb, "now: %4d-%02d-%02d %02d:%02d:%02d\n", tm.tm_year + 1900, tm.tm_mon + 1, tm.tm_mday,
		tm.tm_hour, tm.tm_min, tm.tm_sec);
#else

#endif


	
	cout << "DateTime is " << sb  << endl;

	ln_uid::ln_uid_t uid = {};
	ln_uid::uniqueIdFromString(uniqueid.c_str(), uid);
	time_t timeStr2 = ln_uid::timeFromUniqueId(uid);
	cout << "Time is  : " << timeStr2 << endl;
	
	std::string startDateStr, endDateStr;
	
	cout << "Enter Range Start Date Time in yyyy-MM-dd HH:mm:ss format: " << endl;
	getline (cin, startDateStr);
	cout << "Enter Range End Date Time in yyyy-MM-dd HH:mm:ss format: " << endl;
	getline (cin, endDateStr);
	
	ln_uid::ln_uid_t startuid = {};
	ln_uid::ln_uid_t enduid = {};
	
	ln_uid::getUniqueIdDateRange(startDateStr.c_str(), endDateStr.c_str(), startuid, enduid);
    cout << "Range  - Start UID :" << ln_uid::uniqueIdToString(startuid) << " End UID :" << ln_uid::uniqueIdToString(enduid)	<< endl;
	
	return 0;

}




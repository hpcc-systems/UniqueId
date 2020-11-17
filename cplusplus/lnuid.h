#include <ctime>
#include <string>

using namespace std;

/**
* Copyright (c) 2016 LexisNexis Inc.
* This is an implementation of Globally Unique Transaction ID’s for LexisNexis Risk Solutions.
* Note: This class currently generates unique id on OS's that supports device /dev/urandom.
* @author - Amol Patwardhan
* Created on: October 17, 2016
* Version: 1.0
*/

namespace ln_uid {

    //Random byte count
    const unsigned int uid_size = 16;

    typedef unsigned char ln_uid_t[uid_size];

    ln_uid_t &createUniqueId(ln_uid_t &out);   
    string createUniqueIdString();

    std::string uniqueIdToString(const ln_uid_t &uid);
    ln_uid_t &uniqueIdFromString(const char* uid, ln_uid_t &out);


    time_t timeFromUniqueId(const char* uid);
    time_t timeFromUniqueId(const ln_uid_t &uid);


    void getUniqueIdRange(time_t start, time_t end, ln_uid_t &uid_start, ln_uid_t &uid_end); 
    void getUniqueIdDateRange(const char *start, const char *end, ln_uid_t &uid_start, ln_uid_t &uid_end); 


    bool sameUniqueId(const ln_uid_t &uid1, const ln_uid_t &uid2);
    void copyUniqueId(ln_uid_t &to, const ln_uid_t &from);

	int get_utc_offset();



};

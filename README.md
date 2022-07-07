# TestDataGenerator


Welcome to TestDataGenerator

This application generate ip,mac and hostname as your want.

***OPTIONS CAN CHANGE FROM CONFIG FILE***


---------------------------------------------------------------------------------------------------------------------------------
## CONFIG FILE

+ **Format** : This config parameter says what will be generate .Even names are change it will generate ip,mac and hostname

+ **NetworkAddresses** : This config parameter specify ranges of ip address.

+ **GenerateUniqueIps** : This config parameter specify is ip address unique or not.If it is true you cannot find same 2 ip address.

+ **GenerateUniqueMac** : This config parameter specify is mac address unique or not.If it is true you cannot find same 2 mac addres.

+ **NumberOfGenerations** : This config parameter specify how many to produce.

+ **OutputFile** : This config parameter specify where to write the file.

+ **HostnameFormat** : This config parameter specify the hostname.

+ **MacConfig** : This config parameter specify mac address options with subclasses.
  
  + **Seperator** : This parameter is specify parameters between two bytes.
  
  + **StringCasing** : This parameter is specify spelling of letter.(upper or lower case)
  
  + **Prefixes** : This parameter specify prefix of mac address.

---------------------------------------------------------------------------------------------------------------------------------

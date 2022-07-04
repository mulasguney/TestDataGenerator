# TestDataGenerator


Welcome to TestDataGenerator

This application generate ip,mac and hostname as your want.

OPTIONS CAN CHANGE FROM CONFIG FILE.

Format : This method says what will be generate .Even names are change it will generate ip,mac and hostname

IpRangesStr :: This method specify ranges of ip address.

If network address is 0-8, ip address ranges between 0.0.0.0 - 255.0.0.0
If network address is 8-16, ip address ranges between 0.0.0.0 - 255.255.0.0
If network address is 16-24, ip address ranges between 0.0.0.0 - 255.255.255.0
If network address is 24-32, ip address ranges between 0.0.0.0 - 255.255.255.255

GenerateUniqueIps : This method specify is ip address unique or not.If it is true you cannot find same 2 ip address.

GenerateUniqueMac : This method specify is mac address unique or not.If it is true you cannot find same 2 mac addres.

NumberOfGenerations : This method specify how many to produce.

OutputFile : This method specify where to write the file.

HostnameFormat : This method specify the hostname.

MacConfig : This method specify mac address options with subclasses.
  
  Seperator : This method is specify parameters between two bytes.
  
  StringCasing : This method is specify spelling of letter.(upper or lower case)
  
  Prefixes :: This method specify prefix of mac address.



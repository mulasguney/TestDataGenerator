namespace TestDataGenerator;
public class IpAddressGenerator
{
    private readonly HashSet<string> _ipList = new HashSet<string>();
    public string Generate(bool uniqueIp)
    {
        var ip = IpGenerate();
        if (uniqueIp)
        {
            while (_ipList.Contains(ip))
            {
                ip = IpGenerate();
            }
            if (!_ipList.Contains(ip))
            {
                _ipList.Add(ip);
            }
        }
        return ip;
    }
    private string IpGenerate()
    {
        var number = new Random();
        //It can takes value between 0-255
        var firstOctet = number.Next(0, 256);
        var secondOctet = number.Next(0, 256);
        var thirdOctet = number.Next(0, 256);
        var lastOctet = number.Next(0, 256); 
        return $"{firstOctet}.{secondOctet}.{thirdOctet}.{lastOctet}";
    }
}
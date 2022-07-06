using System.ComponentModel;
using System.Net;

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

    public int GenerationControl(int generation)
    {
        if (generation <= UInt32.MaxValue)
        {
            throw new Exception("You cannot produce 4,294,967,296 Ips");
        }
        return 0;
    }
    private string IpGenerate()
    {
        var number = new Random();
        var firstOctet = number.Next(0, 256);
        var secondOctet = number.Next(0, 256);
        var thirdOctet = number.Next(0, 256);
        var lastOctet = number.Next(0, 256);
        var ip = $"{firstOctet}.{secondOctet}.{thirdOctet}.{lastOctet}";
        
        
        
        return ip;
    }
}
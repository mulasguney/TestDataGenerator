namespace TestDataGenerator;

public class HostnameGenerator
{
    public string Generate(int number)
    {
        var hostname = GeneralConfig.GetDefaultConfig().HostnameFormat!.Replace("#",number.ToString());

        return hostname;
    }
    
    
}
namespace TestDataGenerator;

public class MacAddressGenerator
{
    private readonly MacAddressConfig _config;
    private readonly HashSet<string> _macAddressList = new HashSet<string>();

    public MacAddressGenerator(MacAddressConfig config)
    {
        _config = config ?? throw new Exception("Configuration cannot be null");
    }
    
    public string Generate(bool uniqueMac)
    {
        var mac = MacAddressGenerate();

        if (uniqueMac)
        {
            while (_macAddressList.Contains(mac))
            {
                mac = MacAddressGenerate();
            }

            if (!_macAddressList.Contains(mac))
            {
                _macAddressList.Add(mac);
            }
            
        }
        
        return mac;
    }

    private string MacAddressGenerate()
    {

        var random = new Random();
        var buffer = new byte[6];
        random.NextBytes(buffer);
        var result = String.Concat(buffer.Select(x => $"{x.ToString("X2")}{_config.Separator}").ToArray());

        return _config.StringCasing!.ToLower() == "upper" ? result.TrimEnd(_config.Separator).ToUpper() 
            
            : result.TrimEnd(_config.Separator).ToLower();

    }
    
}
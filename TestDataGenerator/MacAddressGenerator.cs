namespace TestDataGenerator;

public class MacAddressGenerator
{
    private readonly HashSet<string> _macAddressList = new HashSet<string>();
    public string Generate(string separator,string stringCase)
    {
        var mac = MacAddressGenerate(separator,stringCase);

        if (GeneralConfig.GetDefaultConfig().GenerateUniqueMacs)
        {
            while (_macAddressList.Contains(mac))
            {
                mac = Generate(separator,stringCase);
            }

            if (!_macAddressList.Contains(mac))
            {
                _macAddressList.Add(mac);
            }
            
        }
        
        return mac;
    }

    private string MacAddressGenerate(string separator,string stringCase)
    {
        var newSeparator =
            separator.Replace(GeneralConfig.GetDefaultConfig().MacConfig.Separator.ToString(), separator);
        

        var random = new Random();
        var buffer = new byte[6];
        random.NextBytes(buffer);
        var result = String.Concat(buffer.Select(x => $"{x.ToString("X2")}{newSeparator}").ToArray());


        return stringCase == "upper" ? result.TrimEnd(newSeparator.ToCharArray()).ToUpper() 
            : result.TrimEnd(newSeparator.ToCharArray()).ToLower();

    }
    
}
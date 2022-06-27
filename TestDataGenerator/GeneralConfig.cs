namespace TestDataGenerator;

public class GeneralConfig
{
    public static string DefaultConfigFilePath = string.Empty;

    public string Format { get; set; }
    public List<string>? IpRangesStr { get; set; }
    public bool GenerateUniqueIps { get; set; }
    public bool GenerateUniqueMacs { get; set; }
    public int NumberOfGenerations { get; set; }
    public string? OutputFile { get; set; }
    public string? HostnameFormat { get; set; }
    public MacAddressConfig MacConfig { get; set; }

    public static GeneralConfig GetDefaultConfig()
    {

        return new GeneralConfig
        {
            Format = "$mac$,$ip$,$hostname$",
            IpRangesStr = new List<string>{"10.0.0.0/8"},
            NumberOfGenerations = 100,
            OutputFile = ".\\default.out",
            HostnameFormat = "PC#",
            MacConfig = new MacAddressConfig
            {
                Separator = '-',
                StringCasing = "lower",
                Prefixes = new List<string>()
            }
        };

    }
}
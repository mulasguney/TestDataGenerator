using System.Reflection;
using System.Text;
using System.Text.Json;
using TestDataGenerator;


var runningFile = new FileInfo(Assembly.GetExecutingAssembly().Location);
GeneralConfig.DefaultConfigFilePath = Path.Combine(runningFile.DirectoryName!, "config.json");

var arguments = Environment.GetCommandLineArgs();

var configFilePath = GeneralConfig.DefaultConfigFilePath;

switch (arguments.Length)
{
    case 1:
        // Using default config file json
        break;
    case 2:
        // if config file given
        if (!File.Exists(arguments[1]))
        {
            Console.WriteLine($"Cannot find file {arguments[1]}");
            Environment.Exit(-1);
        }

        configFilePath = arguments[1];
        break;
    default:
        Console.WriteLine($"Only config file path argument is supported. Exiting");
        Environment.Exit(-1);
        break;
}

if (!File.Exists(GeneralConfig.DefaultConfigFilePath))
{
    var defConf = GeneralConfig.GetDefaultConfig();
    var serializerOptions = new JsonSerializerOptions
    {
        WriteIndented = true
    };
    var str = JsonSerializer.Serialize(defConf, serializerOptions);
    File.WriteAllText(GeneralConfig.DefaultConfigFilePath, str, Encoding.UTF8);
}

var fileInfo = new FileInfo(GeneralConfig.DefaultConfigFilePath);
var configFile = File.ReadAllText(configFilePath);

var config = JsonSerializer.Deserialize<GeneralConfig>(configFile);

var ipAddressGenerator = new IpAddressGenerator();
var macAddressGenerator = new MacAddressGenerator(config!.MacConfig!);
var hostnameGenerator = new HostnameGenerator();

if (File.Exists(config.OutputFile))
    File.Delete(config.OutputFile);

ipAddressGenerator.GenerationControl(config.NumberOfGenerations);
Console.WriteLine($"Program will generate {config.NumberOfGenerations} Ip,Mac and Hostname");

var listOfLines = new List<string>();


for (var i = 1; i <= config.NumberOfGenerations; i++)
{
    listOfLines.Add(config.Format!
            .Replace("$mac$",macAddressGenerator.Generate(config.GenerateUniqueMacs))
            .Replace("$ip$", ipAddressGenerator.Generate(config.GenerateUniqueIps,config.NetworkAddresses))
            .Replace("$hostname$", hostnameGenerator.Generate(i)));
    if (i % 20 == 0)
    {
        File.AppendAllLines(config.OutputFile!, listOfLines);
        listOfLines.Clear();
    }
    var progress = i * 100 / config.NumberOfGenerations;
    switch (progress)
    {
        case 25:
            Console.WriteLine("%25 is completed");
            break;
        case 50:
            Console.WriteLine("%50 is completed");
            break;
        case 75:
            Console.WriteLine("%75 is completed");
            break;
    }
}
Console.WriteLine($"Path is {config.OutputFile}");

if (listOfLines.Any())
    File.AppendAllLines(config.OutputFile!, listOfLines);
    
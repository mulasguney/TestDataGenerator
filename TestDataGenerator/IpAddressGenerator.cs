namespace TestDataGenerator;

public class IpAddressGenerator
{
    public string Generate()
    {
        var number = new Random();
        var firstByte = number.Next(1, 255);
        var randomByte = number.Next(0, 255);
        var lastByte = number.Next(1, 24);
        
        
        return $"{firstByte}.{randomByte}.{randomByte}/{lastByte}";


    }
    



}
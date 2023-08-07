using System;

string[] METRIC_UNITS = { "Milimeter", "Centimeter", "Decimeter", "Meter", "Decameter", "Hectometer", "Kilometer" };
string[] IMPERIAL_UNITS = { "Inch", "Feet", "Yard", "Mile" };
string SORRY = "Sorry. I don't understand.";


Console.Write("Please type 'Metric'/'Imperial'/'Temperature' to start: ");
string startingGroup = Console.ReadLine().ToLower();
switch (startingGroup)
{
    case "metric":
        Console.Write("Do you want to convert to 'Imperial' or convert one 'Meteric' unit to another?: ");
        string metricConvertTo = Console.ReadLine().ToLower();
        switch (metricConvertTo)
        {
            case "imperial":
                ConvertToImperial();
                break;
            case "meteric":
                Metric();
                break;
            default:
                Console.WriteLine(SORRY);
                break;
        }
        break;
    case "imperial":
        Console.Write("Do you want to convert to 'Metric' or convert one 'Imperial' unit to another?: ");
        string imperialConvertTo = Console.ReadLine().ToLower();
        switch (imperialConvertTo)
        {
            case "metric":
                ConvertToMetric();
                break;
            case "imperial":
                Imperial();
                break;
            default:
                Console.WriteLine(SORRY);
                break;
        }
        
        break;
    case "temperature":
        Temperature();
        break;
    default:
        Console.WriteLine(SORRY);
        break;
}

void Metric()
{
    
}

void Imperial()
{

}

void Temperature()
{

}

void ConvertToImperial()
{

}

void ConvertToMetric()
{
    Console.WriteLine("You want to convert a imperial unit to metric");
}

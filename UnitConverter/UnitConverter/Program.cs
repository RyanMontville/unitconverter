using System;
using System.Linq;
using System.Runtime.CompilerServices;

var METRIC_UNITS = new Dictionary<string, int>
{
    ["Milimeter"] = 1,
    ["Centimeter"] = 10,
    ["Meter"] = 100,
    ["Kilometer"] = 1000
};
var IMPERIAL_UNITS = new Dictionary<string, int>
{
    ["Inch"] = 1,
    ["Feet"] = 12,
    ["Yard"] = 3,
    ["Mile"] = 1760
};
var TEMPERATURE_OPTIONS = new Dictionary<string, int>
{
    ["Convert fahrenheit to celsius"] = 0,
    ["Convert celsius to fahrenheit"] = 1
};
string SORRY = "Sorry. I don't understand.";
double[] METRIC_DECIMALS = { .1, .1, .01, .001 };
bool end_program = false;

while(!end_program) {
    Console.Write("\nPlease type 'Metric'/'Imperial'/'Temperature' to start or 'End' to close the program: ");
    string startingGroup = Console.ReadLine().ToLower();
    switch (startingGroup)
    {
        case "metric":
            int startingUnitMetric = MenuOptions(METRIC_UNITS, "starting unit");
            if(startingUnitMetric == -1)
            {
                break;
            }
            double startingNumMetric = NumberInput(METRIC_UNITS.ElementAt(startingUnitMetric).Key);

            Console.Write("Do you want to convert to 'Imperial' or convert to another 'Metric' unit?: ");
            string metricConvertTo = Console.ReadLine().ToLower();

            switch (metricConvertTo)
            {
                case "imperial":
                    double meterNumber = Metric(startingUnitMetric, 2, startingNumMetric);
                    int imperialConvertUnit = MenuOptions(IMPERIAL_UNITS, "imerial unit to convert to");
                    double imperialConverted = ConvertToImperial(meterNumber, imperialConvertUnit);
                    Console.WriteLine(startingNumMetric + " " + METRIC_UNITS.ElementAt(startingUnitMetric).Key + 
                        " is " + imperialConverted + " " + IMPERIAL_UNITS.ElementAt(imperialConvertUnit).Key);
                    break;
                case "metric":
                    int endingUnitmetric = MenuOptions(METRIC_UNITS, "ending unit");
                    if(endingUnitmetric != -1)
                    {
                        double metric_end = Metric(startingUnitMetric, endingUnitmetric, startingNumMetric);
                        
                        Console.WriteLine(startingNumMetric + " " + METRIC_UNITS.ElementAt(startingUnitMetric).Key +
                            " is " + Math.Round(metric_end, 6) + " " + METRIC_UNITS.ElementAt(endingUnitmetric).Key);
                    }
                    break;
                default:
                    Console.WriteLine(SORRY);
                    break;
            }
            break;
        case "imperial":
            int startingUnitImperial = MenuOptions(IMPERIAL_UNITS, "starting unit");
            if(startingUnitImperial == -1)
            {
                break;
            }
            double startingNumImperial = NumberInput(IMPERIAL_UNITS.ElementAt(startingUnitImperial).Key);

            Console.Write("Do you want to convert to 'Metric' or convert to another 'Imperial' unit?: ");
            string imperialConvertTo = Console.ReadLine().ToLower();
            switch (imperialConvertTo)
            {
                case "metric":
                    double yardNumber = Imperial(startingUnitImperial, 2, startingNumImperial);
                    int metricConvertUnit = MenuOptions(METRIC_UNITS, "metric unit to convert to");
                    double ConvertedMetric = ConvertToMetric(yardNumber, metricConvertUnit);
                    Console.WriteLine(startingNumImperial + " " + IMPERIAL_UNITS.ElementAt(startingUnitImperial).Key + 
                        " is " + ConvertedMetric + " " + METRIC_UNITS.ElementAt(metricConvertUnit).Key);
                    break;
                case "imperial":
                    int endingUnitImperial = MenuOptions(IMPERIAL_UNITS, "ending unit");

                    double imperialEnd = Imperial(startingUnitImperial, endingUnitImperial, startingNumImperial);
                    Console.WriteLine(startingNumImperial + " " + IMPERIAL_UNITS.ElementAt(startingUnitImperial).Key +
                        " is " + Math.Round(imperialEnd, 6) + " " + IMPERIAL_UNITS.ElementAt(endingUnitImperial).Key);
                    break;
                default:
                    Console.WriteLine(SORRY);
                    break;
            }

            break;
        case "temperature":
            Temperature();
            break;
        case "end":
            end_program = true;
            break;
        default:
            Console.WriteLine(SORRY);
            break;
    }
}

double Metric(int startingUnitMetric, int endingUnitmetric, double metricNumber)
{
        if (startingUnitMetric < endingUnitmetric)
        {
            for (int i = startingUnitMetric + 1; i <= endingUnitmetric; i++)
            {
            metricNumber *= METRIC_DECIMALS[i];
            }
        }
        else
        {
            for (int i = startingUnitMetric; i > endingUnitmetric; i--)
            {
            metricNumber *= METRIC_UNITS.ElementAt(i).Value;
            }
        }
    return metricNumber;
}

double Imperial(int startingUnitImperial, int endingUnitImperial, double imperialNumber)
{
    if(startingUnitImperial > endingUnitImperial)
    {
        for(int i= startingUnitImperial; i > endingUnitImperial; i--)
        {
            imperialNumber *= IMPERIAL_UNITS.ElementAt(i).Value;
        }
    } else
    {
        for(int i=startingUnitImperial+1; i <=  endingUnitImperial; i++)
        {
            imperialNumber /= IMPERIAL_UNITS.ElementAt(i).Value;
        }
    }
    return imperialNumber;
}

void Temperature()
{
    Console.WriteLine();
    int choice = MenuOptions(TEMPERATURE_OPTIONS, "temperature converstion");
    switch (choice)
    {
        case 0:
            double fromFahrenheit = NumberInput("fahrenheit");

            double toCelsius = Math.Round((fromFahrenheit - 32) * 0.5556, 2);
            Console.WriteLine(fromFahrenheit + "°F is " + toCelsius + "°C");
            break;
        case 1:
            double fromCelsius = NumberInput("celsius");
            double toFahrenheit = Math.Round(fromCelsius * 1.8) + 32;
            Console.WriteLine(fromCelsius + "°C is " + toFahrenheit + "°F");
            break;
        default:
            Console.WriteLine(SORRY);
            break;
    }

}

double ConvertToImperial(double meterNumber, int imperialConvertUnit)
{
    double yard = meterNumber * 1.09361;
    return Imperial(2, imperialConvertUnit, yard);
}

double ConvertToMetric(double yardNumber, int metricConvertUnit)
{
    double meter = yardNumber * 0.9144;
    return Metric(2, metricConvertUnit, meter);

}

int MenuOptions(Dictionary<string, int> options,string message)
{
    Console.WriteLine();
    for (int i = 0; i < options.Count; i++)
    {
        Console.WriteLine(i + "." + options.ElementAt(i).Key);
    }
    Console.Write("Please make a number selection for the " + message +": ");
    int index =  int.Parse(Console.ReadLine());
    if(index >=0 && index < options.Count)
    {
        return index;
    } else
    {
        Console.WriteLine("Sorry. That number is not on the list.");
        return -1;
    }
}

double NumberInput(string unit)
{
    Console.Write("Enter a number in " + unit +": ");
    return double.Parse(Console.ReadLine());
}
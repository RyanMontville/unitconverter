using System;
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
string SORRY = "Sorry. I don't understand.";
double[] METRIC_DECIMALS = { .1, .1, .01, .001 };
bool end_program = false;

while(!end_program) {
    Console.Write("\nPlease type 'Metric'/'Imperial'/'Temperature' to start or 'End' to close the program: ");
    string startingGroup = Console.ReadLine().ToLower();
    switch (startingGroup)
    {
        case "metric":
            Console.Write("Do you want to convert to 'Imperial' or convert one 'Metric' unit to another?: ");
            string metricConvertTo = Console.ReadLine().ToLower();
            switch (metricConvertTo)
            {
                case "imperial":
                    ConvertToImperial();
                    break;
                case "metric":
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
        case "end":
            end_program = true;
            break;
        default:
            Console.WriteLine(SORRY);
            break;
    }
}




void Metric()
{
    int startingUnitMetric = MenuOptions(METRIC_UNITS, "starting unit");
    int endingUnitmetric = -1;
    if(startingUnitMetric != -1)
    {
        MenuOptions(METRIC_UNITS, "ending unit");
    }
    if (startingUnitMetric != -1 && endingUnitmetric != -1)
    {
        Console.Write("Enter the starting number: ");
        double start_num_metric = double.Parse(Console.ReadLine());
        double end_num_metric = 1;

        if (startingUnitMetric < endingUnitmetric)
        {
            for (int i = startingUnitMetric + 1; i <= endingUnitmetric; i++)
            {
                end_num_metric *= METRIC_DECIMALS[i];
            }
        }
        else
        {
            for (int i = startingUnitMetric; i > endingUnitmetric; i--)
            {
                end_num_metric *= METRIC_UNITS.ElementAt(i).Value;
            }
        }
        double finalMetric = end_num_metric * start_num_metric;
        Console.WriteLine(start_num_metric + " " + METRIC_UNITS.ElementAt(startingUnitMetric).Key +
            " is " + Math.Round(finalMetric, 6) + " " + METRIC_UNITS.ElementAt(endingUnitmetric).Key);
    }
}

void Imperial()
{
    int startingUnitImperial = MenuOptions(IMPERIAL_UNITS, "starting unit");
    int endingUnitImperial = -1;
    if(startingUnitImperial != -1)
    {
        endingUnitImperial = MenuOptions(IMPERIAL_UNITS, "ending unit");
    }
    if (startingUnitImperial != -1 && endingUnitImperial != -1)
    {
        Console.Write("Enter the starting number: ");
        double start_num_imperial = double.Parse(Console.ReadLine());
        double end_num_imperial = 1;

        if(startingUnitImperial > endingUnitImperial)
        {
            for(int i= startingUnitImperial; i > endingUnitImperial; i--)
            {
                end_num_imperial *= IMPERIAL_UNITS.ElementAt(i).Value;
            }
        } else
        {
            for(int i=startingUnitImperial+1; i <= endingUnitImperial; i++)
            {
                Console.WriteLine(IMPERIAL_UNITS.ElementAt(i).Value);
                end_num_imperial /= IMPERIAL_UNITS.ElementAt(i).Value;
            }
        }
        double finalImperial = end_num_imperial * start_num_imperial;
        Console.WriteLine(start_num_imperial + " " + IMPERIAL_UNITS.ElementAt(startingUnitImperial).Key + 
            " is " + Math.Round(finalImperial,6) + " " + IMPERIAL_UNITS.ElementAt(endingUnitImperial).Key);
    }
        
}

void Temperature()
{
    Console.WriteLine();
    Console.WriteLine("1.Convert fahrenheit to celsius");
    Console.WriteLine("2.Convert celsius to fahrenheit");
    Console.Write("Please make a number selection: ");
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            Console.Write("Input the temperature in fahrenheit: ");
            double fromFahrenheit = double.Parse(Console.ReadLine());

            double toCelsius = Math.Round((fromFahrenheit - 32) * 0.5556, 2);
            Console.WriteLine(fromFahrenheit + "°F is " + toCelsius + "°C");
            break;
        case "2":
            Console.Write("Input the temperature in celsius: ");
            double fromCelsius = double.Parse(Console.ReadLine());
            double toFahrenheit = Math.Round(fromCelsius * 1.8) + 32;
            Console.WriteLine(fromCelsius + "°C is " + toFahrenheit + "°F");
            break;
        default:
            Console.WriteLine(SORRY);
            break;
    }

}

void ConvertToImperial()
{

}

void ConvertToMetric()
{
    Console.WriteLine("You want to convert a imperial unit to metric");
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
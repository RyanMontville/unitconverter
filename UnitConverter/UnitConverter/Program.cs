using System;

namespace UnitConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            double cTemp = ConvertToCelsius(30);
            double fTemp = ConvertToFahrenheit(30);
            double mile = ConvertToMiles(30);
            double kilometer = ConvertToKilometers(100);
            Console.WriteLine(cTemp);
            Console.WriteLine(fTemp);
            Console.WriteLine(mile);
            Console.WriteLine(kilometer);
        }

        static double ConvertToCelsius(double fahrenheit)
        {
            return Math.Round((fahrenheit - 32) * 0.5556, 2);
        }

        static double ConvertToFahrenheit(double celsius)
        {
            return Math.Round((celsius * 1.8)) + 32;
        }

        static double ConvertToMiles(double kilometers)
        {
            return Math.Round(kilometers * 0.6213711922,2);
        }

        static double ConvertToKilometers(double miles)
        {
            return Math.Round(miles * 1.609344, 2);
        }
    }
}
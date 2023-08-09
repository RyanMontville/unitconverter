using System;

namespace UnitConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            double tempC = ConvertToCelcius(100);
            double tempF = ConvertToFerenheit(30);
            Console.WriteLine(tempC);
            Console.WriteLine(tempF);
        }

        static double ConvertToCelcius(double ferenheit)
        {
            return Math.Round((ferenheit - 32) * 0.5556,2);
        }

        static double ConvertToFerenheit(double celcius)
        {
            return Math.Round((celcius * 1.8) + 32);
        }
    }
}
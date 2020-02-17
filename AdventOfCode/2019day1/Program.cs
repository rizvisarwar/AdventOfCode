using System;
using System.IO;

namespace _2019day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part1: " + PartOne("Input.txt"));
            Console.WriteLine("Part2: " + PartTwo("Input.txt"));
        }

        private static string PartOne(string fileName)
        {
            try
            {
                var lines = File.ReadLines(fileName);
                long sum = 0;
                foreach (var line in lines)
                {
                    sum += GetFuelForModule(int.Parse(line), 3, 2);
                }

                return sum.ToString();
            }
            catch (IOException e)
            {
                return e.Message;
            }
        }

        private static string PartTwo(string fileName)
        {
            try
            {
                var lines = File.ReadLines(fileName);
                var sum = 0;
                foreach (var line in lines)
                {
                    sum += GetFuelForModuleAndFuel(int.Parse(line), 3, 2);
                }
                return sum.ToString();
            }
            catch (IOException e)
            {
                return e.Message;
            }
        }

        private static int GetFuelForModuleAndFuel(int line, int divideBy, int subtract)
        {
            var fuelMass = GetFuelForModule(line, divideBy, subtract);
            var tempFuelMass = fuelMass;
            while (tempFuelMass > 0)
            {
                tempFuelMass =  GetFuelForModule(tempFuelMass, divideBy, subtract);
                if (tempFuelMass > 0)
                {
                    fuelMass += tempFuelMass;
                }
            }

            return fuelMass;
        }

        private static int GetFuelForModule(int line, int divideBy, int subtract)
        {
            return (line / divideBy) - subtract;
        }
    }
}

using System;

namespace LinearConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            //Collect length and unit of measurement
            Console.Write("Please enter the length: ");
            double length = float.Parse(Console.ReadLine());

            Console.Write("Is the measurement in (m)eter or (f)eet?: ");
            string unitOfMeas = Console.ReadLine().ToLower();

            //Calculate new measurement
            double newLength;
            string newUnit;

            if (unitOfMeas == "m")
            {
                newLength = length * 3.2808399;
                newUnit = "f";
            }
            else
            {
                newLength = length * 0.3048;
                newUnit = "m";
            }

            //Return result
            Console.WriteLine($"{length}{unitOfMeas} is {newLength}{newUnit}.");
        }
    }
}

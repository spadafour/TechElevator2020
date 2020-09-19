using System;

namespace TempConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            //Collect temperature and unit of measurement
            Console.Write("Please enter a temperature: ");
            double temp = int.Parse(Console.ReadLine());

            Console.Write("Is the temperature in (C)elcius or (F)ahrenheit?");
            string unitOfMeas = Console.ReadLine().ToUpper();

            //Calculate new measurement
            int newTemp;
            string newUnit;

            if(unitOfMeas=="C")
            {
                newTemp = (int)(temp * 1.8 + 32);
                newUnit = "F";
            }
            else
            {
                newTemp = (int)((temp - 32) / 1.8);
                newUnit = "C";
            }

            //Return result
            Console.WriteLine($"{temp}{unitOfMeas} is {newTemp}{newUnit}.");
        }
    }
}

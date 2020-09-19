using System;
using System.Runtime.InteropServices.ComTypes;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            //Collecting user's Fibonnai number
            Console.WriteLine("Please enter the Fibonacci number:");
            int userNum = int.Parse(Console.ReadLine());

            //Setting variables
            int fibPast = 0; 
            int fibPres = 1;
            string fibHold = "0";

            //While loop to determine string
            while (fibPres<userNum)
            {
                fibHold += $", {fibPres}";
                fibPres += fibPast;
                fibPast = fibPres - fibPast;
            }

            //Return text
            Console.WriteLine(fibHold);
        }
    }
}

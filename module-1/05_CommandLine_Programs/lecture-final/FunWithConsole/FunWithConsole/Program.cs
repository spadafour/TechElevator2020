using System;

namespace FunWithConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please provide your first name. Pretty please.");
            string userName = Console.ReadLine();
            Console.WriteLine("Your first name is: " + userName);

            Console.WriteLine("How about a last name?");
            string lastName = Console.ReadLine();
            Console.WriteLine($"Your full name is {userName} {lastName}");
            Console.WriteLine("What's your home town?");
            string homeTown = Console.ReadLine();
            Console.WriteLine("How many times do you want to see your home town?");
            string timesInput = Console.ReadLine();
            int numberTimes = int.Parse(timesInput);

            for(int i = 0; i < numberTimes; i++)
            {
                Console.WriteLine(homeTown);
            }

            int number = 0;
            do
            {
                Console.WriteLine("Enter a number");
                number = int.Parse(Console.ReadLine());
                Console.WriteLine("Is it positive? " + (number > 0));
            } while (number > 0);
        }
    }
}

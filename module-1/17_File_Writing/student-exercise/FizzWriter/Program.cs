using System;
using System.IO;

namespace FizzWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory = Environment.CurrentDirectory;
            string fileName = "FizzBuzz.txt";
            string fullPath = Path.Combine(directory, fileName);

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath))
                {
                    for (int i = 1; i <= 300; i++)
                    {
                        string fizzbuzzResult = "";
                        if (i % 3 == 0) { fizzbuzzResult += "Fizz"; }
                        if (i % 5 == 0) { fizzbuzzResult += "Buzz"; }
                        if (fizzbuzzResult == "") { fizzbuzzResult = $"{i}"; }
                        sw.WriteLine(fizzbuzzResult);
                    }
                }
                Console.WriteLine($"{fileName} has been created.");
            }

            catch (Exception e)
            {
                Console.WriteLine("Unable to write to file:");
                Console.WriteLine(e.Message);
            }
        }
    }
}

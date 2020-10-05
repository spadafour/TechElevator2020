using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace WordSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ask the user for the file path
            Console.WriteLine("What is the fully qualified name of the file that should be searched?");
            string fileName = Console.ReadLine();
            bool canOpen = false;
            while (fileName.Length < 1)
            {
                Console.WriteLine("I won't be able to work without a file. Please enter a fully qualified file name.");
                fileName = Console.ReadLine();
            }
            while (!canOpen)
            {
                try
                {
                    File.OpenRead(fileName);
                    canOpen = true;
                }
                catch (IOException exception)
                {
                    Console.WriteLine("Cannot open the file to read.");
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Please enter a fully qualified file name.");
                    fileName = Console.ReadLine();
                }
            }

            //Ask the user for the search string
            Console.WriteLine("What is the search word you are looking for?");
            string searchWord = Console.ReadLine();
            while (searchWord.Length < 1)
            {
                Console.WriteLine("Please enter a word I can search for.");
                searchWord = Console.ReadLine();
            }

            //Ask the user if search is case sensitive
            Console.WriteLine("Should the search be case sensitive? (Y/N)");
            string caseCheck = Console.ReadLine().ToLower();
            List<string> caseCheckPossibilities = new List<string> { "y", "n" };
            while (!caseCheckPossibilities.Contains(caseCheck))
            {
                Console.WriteLine("I didn't quite get that. Please only enter either Y or N.");
                caseCheck = Console.ReadLine();
            }

            //Open the file
            using (StreamReader stream = new StreamReader(fileName))
            {

                //Loop through each line in the file
                int lineNumber = 1;
                while (!stream.EndOfStream)
                {
                    string line = stream.ReadLine();

                    //Search case insensitive
                    if (caseCheck == "n")
                    {
                        string wordLower = searchWord.ToLower();
                        string wordUpper = searchWord.ToUpper();
                        string wordProper = char.ToUpper(searchWord[0]) + wordLower.Substring(1);

                        if (line.Contains(wordLower) || line.Contains(wordUpper) || line.Contains(wordProper))
                        {
                            Console.WriteLine($"{lineNumber}) {line}");
                        }
                        lineNumber++;
                    }

                    //If the line contains the search string, print it out along with its line number
                    else
                    {
                        if (line.Contains(searchWord))
                        {
                            Console.WriteLine($"{lineNumber}) {line}");
                        }
                        lineNumber++;
                    }
                }

            }
        }
    }
}

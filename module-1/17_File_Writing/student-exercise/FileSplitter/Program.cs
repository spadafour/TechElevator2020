using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;

namespace FileSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ask the user for the file path
            Console.WriteLine("What is the fully qualified file name of the test to run?");
            string fullFilePath = Console.ReadLine();
            while (fullFilePath.Length < 1)
            {
                Console.WriteLine("I won't be able to work without a test file. Please enter a fully qualified file name.");
                fullFilePath = Console.ReadLine();
            }


            //Test file for readability and then define file name variables
            bool canOpen = false;
            while (!canOpen)
            {
                try
                {
                    File.OpenRead(fullFilePath);
                    canOpen = true;

                }
                catch (IOException exception)
                {
                    Console.Write("Cannot open the file to read: ");
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Please enter a fully qualified file name.");
                    fullFilePath = Console.ReadLine();
                }
            }
            string fileNameBase = Path.GetFileName(fullFilePath);
            string fileNameNoExtension = Path.GetFileNameWithoutExtension(fullFilePath);
            string fileNameExtension = Path.GetExtension(fullFilePath);


            //Set max number of lines per file
            Console.Write("How many lines of text (max) should there be in the split files? ");
            string maxLinesString = Console.ReadLine();
            int maxLines = 0;
            bool canParse = false;
            while (!canParse)
            {
                try
                {
                    maxLines = int.Parse(maxLinesString);
                    canParse = true;
                }
                catch
                {
                    Console.Write("I can't parse that into an integer. Please re-enter a max number of lines: ");
                    maxLinesString = Console.ReadLine();
                }
            }


            //Collext input text and Output number of lines in document
            int inputLineCount = 0;
            Queue<string> inputTextHolder = new Queue<string>();
            try
            {
                using (StreamReader sr = new StreamReader(fullFilePath))
                {
                    while (!sr.EndOfStream)
                    {
                        inputTextHolder.Enqueue(sr.ReadLine());
                        inputLineCount++;
                    }
                }
            }
            catch (IOException e)
            {
                Console.Write("Ooops! Something went wrong: ");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine($"The input file has {inputLineCount} lines of text.\n");


            //Calculate how many new files you will need to generate
            Console.WriteLine("Each file that is created shoud have a sequential number assigned to it.\n");
            int fileNum = (inputLineCount % maxLines == 0) ? inputLineCount / maxLines : (inputLineCount / maxLines) + 1;
            Console.WriteLine($"For a {inputLineCount} line input file \"{fileNameBase}\", this produces {fileNum} output files.\n");


            //Generate Output
            Console.WriteLine("GENERATING OUTPUT\n");
            string generatorFileName = "";
            int generatorLineCount = 0;
            int generatorFileCount = 0;

            while (inputLineCount > generatorLineCount)
            {
                generatorLineCount++;
                if (generatorLineCount % maxLines == 1)
                {
                    generatorFileCount++;
                    generatorFileName = fileNameNoExtension + $"-{generatorFileCount}" + fileNameExtension;
                    Console.WriteLine($"Generating {generatorFileName}");
                }
                using (StreamWriter sw = new StreamWriter(generatorFileName, true))
                {
                    sw.WriteLine(inputTextHolder.Dequeue());
                }
            }

        }
    }
}

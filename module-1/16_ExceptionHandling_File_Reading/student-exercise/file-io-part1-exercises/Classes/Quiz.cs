using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace file_io_part1_exercises.Classes
{
    public class Quiz
    {
        public string FileName { get; private set; }
        public List<Question> QuestionsList { get; set; } = new List<Question>();
        public int Score { get; private set; } = 0;


        //Constructor gathers FileName and generates QuestionsList with Questions
        public Quiz()
        {
            //Ask the user for the file path
            Console.WriteLine("What is the fully qualified file name of the test to run?");
            string fileName = Console.ReadLine();
            bool canOpen = false;
            while (fileName.Length < 1)
            {
                Console.WriteLine("I won't be able to work without a test file. Please enter a fully qualified file name.");
                fileName = Console.ReadLine();
            }
            //Test file for readability
            while (!canOpen)
            {
                try
                {
                    File.OpenRead(fileName);
                    canOpen = true;
                    FileName = fileName;

                }
                catch (IOException exception)
                {
                    Console.WriteLine("Cannot open the file to read.");
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Please enter a fully qualified file name.");
                    fileName = Console.ReadLine();
                }
            }

            //Begin StreamReader to get all question lines from file into List of Questions.
            try
            {
                using (StreamReader stream = new StreamReader(fileName))
                {
                    while (!stream.EndOfStream)
                    {
                        string line = stream.ReadLine();
                        string[] lineArray = new string[5];
                        try
                        {
                            lineArray = line.Split("|");
                            //Add Question to QuestionsList
                            QuestionsList.Add(new Question(lineArray));
                        }
                        catch
                        {
                            Console.WriteLine("Unable to split this question up properly:");
                            Console.WriteLine($"{line}");
                        }
                    }
                }
            }
            catch (IOException exception)
            {
                Console.WriteLine("Cannot properly read file:");
                Console.WriteLine(exception.Message);
            }
        }

        //Method TakeTest Initiates the new test
        public void TakeQuiz()
        {
            foreach (Question question in QuestionsList)
            {
                //Print the Question and Possible Answers
                Console.WriteLine("\n" + question.QuestionLine);
                Console.WriteLine($"1) {question.Answer1}");
                Console.WriteLine($"2) {question.Answer2}");
                Console.WriteLine($"3) {question.Answer3}");
                Console.WriteLine($"4) {question.Answer4}");

                //Query user for selection
                Console.Write("Your answer: ");
                string userChoice = Console.ReadLine();
                string[] possibleChoices = new string[4] { "1", "2", "3", "4" };
                while (!possibleChoices.Contains(userChoice))
                {
                    Console.WriteLine($"{userChoice} is not an option. Please select 1, 2, 3, or 4.");
                    userChoice = Console.ReadLine();
                }

                //Determine if answer is correct or incorrect
                if (userChoice == question.GetCorrectAnswerIndex())
                {
                    Score++;
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer was {question.GetCorrectAnswerIndex()}. {question.GetCorrectAnswer()}.");
                }
            }

            //Output score
            Console.WriteLine($"You scored {Score} point(s) out of {QuestionsList.Count}.");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTracker.Classes
{
    public class UI
    {
        private List<QuestionData> questionData { get; set; } = new List<QuestionData>();
        public void Menu()
        {
            bool shouldContinue = false;
            do
            {
                Console.WriteLine("Welcome to the 100% Tracker!");
                Console.WriteLine("Press 1 to record a new question record.");
                Console.WriteLine("Press 2 to display all question records.");
                Console.WriteLine("Press any key to exit.");
                ConsoleKeyInfo userInput = Console.ReadKey();
                if(userInput.KeyChar == '1')
                {
                    AddRecord();
                    shouldContinue = true;
                } else if(userInput.KeyChar == '2')
                {
                    DisplayRecords();
                    shouldContinue = true;
                } else
                {
                    shouldContinue = false;
                }
            } while (shouldContinue);
        }

        private bool AddRecord()
        {
            bool dataIsValid = false;
            do
            {
                Console.Write("Enter the date of the quiz: ");
                string dateOfQuiz = Console.ReadLine();
                Console.Write("The name of the quiz: ");
                string quizName = Console.ReadLine();
                Console.Write("What is the question number: ");
                string questionNumber = Console.ReadLine();
                // Now let's convert our input into the datatypes
                try
                {
                    // TODO Should we declare outside the loop so we can show default values on error?
                    QuestionData questionData = new QuestionData();
                    questionData.QuizDate = DateTime.Parse(dateOfQuiz);
                    questionData.QuestionNumber = int.Parse(questionNumber);
                    questionData.QuizTitle = quizName;
                    Logger.WriteRecord(questionData);
                    dataIsValid = true;
                }
                catch (Exception e)
                {
                    // TODO Let's check if it is just the date, and fix it to save the data
                    Console.WriteLine("Sorry, the data is invalid, please try again.");
                    dataIsValid = false;
                }
            } while (!dataIsValid);

            return dataIsValid;
        }

        private bool DisplayRecords()
        {
            Console.WriteLine("Here are all the records: ");
            try
            {
                questionData = Logger.ReadRecords();
                foreach(QuestionData qd in questionData)
                {
                    Console.WriteLine(qd);
                }
                return true;
            } catch(Exception e)
            {
                return false;
            }
        }
    }
}

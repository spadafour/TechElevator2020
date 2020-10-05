using System;
using System.Collections.Generic;
using System.Text;

namespace file_io_part1_exercises.Classes
{
    public class Question
    {
        public string QuestionLine { get; private set; }
        public string Answer1 { get; private set; }
        public string Answer2 { get; private set; }
        public string Answer3 { get; private set; }
        public string Answer4 { get; private set; }
        private string CorrectAnswer { get; set; }
        private string CorrectAnswerIndex { get; set; }

        //Constructor
        public Question(string[] question)
        {
            //Set QuestionLine and Answer1-4
            QuestionLine = question[0];
            Answer1 = question[1].Contains("*") ? question[1].Substring(0, question[1].Length - 1) : question[1];
            Answer2 = question[2].Contains("*") ? question[2].Substring(0, question[2].Length - 1) : question[2];
            Answer3 = question[3].Contains("*") ? question[3].Substring(0, question[3].Length - 1) : question[3];
            Answer4 = question[4].Contains("*") ? question[4].Substring(0, question[4].Length - 1) : question[4];

            //Find and set CorrectAnswer and CorrectAnswerIndex
            for (int i = 1; i < question.Length; i++)
            {
                if (question[i].Contains("*"))
                {
                    CorrectAnswer = question[i].Substring(0, question[i].Length - 1);
                    CorrectAnswerIndex = $"{i}";
                }
            }
        }

        //Method to Return Correct Answer Text
        public string GetCorrectAnswer()
        {
            return CorrectAnswer;
        }

        //Method to return Correct Answer Index
        public string GetCorrectAnswerIndex()
        {
            return CorrectAnswerIndex;
        }
    }
}

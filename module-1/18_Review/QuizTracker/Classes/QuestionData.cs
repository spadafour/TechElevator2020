using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTracker.Classes
{
    public class QuestionData
    {
        public string QuizTitle { get; set; }
        public DateTime QuizDate { get; set; }
        public double Score { get; set; } = 100;
        public int QuestionNumber { get; set; }

        public QuestionData() { }
        public QuestionData(string csv)
        {
            try
            {
                string[] data = csv.Split(',',StringSplitOptions.RemoveEmptyEntries);
                QuizTitle = data[0];
                QuizDate = DateTime.Parse(data[1]);
                Score = int.Parse(data[2]);
                QuestionNumber = int.Parse(data[3]);
            } catch (Exception e)
            {
                throw e;
            }
        }
        public string PrepData()
        {
            return $"{QuizTitle},{QuizDate},{Score},{QuestionNumber}";
        }
        public override string ToString()
        {
            return $"On {QuizDate} we scored {Score} on question number {QuestionNumber} of quiz {QuizTitle}.";
        }
    }
}

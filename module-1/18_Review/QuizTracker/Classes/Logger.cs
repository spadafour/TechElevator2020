using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuizTracker.Classes
{
    public static class Logger
    {
        private const string FILENAME = "100Questions.csv";
        public static bool WriteRecord(QuestionData questionData)
        {
            bool success = false;
            string directory = Environment.CurrentDirectory;
            string fullPath = Path.Combine(directory, FILENAME);
            try
            {
                using(StreamWriter sw = new StreamWriter(fullPath,true))
                {
                    sw.WriteLine(questionData.PrepData());
                }
                success = true;
            } catch (Exception e)
            {
                success = false;
            }
            return success;
        }

        public static List<QuestionData> ReadRecords()
        {
            List<QuestionData> output = new List<QuestionData>();
            string directory = Environment.CurrentDirectory;
            string fullPath = Path.Combine(directory, FILENAME);
            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while(!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        output.Add(new QuestionData(line));
                    }
                }
            } catch (Exception e)
            {
                throw e;
            }
            return output;
        }
    }
}

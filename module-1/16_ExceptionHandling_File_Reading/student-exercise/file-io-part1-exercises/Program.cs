using file_io_part1_exercises.Classes;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;

namespace file_io_part1_exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates a new quiz
            Quiz quizMaker = new Quiz();
            //Executes the quiz
            quizMaker.TakeQuiz();
        }
    }
}
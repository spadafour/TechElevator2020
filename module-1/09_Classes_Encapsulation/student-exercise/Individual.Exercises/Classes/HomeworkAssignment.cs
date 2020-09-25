using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class HomeworkAssignment
    {
        public int EarnedMarks { get; set; }
        public int PossibleMarks { get; private set; }
        public string SubmitterName { get; private set; }
        public string LetterGrade {
            get 
            {
                string letterGrade;
                double percentGrade = (Convert.ToDouble(EarnedMarks) / PossibleMarks) * 100;
                if (percentGrade >= 0 && percentGrade < 60)
                {
                    letterGrade = "F";
                }
                else if (percentGrade >= 60 && percentGrade < 70)
                {
                    letterGrade = "D";
                }
                else if (percentGrade >= 70 && percentGrade < 80)
                {
                    letterGrade = "C";
                }
                else if (percentGrade >= 80 && percentGrade < 90)
                {
                    letterGrade = "B";
                }
                else if (percentGrade >= 90 && percentGrade <=100)
                {
                    letterGrade = "A";
                } else
                {
                    letterGrade = "Earned Marks and/or Possible Marks was entered incorrectly";
                }
                return letterGrade;
            }
        }

        public HomeworkAssignment (int possibleMarks, string submitterName)
        {
            PossibleMarks = possibleMarks;
            SubmitterName = submitterName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         Given two lists of Integers, interleave them beginning with the first element in the first list followed
         by the first element of the second. Continue interleaving the elements until all elements have been interwoven.
         Return the new list. If the lists are of unequal lengths, simply attach the remaining elements of the longer
         list to the new list before returning it.
		 DIFFICULTY: HARD
         InterleaveLists( [1, 2, 3], [4, 5, 6] )  ->  [1, 4, 2, 5, 3, 6]
         */
        public List<int> InterleaveLists(List<int> listOne, List<int> listTwo)
        {
            //Declare variables for interleaved output and count of both input lists
            List<int> interleaved = new List<int>();
            int oneCount = listOne.Count();
            int twoCount = listTwo.Count();
            //declared variables if the counts are different
            int countDiff;
            int extraNumIndexStart;

            //generating output based on Count listOne vs Count listTwo
            if (oneCount>twoCount)
            {
                countDiff = oneCount - twoCount;
                extraNumIndexStart = oneCount - countDiff;
                for (int i=0; i<twoCount; i++)
                {
                    interleaved.Add(listOne[i]);
                    interleaved.Add(listTwo[i]);
                }
                interleaved.AddRange(listOne.GetRange(extraNumIndexStart, countDiff));
            } else if (twoCount>oneCount)
            {
                countDiff = twoCount - oneCount;
                extraNumIndexStart = twoCount - countDiff;
                for (int i=0; i<oneCount; i++)
                {
                    interleaved.Add(listOne[i]);
                    interleaved.Add(listTwo[i]);
                }
                interleaved.AddRange(listTwo.GetRange(extraNumIndexStart, countDiff));
            } else
            {
                for (int i=0; i<oneCount; i++)
                {
                    interleaved.Add(listOne[i]);
                    interleaved.Add(listTwo[i]);
                }
            }

            //ouput
            return interleaved;
        }
    }
}

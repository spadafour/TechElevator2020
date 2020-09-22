using System;
using System.Collections.Generic;
using System.Linq;
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
            
            //I know this isn't the most elegant code, but I was having fun getting this logic to work. Sorry for the mess!
            
            //create new list to hold lists one and two together
            List<int> listAll = new List<int>();
            listAll.AddRange(listOne);
            listAll.AddRange(listTwo);

            //if one is larger than the other, pull the extra numbers out and hold them in a separate list
            List<int> extraHolder = new List<int>();
            int oneLength = listOne.Count();
            int twoLength = listTwo.Count();
            int lengthDiff = 0;
            if (oneLength>twoLength)
            {
                lengthDiff = oneLength - twoLength; 
                extraHolder.AddRange(listOne.GetRange(oneLength-lengthDiff, lengthDiff));
                listAll.RemoveRange(oneLength - lengthDiff, lengthDiff);
                oneLength -= lengthDiff;
            }
            if (twoLength>oneLength)
            {
                lengthDiff = twoLength - oneLength;
                extraHolder.AddRange(listTwo.GetRange(twoLength - lengthDiff, lengthDiff));
                listAll.RemoveRange(listAll.Count() - lengthDiff, lengthDiff);
            }

            //Create new interweaved list to hold final output, and generate interweaved output
            List<int> interweaved = new List<int>();
            for (int i=0; i<oneLength; i++)
            {
                interweaved.Add(listAll[i]);
                interweaved.Add(listAll[i + oneLength]);
            }

            //add extra holder back onto the end of the output
            if (lengthDiff > 0)
            {
                interweaved.AddRange(extraHolder);
            }

            return interweaved;
        }
    }
}

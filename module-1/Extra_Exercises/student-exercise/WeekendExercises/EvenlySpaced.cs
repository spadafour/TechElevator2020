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
        Given three ints, a b c, one of them is small, one is medium and one is large. Return true if the three values are evenly 
        spaced, so the difference between small and medium is the same as the difference between medium and large.
        evenlySpaced(2, 4, 6) → true
        evenlySpaced(4, 6, 2) → true
        evenlySpaced(4, 6, 3) → false
        */
        public bool EvenlySpaced(int a, int b, int c)
        {
            //int small;
            //int med;
            //int large;

            //if (a > b && a > c)
            //{
            //    large = a;
            //    if (b > c) { med = b; small = c; }
            //    else { med = c; small = b; }
            //}
            //else if (b > a && b > c)
            //{
            //    large = b;
            //    if (a > c) { med = a; small = c; }
            //    else { med = c; small = a; }
            //}
            //else
            //{
            //    large = c;
            //    if (a > b) { med = a; small = b; }
            //    else { med = b; small = a; }
            //}

            //int diffSmallMed = med - small;
            //int diffMedLrg = large - med;

            //return diffMedLrg == diffSmallMed;

            List<int> numSort = new List<int> { a, b, c };
            numSort.Sort();
            bool isEvenlySpaced = numSort[2] - numSort[1] == numSort[1] - numSort[0];
            return isEvenlySpaced;
        }
    }
}

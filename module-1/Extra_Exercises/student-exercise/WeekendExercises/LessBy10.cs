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
         Given three ints, a b c, return true if one of them is 10 or more less than one of the others.
         lessBy10(1, 7, 11) → true
         lessBy10(1, 7, 10) → false
         lessBy10(11, 1, 7) → true
         */
        public bool LessBy10(int a, int b, int c)
        {
            bool isLessBy10 = false;
            int[] lessBy10 = new int[3] { a, b, c };
            Array.Sort(lessBy10);
            if (lessBy10[2] - lessBy10[1] >= 10 || lessBy10[2] - lessBy10[0] >= 10 || lessBy10[1] - lessBy10[0] >= 10) { isLessBy10 = true; }
            return isLessBy10;
        }


    }
}

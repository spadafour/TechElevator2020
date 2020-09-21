using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class StringExercises
    {
        /*
         Given a string, return true if the first instance of "x" in the string is immediately followed by another "x".
         DoubleX("axxbb") → true
         DoubleX("axaxax") → false
         DoubleX("xxxxx") → true
         */
        public bool DoubleX(string str)
        {
            bool doubleX = false;
            if (str.Contains("xx") && str.Length > 1)
            {
                int whereX = str.IndexOf('x');
                int nextIndex = whereX + 1;
                doubleX = str[whereX] == str[nextIndex];
            }
            return doubleX;
        }
    }
}
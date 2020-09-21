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
         Count the number of "xx" in the given string. We'll say that overlapping is allowed, so "xxx" contains 2 "xx".
         CountXX("abcxx") → 1
         CountXX("xxx") → 2
         CountXX("xxxx") →
         */
        public int CountXX(string str)
        {
            int sumX = 0;
            for (int i=0; i<str.Length-1; i++)
            {
                bool isX = str[i] == 'x';
                bool isSame = str[i] == str[i + 1];
                if (isX && isSame)
                {
                    sumX++;
                }
            }
            return sumX;
        }
    }
}

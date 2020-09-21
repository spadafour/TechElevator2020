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
        Given a string, return a version where all the "x" have been removed. Except an "x" at the very start or end
        should not be removed.
        StringX("xxHxix") → "xHix"
        StringX("abxxxcd") → "abcd"
        StringX("xabxxxcdx") → "xabcdx"
        */
        public string StringX(string str)
        {
            string noX = str;
            if (str.Length > 1)
            {
                string noXFirst = $"{str[0]}";
                string noXLast = $"{str[str.Length-1]}";
                string noXMid = "";
                for (int i = 1; i < str.Length - 1; i++)
                {
                    if (str[i] != 'x')
                    {
                        noXMid += str[i];
                    }
                }
                noX = noXFirst + noXMid + noXLast;
            }
            return noX;
        }
    }
}

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
         Given a list of Strings, return an array containing the same Strings in the same order
         List2Array( ["Apple", "Orange", "Banana"] )  ->  {"Apple", "Orange", "Banana"}
         List2Array( ["Red", "Orange", "Yellow"] )  ->  {"Red", "Orange", "Yellow"}
         List2Array( ["Left", "Right", "Forward", "Back"] )  ->  {"Left", "Right", "Forward", "Back"}
         */
        public string[] List2Array(List<string> stringList)
        {
            string[] arrList = new string[stringList.Count];
            for (int i=0; i<arrList.Length; i++)
            {
                arrList[i] = stringList[i];
            }
            return arrList;
        }
    }
}

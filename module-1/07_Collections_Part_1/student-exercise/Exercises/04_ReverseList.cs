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
         Given a List of string, return a new list in reverse order of the original. One obvious solution is to
         simply loop through the original list in reverse order, but see if you can come up with an alternative
         solution. (Hint: Think LIFO (i.e. stack))
         ReverseList( ["purple", "green", "blue", "yellow", "green" ])  -> ["green", "yellow", "blue", "green", "purple" ]
         ReverseList( ["jingle", "bells", "jingle", "bells", "jingle", "all", "the", "way"} )
            -> ["way", "the", "all", "jingle", "bells", "jingle", "bells", "jingle"]
         */
        public List<string> ReverseList(List<string> objectList)
        {
            List<string> reverse = new List<string>();
            //Super simple method
            //reverse.Reverse();
            foreach (string obj in objectList)
            {
                reverse.Insert(0, obj);
            }

            return reverse;


            ////here's a "LIFO hint" solution
            
            //Stack<string> reverseStack = new Stack<string>();
            //foreach (string obj in objectList)
            //{
            //    reverseStack.Push(obj);
            //}

            ////tests look for a list back, so put stack into a list
            
            //List<string> reverseString = new List<string>();
            //foreach (string obj in reverseStack)
            //{
            //    reverseString.Add(obj);
            //}    

            //return reverseString;
        }

    }
}

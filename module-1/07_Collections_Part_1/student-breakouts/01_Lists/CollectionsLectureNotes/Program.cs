using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CollectionsLectureNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // LIST<T>
            //
            // Lists allow us to hold collections of data. They are declared with a type of data that they hold
            // only allowing items of that type to go inside of them.
            //
            // The syntax used for declaring a new list of type T is
            //      List<T> list = new List<T>();
            //
            //

            // Create two lists of integers
            List<int> intsA = new List<int>() { 1, 2, 3 };
            List<int> intsB = new List<int>() { 4, 5, 6 };

            // Create list of strings
            List<string> strings = new List<string>() { "apple", "banana", "cabinet" };

            // Write these variables to the console
            Console.WriteLine(intsA[0]);
            Console.WriteLine(intsB[1]);
            Console.WriteLine(strings);

            // Discuss: What did you see on the console? Is that what you expected?

            /////////////////


            //////////////////
            // OBJECT EQUALITY
            //////////////////

            // Check if the first list you created is equal to the second list
            bool isSame = intsA == intsB;

            // If they are equal, write "They are the same" to the console.
            if (isSame)
            {
                Console.WriteLine("They are the same");
            }

            // If they are not equal, write "They are not the same" to the console.
            // Discuss: Why did you get that result?
            else
            {
                Console.WriteLine("They are different");
            }

            // Assign the first integer list to the second integer list
            intsA[0] = intsB[0];
            Console.WriteLine(intsA[0]);

            // Check if the first list you created is equal to the second list
            // If they are equal, write "They are the same" to the console.
            // If they are not equal, write "They are not the same" to the console.
            // Discuss: Why did you get that result?


            /////////////////
            // ADDING ITEMS
            /////////////////

            // Add three numbers to one of the integer lists
            intsA.Add(10);
            intsA.Add(11);
            intsA.Add(12);

            // Add four words to the list of strings
            strings.Add("one");
            strings.Add("two");
            strings.Add("three");

            //////////////////
            // ACCESSING BY INDEX
            //////////////////
            // Use a for loop to access each element by its index
            // Write each element to the console. 
            // Do this for both the integer list and the string list.



            Console.ReadLine();

        }
    }
}

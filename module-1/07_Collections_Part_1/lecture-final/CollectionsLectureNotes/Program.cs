using System;
using System.Collections.Generic;

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

            // Creating lists of integers
            List<int> numbersList = new List<int>();
            List<int> numbersList2 = new List<int>();

            // Creating lists of strings
            List<string> wordsList = new List<string>();


            /////////////////


            //////////////////
            // OBJECT EQUALITY
            //////////////////
            if (numbersList == numbersList2)
            {
                Console.WriteLine("They are the same.");
            }
            else
            {
                Console.WriteLine("They are different.");
            }

            numbersList = numbersList2;
            if (numbersList == numbersList2)
            {
                Console.WriteLine("Again: They are the same.");
            }
            else
            {
                Console.WriteLine("Again: They are different.");
            }

            /////////////////
            // ADDING ITEMS
            /////////////////

            // Adding items one at a time to each list
            numbersList.Add(42);
            numbersList.Add(8);
            numbersList.Add(56);

            /////////////////
            // ADDING MULTIPLE ITEMS
            /////////////////
            int[] numbersArray = { 9, 4, 7, 23 };
            numbersList2.AddRange(numbersArray);

            wordsList.AddRange(new string[] { "blue","green","green","yellow", "azure"});

            //////////////////
            // ACCESSING BY INDEX
            //////////////////
            for(int i = 0; i < wordsList.Count; i++)
            {
                Console.WriteLine(wordsList[i]);
            }



            ///////////////////
            // ACCESSING WITH FOR-EACH
            ///////////////////
            foreach(string word in wordsList)
            {
                Console.WriteLine("From Foreach: " + word);
            }

            foreach(int number in numbersList2)
            {
                Console.WriteLine("From Foreach: " + number);
                Console.WriteLine("From Foreach: " + number * 2);
                if(number > 10)
                {
                    Console.WriteLine("It's double digits");
                }
            }
            ////////////////////
            // ADDITIONAL LIST<T> METHODS
            ////////////////////
            bool containsNumber = numbersList.Contains(2);
            Console.WriteLine("List contains 2 - " + containsNumber);

            int index = wordsList.IndexOf("Yellow");
            Console.WriteLine("Yellow is at " + index);

            index = wordsList.IndexOf("yellow");
            Console.WriteLine("yellow is at " + index);

            numbersList.Insert(0, 100);
            Console.WriteLine($"Numbers List has {numbersList.Count} items in it");

            numbersList.Remove(100);
            Console.WriteLine($"Numbers List has {numbersList.Count} items in it");

            numbersList.RemoveAt(2);
            wordsList.Remove("Green");
            //wordsList.Remove("green");
            // Let's remove all the greens in the list
            while(wordsList.Contains("green"))
            {
                wordsList.Remove("green");
            }
            string[] processedWords = wordsList.ToArray();


            ////////////////////////
            // SORT and PRINT A LIST
            ////////////////////////
            wordsList.Sort();
            Console.WriteLine(String.Join(", ", wordsList));

            wordsList.Reverse();
            Console.WriteLine(String.Join(", ", wordsList));
            Console.WriteLine();




            // QUEUE <T>
            //
            // Queues are a special type of data structure that follow First-In First-Out (FIFO).
            // With Queues, we Enqueue (add) and Dequeue (remove) items.
            Queue<string> todos = new Queue<string>();

            todos.Enqueue("Clean the dishes");
            todos.Enqueue("Paint the fence");
            todos.Enqueue("Wax the car");
            todos.Enqueue("Wash the floor");

            /////////////////////
            // PROCESSING ITEMS IN A QUEUE
            /////////////////////
            while(todos.Count > 0)
            {
                Console.WriteLine(todos.Dequeue());
            }


            // STACK <T>
            //
            // Stacks are another type of data structure that follow Last-In First-Out (LIFO).
            // With Stacks, we Push (add) and Pop (remove) items. 
            Stack<string> breakfast = new Stack<string>();


            ////////////////////
            // PUSHING ITEMS TO THE STACK
            //////////////////// 
            breakfast.Push("Eggs");
            breakfast.Push("Bacon");
            breakfast.Push("Tomatoes");
            breakfast.Push("Sausage");
            breakfast.Push("Hashbrowns");



            ////////////////////
            // POPPING THE STACK
            ////////////////////

            while(breakfast.Count > 0)
            {
                string item = breakfast.Pop();
                string nextItem = breakfast.Count > 0 ? breakfast.Peek() : "All done.";

                if(item != "Sausage")
                {
                    Console.WriteLine($"For breakfast I had {item}");
                    Console.WriteLine($"Next, I'm going to have {nextItem}");

                }
            }

            Console.ReadLine();

        }
    }
}

using System;
using System.Collections.Generic;

namespace CollectionsLectureNotes
{
    class Program
    {
        static void Main(string[] args)
        {

            // QUEUE <T>
            //
            // Queues are a special type of data structure that follow First-In First-Out (FIFO).
            // With Queues, we Enqueue (add) and Dequeue (remove) items.

            // Create a queue of strings
            Queue<string> QWord = new Queue<string>();

            // Add four tasks to the queue that you do every day
            QWord.Enqueue("Turn off alarm");
            QWord.Enqueue("Take shower");
            QWord.Enqueue("Brush teeth");
            QWord.Enqueue("Put on clothes");

            /////////////////////
            // PROCESSING ITEMS IN A QUEUE
            /////////////////////

            // Print each task to the console in the order they were entered (FIFO)
            while(QWord.Count>0)
            {
                Console.WriteLine(QWord.Dequeue());
            }

            // STACK <T>
            //
            // Stacks are another type of data structure that follow Last-In First-Out (LIFO).
            // With Stacks, we Push (add) and Pop (remove) items. 

            // Create a stack of strings
            Stack<string> Breakfast = new Stack<string>();

            // Add to the stack four things you might eat for breakfast
            Breakfast.Push("Bacon");
            Breakfast.Push("Eggs");
            Breakfast.Push("Orange Juice");
            Breakfast.Push("Pancakes");

            ////////////////////
            // POPPING THE STACK
            ////////////////////

            // Print each breakfast item to the console in reverse order (LIFO)

            while (Breakfast.Count > 0)
            {
                Console.WriteLine(Breakfast.Pop());
            }

        }
    }
}

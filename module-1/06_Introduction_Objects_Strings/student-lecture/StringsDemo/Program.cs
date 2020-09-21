using System;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Ada Lovelace";

            // Strings are actually arrays of characters (char). 
            // Those characters can be accessed using [] notation.

            // 1. Write code that prints out the first and last characters
            //      of name.
            // Output: A
            // Output: e

            Console.WriteLine("First and Last Character. ");
            Console.WriteLine(name[0]);
            Console.WriteLine(name[name.Length-1]);

            // 2. How do we write code that prints out the first three characters
            // Output: Ada

            Console.WriteLine("First 3 characters: ");
            string firstThree = name.Substring(0, 3);
            Console.WriteLine(firstThree);

            // 3. Now print out the first three and the last three characters
            // Output: Adaace

            Console.WriteLine("Last 3 characters: ");
            string lastThree = name.Substring(name.Length-3);
            Console.WriteLine(firstThree + lastThree);

            // 4. What about the last word?
            // Output: Lovelace

            Console.WriteLine("Last Word: ");
            string[] words = name.Split(' ');
            Console.WriteLine(words[1]);

            // 5. Does the string contain inside of it "Love"?
            // Output: true

            // Console.WriteLine("Contains \"Love\"");
            Console.WriteLine(name.Contains("Love"));

            // 6. Where does the string "lace" show up in name?
            // Output: 8
            int lace = name.IndexOf("lace");
            Console.WriteLine(lace);

            // Console.WriteLine("Index of \"lace\": ");

            // 7. How many 'a's OR 'A's are in name?
            // Output: 3

            // Console.WriteLine("Number of \"a's\": ");

            int aCount = 0;
            for (int i = 0; i < name.Length; i++)
            {
                char foo = name.ToLower()[i];
                if (foo == 'a')
                {
                    aCount++;
                }
            }
            Console.WriteLine(aCount);

            // 8. Replace "Ada" with "Ada, Countess of Lovelace"

            // Console.WriteLine(name);

            // 9. Set name equal to null.

            // 10. If name is equal to null or "", print out "All Done".

            Console.ReadLine();
        }
    }
}
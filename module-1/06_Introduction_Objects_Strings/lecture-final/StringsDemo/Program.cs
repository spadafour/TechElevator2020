using System;
using System.Linq;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Ada King Lovelace";

            // Strings are actually arrays of characters (char). 
            // Those characters can be accessed using [] notation.

            // 1. Write code that prints out the first and last characters
            //      of name.
            // Output: A
            // Output: e
            char firstCharacter = name[0];
            char lastCharacter = name[name.Length - 1];
            Console.WriteLine("First and Last Character. " + firstCharacter + " -- " + lastCharacter);

            // 2. How do we write code that prints out the first three characters
            // Output: Ada
            string firstThreeCharacters = name.Substring(0, 3);
            Console.WriteLine("First 3 characters: " + firstThreeCharacters);

            // 3. Now print out the first three and the last three characters
            // Output: Adaace
            string lastThreeCharacters = name.Substring(name.Length - 3);
            Console.WriteLine($"Last 3 characters: {firstThreeCharacters}{lastThreeCharacters}");

            // 4. What about the last word?
            // Output: Lovelace
            string[] words = name.Split(' ', ',', StringSplitOptions.RemoveEmptyEntries);
            string lastWord = words[words.Length - 1];
            Console.WriteLine("Last Word: " + lastWord);

            // 5. Does the string contain inside of it "Love"?
            // Output: true
            bool containsLove = name.Contains("love", StringComparison.InvariantCultureIgnoreCase);
            Console.WriteLine("Contains \"Love\" " + containsLove);

            // 6. Where does the string "lace" show up in name?
            // Output: 8
            int laceIndex = name.IndexOf("lace");
            Console.WriteLine("Index of \"lace\": " + laceIndex);
            // 4. What about the last word? without split
            int lastSpace = 0;
            for (int index = 0; index < name.Length; index++)
            {
                if (name.IndexOf(' ', index) != -1)
                {
                    lastSpace = name.IndexOf(' ', index);
                }
            }
            lastWord = name.Substring(lastSpace + 1);
            Console.WriteLine("Last Word with indexOf: " + lastWord);

            int lastWordIndex = name.LastIndexOf(' ');
            lastWord = name.Substring(lastWordIndex + 1);
            Console.WriteLine("Last Word with LastindexOf: " + lastWord);

            // 7. How many 'a's OR 'A's are in name?
            // Output: 3
            int countOfAs = 0;
            for (int i = 0; i < name.Length; i++)
            {
                if(name[i] == 'a' || name[i] == 'A')
                {
                    countOfAs++;
                }
            }

            countOfAs = 0;
            // resist the urge to alter back to the same variable
            //name = name.ToLower();
            string nameLower = name.ToLower();
            for (int i = 0; i < nameLower.Length; i++)
            {
                if(nameLower[i] == 'a')
                {
                    countOfAs++;
                }
            }
            Console.WriteLine("Number of \"a's\": " + countOfAs);

            // 8. Replace "Ada" with "Ada, Countess of Lovelace"
            string formalName = name.Replace("Ada", "Ada, Countess of");
            Console.WriteLine(formalName);

            // 9. Set name equal to null.
            name = null;

            // 10. If name is equal to null or "", print out "All Done".
            if(String.IsNullOrEmpty(name))
            {
                Console.WriteLine("All Done.");
            }
            if(!String.IsNullOrEmpty(name))
            {
                Console.WriteLine("Wait, still have the name.");
            }

            for(int i = 0; i < words.Length; i++)
            {
                Console.Write(words[i].PadRight(10));
            }
            Console.WriteLine();
            for(int i = 0; i < words.Length; i++)
            {
                Console.Write(words[i].PadRight(10));
            }
            Console.WriteLine();
            string putTogether = String.Join(',', words);
            Console.WriteLine(putTogether);
            name = "      Ada Lovelace       ";
            Console.Write(name);
            Console.Write(name.Trim());
            Console.Write(name.TrimEnd());
            Console.Write(name.TrimStart());
            Console.Write("All done!!");
            Console.ReadLine();
        }
    }
}
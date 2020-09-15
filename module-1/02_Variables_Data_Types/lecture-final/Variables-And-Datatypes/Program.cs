using Microsoft.Win32.SafeHandles;
using System;

namespace Variables_And_Datatypes
{
    class Program
    {
        static void Main(string[] args)
        {
            /* VARIABLES & DATA TYPES */

            /*
		    1. Create a variable to hold an int and call it numberOfExercises.
			Then set it to 26.
		    */
            int numberOfExercises;
            numberOfExercises = 26;
            Console.WriteLine(numberOfExercises);

            /*
            2. Create a variable to hold a double and call it half.
                Set it to 0.5.
            */
            double half;
            half = 0.5;
            Console.WriteLine(half);

            /*
            3. Create a variable to hold a string and call it name.
                Set it to "TechElevator".
            */
            string name;
            name = "TechElevator";
            Console.WriteLine(name);
            //Console.WriteLine(name);

            /*
            4. Create a variable called seasonsOfFirefly and set it to 1.
            */
            int seasonsOfFireFly;
            seasonsOfFireFly = 1;
            Console.WriteLine(seasonsOfFireFly);
            //Console.WriteLine(seasonsOfFirefly);

            /*
            5. Create a variable called myFavoriteLanguage and set it to "C#".
            */
            string myFavoriteLanguage;
            myFavoriteLanguage = "C#";
            Console.WriteLine(myFavoriteLanguage);
            //Console.WriteLine(myFavoriteLanguage);

            /*
            6. Create a variable called pi and set it to 3.1416.
            */
            double pi;
            pi = 3.1416;
            float pi_float;
            // the F forces this to float instead a double
            pi_float = 3.1416F;
            int number = 42;
            decimal pi_decimal;
            // the M forces this to a decimal instead of a double
            pi_decimal = 3.1416M;
            pi_float = (float)pi_decimal;
            // convention when you create a const, the name is all uppercase
            const double PI = 3.1416;
            Console.WriteLine(pi);
            //Console.WriteLine(pi);

            /*
            7. Create and set a variable that holds your name.
            */
            // This reuses the name variable from above
            name = "Henry Edwards";
            Console.WriteLine(name);
            /*
            8. Create and set a variable that holds the number of buttons on your mouse.
            */
            int numberOfButtons = 5;
            Console.WriteLine(numberOfButtons);
            /*
            9. Create and set a variable that holds the percentage of battery left on
            your phone.
            */
            float batteryLeft = 0.42F;
            /* EXPRESSIONS */

            /*
            10. Create an int variable that holds the difference between 121 and 27.
            */
            int difference = 121 - 127;
            Console.WriteLine(difference);
            /*
            11. Create a double that holds the addition of 12.3 and 32.1.
            */
            double addition = 12.3 + 32.1;
            Console.WriteLine(addition);

            double balance;
            balance = 0.1 + 0.2;
            Console.WriteLine(balance);
            /*
            12. Create a string that holds your full name.
            */
            string firstName = "Henry Edwards";
            Console.WriteLine(firstName);
            /*
            13. Create a string that holds the word "Hello, " concatenated onto your
            name from above.
            */
            string greeting = "Hello";
            string full = greeting + " " + firstName;
            Console.WriteLine(full);
            /*
            14. Add a " Esquire" onto the end of your full name and save it back to
            the same variable.
            */
            full = full + " Esquire";
            Console.WriteLine(full);
            /*
            15. Now do the same as exercise 14, but use the += operator.
            */
            // The next two lines do exactly the same thing.
            //full = full + ",jr.";
            full += ", jr.";
            Console.WriteLine(full);

            /*
            16. Create a variable to hold "Saw" and add a 2 onto the end of it.
            */
            string movie = "Saw";
            int val = 2;
            movie += val;
            Console.WriteLine(movie);
            /*
            17. Add a 0 onto the end of the variable from exercise 16.
            */
            movie += 0;
            Console.WriteLine(movie);
            /*
            18. What is 4.4 divided by 2.2?
            */
            double result = 4.4 / 2.2;
            Console.WriteLine(result);
            /*
            19. What is 5.4 divided by 2?
            */
            Console.WriteLine(5.4 / 2);

            /* CASTING */

            /*
            20. What is 5 divided by 2?
            */
            double quotient = 5 / 2;
            Console.WriteLine(quotient);
            /*
            21. What is 5.0 divided by 2?
            */
            quotient = 5.0 / 2;
            Console.WriteLine(quotient);

            int firstNum = 5;
            int secondNum = 2;

            double answer = firstNum / secondNum;
            /*
            22. Create a variable that holds a bank balance with the value of 1234.56.
            */
            decimal bankBalace = 1234.56M;

            /*
            23. If I divide 5 by 2, what's my remainder?
            */
            int remainder = 5 % 2;
            Console.WriteLine(remainder);
            /*
            24. Create two variables: 3 and 1,000,000,000 and multiple them together. 
                What is the result?
            */
            int three = 3;
            int billion = 1000000000;
            long threeBillion = three * (long)billion;
            Console.WriteLine(threeBillion);
            /*
            25. Create a variable that holds a boolean called doneWithExercises and
            set it to false.
            */
            bool doneWithExerciseFinally = false;
            /*
            26. Now set doneWithExercise to true.
            */
            doneWithExerciseFinally = true;
            Console.WriteLine(doneWithExerciseFinally);
            Console.ReadLine();
        }
    }
}

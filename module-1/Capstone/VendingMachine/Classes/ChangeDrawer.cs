using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Exceptions;

namespace VendingMachine.Classes
{
    /// <summary>
    /// This class will calculate the change required in the smallest number of coins
    /// </summary>
    public class ChangeDrawer
    {
        /// <summary>
        /// Local variables to hold the number of nickels, dimes, and quarters.
        /// </summary>
        private int nickels { get; set; }
        private int dimes { get; set; }
        private int quarters { get; set; }
        private decimal totalChange { get; set; }

        /// <summary>
        /// Public accessors to get the number of nickels, dimes, and quaters.
        /// </summary>
        public int Nickels { get { return nickels; } }
        public int Dimes { get { return dimes; } }
        public int Quarters { get { return quarters; } }
        /// <summary>
        /// The is a wrapper method for the overloaded MakeChange.
        /// </summary>
        /// <param name="amountInDollars">Take an amount as decimal</param>
        public void MakeChange(decimal amountInDollars)
        {
            try
            {
                // convert the parameter to cents and an int. Math is nicer with ints. Call the private MakeChange
                MakeChange((int)(amountInDollars * 100));
            }
            // If MakeChange throws an exception....
            catch (InsufficientFundsException e)
            {
                // throw it to the calling function
                throw e;
            }

        }
        /// <summary>
        /// Private method that calculates coinage from an amount in pennies
        /// </summary>
        /// <param name="amountInCents">Amount in pennies</param>
        private void MakeChange(int amountInCents)
        {
            // Integer math!!! In this case, it works great to give us how many quarters are in the amount
            quarters = amountInCents / 25;
            // Decrement the parameter amount by the value of the quarters
            amountInCents -= quarters * 25;
            // Repeat that process for dimes and nickels
            dimes = amountInCents / 10;
            amountInCents -= dimes * 10;
            nickels = amountInCents / 5;
        }
        /// <summary>
        /// Override the ToString method so I can call Console.WriteLine on the object itself
        /// </summary>
        /// <returns>The string to print to the console</returns>
        public override string ToString()
        {
            return $"Nickels: {nickels} | Dimes: {dimes} | Quarters: {quarters}";
        }
    }
}

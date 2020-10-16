using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Exceptions
{
    /// <summary>
    /// This exception is thrown if the user doesn't have enough funds to buy the item in the slot.
    /// </summary>
    public class InsufficientFundsException : VendingMachineException
    {
        public InsufficientFundsException() : base("Feed me, Seymour! Money, that is.") { }

    }
}

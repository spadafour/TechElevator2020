using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Exceptions
{
    /// <summary>
    /// This exception is thrown if the user types in a slot that doesn't exist
    /// </summary>
    public class InvalidSlotIDException : VendingMachineException
    {
        public InvalidSlotIDException() : base("Hmmm, that slot doesn't register. Maybe try a different slot?") { }
    }
}

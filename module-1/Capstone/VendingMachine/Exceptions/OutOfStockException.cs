using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Exceptions
{
    /// <summary>
    /// This exception is thrown when the slot is empty
    /// </summary>
    public class OutOfStockException : VendingMachineException
    {
        public OutOfStockException() : base("I can't do that, Dave. That slot is empty") { }
    }
}

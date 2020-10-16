using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Exceptions
{
    // Base class for vending machine specific errors
    // All custom classes are going to inherit from this class so try/catch only 
    // has to look at one type
    public abstract class VendingMachineException : Exception
    {
        public VendingMachineException(string message) : base(message) { }
    }
}

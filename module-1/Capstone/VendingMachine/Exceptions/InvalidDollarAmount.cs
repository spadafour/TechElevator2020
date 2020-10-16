using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Exceptions
{
    public class InvalidDollarAmount : VendingMachineException
    {
        public InvalidDollarAmount() : base("Please, only positive whole dollar amounts") { }

    }
}

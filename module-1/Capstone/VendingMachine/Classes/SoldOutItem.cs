using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Classes
{
    /// <summary>
    /// Item that inherits from VendingMachineItem and represents a sold out slot
    /// </summary>
    public class SoldOutItem : VendingMachineItem
    {
        /// <summary>
        /// Constructor to set item's name and price. Calls the base constructor to set them
        /// </summary>
        /// <param name="itemName">The name of the item</param>
        /// <param name="price">The price of the item</param>
        public SoldOutItem() : base("SOLD OUT", 0.0M)
        {
        }
        /// <summary>
        /// Implementation of the abastract method for consuming the item
        /// </summary>
        /// <returns>The string specific to this item</returns>
        public override string Consume()
        {
            return "Hmm, nothing to eat.";
        }

    }
}

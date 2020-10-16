using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Classes
{
    /// <summary>
    /// Item that inherits from VendingMachineItem
    /// </summary>
    public class BeverageItem : VendingMachineItem
    {
        /// <summary>
        /// Constructor to set item's name and price. Calls the base constructor to set them
        /// </summary>
        /// <param name="itemName">The name of the item</param>
        /// <param name="price">The price of the item</param>
        public BeverageItem(string itemName, decimal price) : base(itemName, price)
        {

        }
        /// <summary>
        /// Implementation of the abastract method for consuming the item
        /// </summary>
        /// <returns>The string specific to this item</returns>
        public override string Consume()
        {
            return "Glug Glub, Yum!";
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Classes
{
    /// <summary>
    /// Base class for all Vending Machine Items. It is abstract since there isn't a generic Vending Machine Item.
    /// </summary>
    public abstract class VendingMachineItem
    {
        /// <summary>
        /// The name of the item/product
        /// </summary>
        public string itemName { get; }
        /// <summary>
        /// The price of the item/product
        /// </summary>
        public decimal price { get; }
        /// <summary>
        /// An abstract method so each derived class has a Consume method
        /// </summary>
        /// <returns>The string the represents the consuming of the item/product</returns>
        public abstract string Consume();

        /// <summary>
        /// Constructor for the instance
        /// </summary>
        /// <param name="itemName">The name of the item/product</param>
        /// <param name="price">The price of the item/product</param>
        public VendingMachineItem(string itemName,decimal price)
        {
            // Nick says: make sure there is a string in the name to prevent crashes if we manipulate the itemName
            this.itemName = itemName ?? "Unknown";
            // Since the local variable price is the same as parameter price, use "this" to reference the local variable
            this.price = price;
        }
    }
}

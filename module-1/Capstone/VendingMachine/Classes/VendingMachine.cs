using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using VendingMachine.Exceptions;

namespace VendingMachine.Classes
{
    public class VirtualVendingMachine
    {
        /// <summary>
        /// This hold the balance but it's private so it can only be manipulated by methods within this class
        /// </summary>
        private decimal _currentBalance { get; set; }
        /// <summary>
        /// This stores the inventory. The string will be the slot id and the value will hold a queue of products. 
        /// </summary>
        public Dictionary<string, Queue<VendingMachineItem>> inventory { get; private set; }

        // 
        /// <summary>
        /// Default Constructor for the machine. The constructor loads the files and populates the inventory. It also resets the sales log
        /// </summary>
        public VirtualVendingMachine()
        {
            // load it up!
            string directory = Environment.CurrentDirectory;
            string fullPath = Path.Combine(directory, "vendingmachine.csv");
            inventory = FileFunctions.LoadMachine(fullPath);
            FileFunctions.ResetLog();
        }

        /// <summary>
        /// Overloaded constructor to take in a file path incase we need a different file
        /// </summary>
        /// <param name="fullPath">Full path to inventory file</param>
        public VirtualVendingMachine(string fullPath)
        {
            inventory = FileFunctions.LoadMachine(fullPath);
            FileFunctions.ResetLog();
        }

        /// <summary>
        /// Public derived property to return the current balance in the machine
        /// </summary>
        public decimal CurrentBalance { get { return _currentBalance; } }
        /// <summary>
        /// Public method to add money to the vending machine's balance
        /// </summary>
        /// <param name="dollars">Amount of dollars to add.</param>
        /// <returns>The machine balance after the money is added</returns>
        public decimal FeedMoney(int dollars)
        {
            // check for negative values. Need to check here in case this class is used elsewhere
            if(dollars < 0)
            {
                throw new InvalidDollarAmount();
            }
            try
            {
                _currentBalance += dollars;
            }
            catch (Exception e)
            {
                throw e;
            }
            // Log it
            FileFunctions.LogTransaction("FEED MONEY", (decimal)dollars, CurrentBalance);
            return CurrentBalance;
        }
        /// <summary>
        /// Part of the vending method, this gets an item from the specified slot
        /// </summary>
        /// <param name="slotID">The slot identifier</param>
        /// <returns>The next item in the specified slot</returns>
        private VendingMachineItem GetItemOutOfSlot(string slotID)
        {
            // Check to see if the slotID is valid, if it is get the item, if it isn't return null;
            return inventory.ContainsKey(slotID) ? inventory[slotID].Dequeue() : null;
        }
        /// <summary>
        /// Returns how many items are in a give slot
        /// </summary>
        /// <param name="slotID">The slot identifier</param>
        /// <returns>How many items are in the slot</returns>
        private int GetQuantityOfSlot(string slotID)
        {
            // Check to see if the slotID is valid, if it is get the count, if it isn't return 0;
            return inventory.ContainsKey(slotID) ? inventory[slotID].Count : 0;
        }

        /// <summary>
        /// Get the cost of the next item in the specified slot
        /// </summary>
        /// <param name="slotID">The slot identifier</param>
        /// <returns>The price of the next item in the slot</returns>
        private decimal GetCostOfSlot(string slotID)
        {
            // Check to see if the slotID is valid and there is something in the slot, if it is get the price, if it isn't return 0;
            return inventory.ContainsKey(slotID) && GetQuantityOfSlot(slotID) > 0 ? inventory[slotID].Peek().price : 0;
        }
        /// <summary>
        /// Purchase an item from the machine
        /// </summary>
        /// <param name="slotID">The slot identifier</param>
        /// <returns>The vended product</returns>
        public VendingMachineItem Purchase(string slotID)
        {
            // Translate the slot to all uppercase for comparison
            slotID = slotID.ToUpper();
            // check if there is anything at the slot
            if (GetQuantityOfSlot(slotID) > 0)
            {
                // is there enough money?
                if (_currentBalance > GetCostOfSlot(slotID))
                {
                    // decrement the balance by the cost of the item
                    _currentBalance -= GetCostOfSlot(slotID);
                    // get the item from the slot
                    VendingMachineItem purchasedItem = GetItemOutOfSlot(slotID);
                    // log the purchase
                    FileFunctions.LogTransaction(purchasedItem.itemName + " " + slotID, purchasedItem.price, _currentBalance);
                    // return the item to the purchaser
                    return purchasedItem;
                }
                // If not enough money, through InsufficientFundsException
                throw new InsufficientFundsException();
            }
            // if there is nothing in slot, throw and OutOfStockException
            throw new OutOfStockException();
        }
        /// <summary>
        /// Method to return change from the vending machine
        /// </summary>
        /// <returns>A changedrawer object containing the change breakdown</returns>
        public ChangeDrawer ReturnChange()
        {
            // Log the transaction. Do it here since the CurrentBalance will change after MakeChange is called
            FileFunctions.LogTransaction("GIVE CHANGE", CurrentBalance, 0M);

            ChangeDrawer changeDrawer = new ChangeDrawer();
            changeDrawer.MakeChange(CurrentBalance);
            return changeDrawer;
        }
    }
}

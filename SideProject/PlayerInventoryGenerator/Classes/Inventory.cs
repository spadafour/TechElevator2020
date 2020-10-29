using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerInventoryGenerator.Classes
{
    public class Inventory
    {
        public int MaxInventory { get; private set; }

        public Inventory(int maxInventory)
        {
            MaxInventory = maxInventory;
        }
    }
}
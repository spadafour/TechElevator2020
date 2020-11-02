using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace LooterHero.Models
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
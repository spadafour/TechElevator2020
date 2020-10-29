using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerInventoryGenerator.Classes
{
    public class Player
    {
        public int Level { get; private set; } = 1;
        public Inventory Inventory { get; private set; } = new Inventory(20);

        public Player()
        {
            
        }
    }
}

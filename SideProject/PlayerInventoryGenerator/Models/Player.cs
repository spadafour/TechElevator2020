using System;
using System.Collections.Generic;
using System.Text;

namespace LooterHero.Models
{
    public class Player
    {
        public int Level { get; private set; } = 1;
        public Inventory Inventory { get; private set; } = new Inventory(20);

        public bool LevelUp()
        {
            Level += 1;
            return true;
        }
    }
}

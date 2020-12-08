using System;
using System.Collections.Generic;
using System.Text;

namespace LooterHero.Models
{
    public class Player
    {
        public int Level { get; private set; } = 1;
        //public Inventory Inventory { get; private set; } = new Inventory(20);
        public Sword EquippedWeapon { get; private set; }

        public bool LevelUp()
        {
            Level += 1;
            return true;
        }

        public bool EquipWeapon(Sword newSword)
        {
            EquippedWeapon = newSword;
            return true;
        }
    }
}

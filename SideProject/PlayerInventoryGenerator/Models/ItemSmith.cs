using System;
using System.Collections.Generic;
using System.Text;

namespace LooterHero.Models
{
    public class ItemSmith
    {
        public Sword CraftSword(int playerLevel)
        {
            return new Sword(playerLevel);
        }
    }
}

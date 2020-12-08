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

        public string FindJunk()
        {
            string[] randomJunk = new string[5] { "Soggy Boot", "Broken Hilt", "Rusted Metal Shard", "Broken Clay Pot", "Soiled Sack" };
            int randomJunkNum = new Random().Next(0, randomJunk.Length - 1);
            return randomJunk[randomJunkNum]; 
        }
    }
}

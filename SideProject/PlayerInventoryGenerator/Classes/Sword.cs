using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PlayerInventoryGenerator.Classes
{
    public class Sword
    {
        public int Level { get; private set; }
        public double Attack { get; private set; }
        public int InventorySpace { get; private set; } = 1;
        public Sword(int level)
        {
            Level = level;
            int minAtk = level - 5;
            int maxAtk = level + 5;
            Attack = new Random().Next(minAtk, maxAtk);
        }
    }
}
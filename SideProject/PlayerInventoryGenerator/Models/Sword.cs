using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LooterHero.Models
{
    public class Sword
    {
        public int Level { get; private set; }
        public double Attack { get; private set; }

        public Sword(int level)
        {
            Level = level;
            Attack = RandomAtkVal();
        }

        private int RandomAtkVal()
        {
            int avgAtk = 5 + (Level * 2);
            int varAtk = (int)(avgAtk * 0.15);
            int minAtk = avgAtk - varAtk;
            int maxAtk = avgAtk + varAtk;
            return new Random().Next(minAtk, maxAtk);
        }
    }
}
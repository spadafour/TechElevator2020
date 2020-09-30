﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AbstractExercise
{
    public class SquareWall : RectangleWall
    {
        public SquareWall(string name, string color, int sideLength) : base(name, color, sideLength, sideLength) { }

        public override string ToString()
        {
            return $"{this.Name} ({this.Length}x{this.Height}) square";
        }
    }
}

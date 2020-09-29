using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Sheep : FarmAnimal
    {
        public Sheep(string petName, string sheepSound) : base(petName,sheepSound) { }
        public string Shear()
        {
            return "Get wool.";
        }
    }
}

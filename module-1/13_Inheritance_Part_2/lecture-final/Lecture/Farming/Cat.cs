using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public sealed class  Cat : FarmAnimal
    {
        public Cat(string goofyName) : base(goofyName,"Meow") { }

        public string Sound { get { return "Meow"; } }

        public override string Eat()
        {
            return "Tosses food around the room";
        }
    }
}

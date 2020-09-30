using System;

namespace Lecture.Farming
{
    public class Chicken : FarmAnimal
    {
        public Chicken() : base("Chicken", "cluck")
        {
        }

        public override string Eat()
        {
            return "Peck";
        }

        public void LayEgg()
        {
            Console.WriteLine("Chicken laid an egg!");
        }
    }
}

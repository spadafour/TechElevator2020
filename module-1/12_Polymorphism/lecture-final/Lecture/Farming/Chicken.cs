using System;

namespace Lecture.Farming
{
    public class Chicken : FarmAnimal, ISellable
    {
        public Chicken() : base("Chicken", "cluck")
        {
        }

        public decimal GetSalesPrice()
        {
            return 12.50M;
        }

        public void LayEgg()
        {
            Console.WriteLine("Chicken laid an egg!");
        }

        public override string ToString()
        {
            return $"Each Chicken costs {GetSalesPrice():C2}";
        }
    }

}

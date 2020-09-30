namespace Lecture.Farming
{
    public class Cow : FarmAnimal, ISellable
    {
        public decimal Price { get; }

        public Cow(string name) : base(name, "moo")
        {
            Price = 1500;
        }

        public override string Eat()
        {
            return "Chew";
        }

    }
}

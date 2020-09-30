using Lecture.Farming;
using System;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // OLD MACDONALD
            //

            Cow sleepy = new Cow("Sleepy");
            sleepy.Sleep();
            Cat cat = new Cat("Cosmic Creepers");
            cat.Sleep();
            Jersey jersey = new Jersey();
            Cat felix = new Cat("Felix");
            Console.WriteLine(sleepy.Eat());
            Console.WriteLine(cat.Eat());
            ISingable[] singables = new ISingable[]
            {
                new Cow("Henry"), new Chicken(), new Pig(), new Tractor(), new Cow("Earl"), sleepy, cat, jersey, felix
            };

            ((FarmAnimal)singables[2]).Sleep();
            foreach(ISingable singable in singables)
            {
                Console.WriteLine("Old MacDonald had a farm, ee ay ee ay oh!");
                Console.WriteLine("And on his farm he had a " + singable.Name + ", ee ay ee ay oh!");
                Console.WriteLine("With a " + singable.Sound + " " + singable.Sound + " here");
                Console.WriteLine("And a " + singable.Sound + " " + singable.Sound + " there");
                Console.WriteLine("Here a " + singable.Sound + " there a " + singable.Sound + " everywhere a " + singable.Sound + " " + singable.Sound);
                Console.WriteLine();
            }

            ISellable[] sellables = new ISellable[]
            {
                new Cow("Henry"), new Pig(), new Egg()
            };

            foreach(ISellable sellable in sellables)
            {
                Console.WriteLine("Step right up and get your " + sellable.Name);
                Console.WriteLine("Only $" + sellable.Price);
            }
        }
    }
}
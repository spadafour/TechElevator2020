using System;

namespace DiscountCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Discount Calculator");
            // Prompt the user for the price
            Console.Write("Enter the discount price (w/o percent sign): ");
            decimal discount = decimal.Parse(Console.ReadLine()) / 100;

            // Prompt them for the price of the item
            Console.Write("Please enter the prices separated by spaces. ");
            string prices = Console.ReadLine();
            char[] delimiters = { ' ', ',', ';' };
            // StringSplitOptions.RemoveEmptyEntries removes any empty entries
            string[] priceArray = prices.Split(delimiters,StringSplitOptions.RemoveEmptyEntries);

            // Loop through the array
            for(int i = 0; i < priceArray.Length; i++)
            {
                // convert the string value in the array to a decimal
                decimal price = decimal.Parse(priceArray[i]);
                // calculated the values
                decimal amountOff = price * discount;
                decimal salePrice = price - amountOff;
                // wrote them to the screen.
                Console.WriteLine($"Original Price: {price:C2} | Sale Price: {salePrice:C2}");

            }
        }
    }
}

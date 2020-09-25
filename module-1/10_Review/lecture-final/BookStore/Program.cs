using BookStore.Classes;
using System;
using System.Collections.Generic;

namespace BookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Tech Elevator Bookstore");
            Console.WriteLine();

            // Step Three: Test the properties
            Book twoCities = new Book("A Tale of Two Cities", "Charles Dickens", 14.99M);
            Console.WriteLine($"Title: {twoCities.Title}, Author: {twoCities.author}, Price: {twoCities.price:C2}");

            // Step Five: Test the Book constructor
            Book threeMusketeers = new Book("The Three Musketeers","Alexandre Dumas", 12.95M);
            Console.WriteLine(threeMusketeers.BookInfo());
            Book firstInTheSeries = new Book("Harry Potter and the Sorcerer's Stone", "J.K. Rowling", 152.00M);
            Console.WriteLine(firstInTheSeries.BookInfo());
            // Step Nine: Test the ShoppingCart class
            ShoppingCart myCart = new ShoppingCart();
            myCart.budget = 1700.00M;
            myCart.Add(firstInTheSeries);
            Console.WriteLine(myCart.TotalPrice);
            myCart.Add(twoCities);
            Console.WriteLine(myCart.TotalPrice);
            myCart.Add(threeMusketeers);
            Console.WriteLine(myCart.TotalPrice);
            myCart.Add(threeMusketeers);
            Console.WriteLine(myCart.TotalPrice);

            Console.WriteLine(myCart.PrintReceipt());
        }
    }
}

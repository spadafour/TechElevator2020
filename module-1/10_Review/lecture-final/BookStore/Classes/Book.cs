using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Classes
{
    public class Book
    {
        public string Title { get; set; }
        public string author { get; set; }
        public decimal price { get; set; } 
        public string ISBN { get; set; }

        public Book(string title, string author, decimal price)
        {
            Title = title;
            this.author = author;
            this.price = price;
        }

        public string BookInfo()
        {
            return "Title: " + Title + ", Author: " + author + ", Price: $" + price;
        }
    }
}

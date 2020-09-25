using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Classes
{
    public class ShoppingCart
    {
        private List<Book> booksToBuy { get; set; } = new List<Book>();
        public decimal budget { get; set; }
        public decimal TotalPrice
        {
            get
            {
                decimal total = 0;
                foreach(Book book in booksToBuy)
                {
                    total += book.price;
                }
                return total;
            }
        }
        public void Add(Book bookToAdd)
        {
            if(TotalPrice + bookToAdd.price <= budget)
            {
                booksToBuy.Add(bookToAdd);
            }
        }

        public string PrintReceipt()
        {
            string receipt = "\nReceipt\n\n";
            foreach(Book book in booksToBuy)
            {
                receipt += book.BookInfo();
                receipt += "\n";
            }
            receipt += "\nTotal: " + TotalPrice;
            return receipt;
        }

    }
}

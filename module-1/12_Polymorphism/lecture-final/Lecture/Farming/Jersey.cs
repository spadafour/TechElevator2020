using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Jersey : Cow, ISellable, ITradable
    {
        public decimal GetSalesPrice()
        {
            return 1000M;
        }

        public string MinimumOffer()
        {
            return "Magic Beans";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Apple : ISellable
    {
        public decimal GetSalesPrice()
        {
            return 1.25M;
        }

        public decimal GetSalesPrice(string AppleName)
        {
            return 2.25M;
        }

        public override string ToString()
        {
            return $"Each Apple costs {GetSalesPrice():C2}";
        }
    }
}

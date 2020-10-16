using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Classes;
using VendingMachine.Exceptions;

namespace VendingMachine.Tests
{
    [TestClass]
    public class InventoryTests
    {
        private VirtualVendingMachine vm { get; set; }
        [TestInitialize]
        public void Initialize()
        {
            vm = new VirtualVendingMachine();
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfStockException))]
        public void SoldOut()
        {
            vm.FeedMoney(100);
            for (int i = 0; i < 10; i++)
            {
                vm.Purchase("A1");
            }
        }
    }
}

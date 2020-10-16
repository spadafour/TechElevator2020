using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Classes;

namespace VendingMachine.Tests
{
    [TestClass]
    public class MoneyTests
    {
        private VirtualVendingMachine vm { get; set; }
        [TestInitialize]
        public void Initialize()
        {
            vm = new VirtualVendingMachine();
        }

        [TestMethod]
        public void AddMoney()
        {
            decimal money = vm.FeedMoney(10);
            Assert.AreEqual(10, money);
            money = vm.FeedMoney(5);
            Assert.AreEqual(15, money);
        }

        [TestMethod]
        public void ReturnChange()
        {
            vm.FeedMoney(10);
            vm.Purchase("A1");
            ChangeDrawer changeDrawer = vm.ReturnChange();
            Assert.AreEqual(changeDrawer.Quarters, 27);
            Assert.AreEqual(changeDrawer.Dimes, 2);
            Assert.AreEqual(changeDrawer.Nickels, 0);
        }
    }
}

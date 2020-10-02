using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class Less20Test
    {
        [DataTestMethod]
        [DataRow(18)]
        [DataRow(19)]
        [DataRow(38)]
        [DataRow(39)]
        [DataRow(58)]
        [DataRow(59)]
        [DataRow(78)]
        [DataRow(79)]
        [DataRow(118)]
        [DataRow(119)]
        public void Is1Or2Less(int num)
        {
            Less20 less20 = new Less20();
            bool expected = true;
            bool result = less20.IsLessThanMultipleOf20(num);
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(17)]
        [DataRow(20)]
        [DataRow(21)]
        [DataRow(22)]
        [DataRow(40)]
        [DataRow(101)]
        [DataRow(110)]
        [DataRow(int.MaxValue)]
        public void Not1Or2Less(int num)
        {
            Less20 less20 = new Less20();
            bool expected = false;
            bool result = less20.IsLessThanMultipleOf20(num);
            Assert.AreEqual(expected, result);
        }

    }
}

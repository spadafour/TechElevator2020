using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class DateFashionTest
    {
        [DataTestMethod]
        [DataRow(0, 0)]
        [DataRow(2, 2)]
        [DataRow(0, 2)]
        [DataRow(0, 7)]
        [DataRow(0, 8)]
        [DataRow(0, 10)]
        [DataRow(2, 7)]
        [DataRow(2, 8)]
        [DataRow(2, 10)]
        [DataRow(2, 0)]
        [DataRow(7, 0)]
        [DataRow(8, 0)]
        [DataRow(10, 0)]
        [DataRow(7, 2)]
        [DataRow(8, 2)]
        [DataRow(10, 2)]
        public void NoChanceAtTable(int you, int date)
        {
            DateFashion dateFashion = new DateFashion();
            int expected = 0;
            int result = dateFashion.GetATable(you, date);
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(8, 8)]
        [DataRow(10, 10)]
        [DataRow(8, 3)]
        [DataRow(8, 7)]
        [DataRow(8, 10)]
        [DataRow(10, 3)]
        [DataRow(10, 7)]
        [DataRow(10, 8)]
        [DataRow(3, 8)]
        [DataRow(7, 8)]
        [DataRow(10, 8)]
        [DataRow(3, 10)]
        [DataRow(7, 10)]
        [DataRow(8, 10)]
        public void WillGetTable(int you, int date)
        {
            DateFashion dateFashion = new DateFashion();
            int expected = 2;
            int result = dateFashion.GetATable(you, date);
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(3, 3)]
        [DataRow(5, 5)]
        [DataRow(7, 7)]
        [DataRow(3, 5)]
        [DataRow(3, 7)]
        [DataRow(5, 3)]
        [DataRow(5, 7)]
        [DataRow(7, 3)]
        [DataRow(7, 5)]
        [DataRow(5, 3)]
        [DataRow(7, 3)]
        [DataRow(3, 5)]
        [DataRow(7, 5)]
        [DataRow(3, 7)]
        [DataRow(5, 7)]
        public void MightGetTable(int you, int date)
        {
            DateFashion dateFashion = new DateFashion();
            int expected = 1;
            int result = dateFashion.GetATable(you, date);
            Assert.AreEqual(expected, result);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class Lucky13Test
    {
        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 4 })]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { 1, 1, 1 })]
        [DataRow(new int[] { 1, -2, -4 })]
        public void HasOnes(int[] luckyArr)
        {
            Lucky13 lucky13 = new Lucky13();
            bool expected = false;
            bool result = lucky13.GetLucky(luckyArr);
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(new int[] { 3, 2, 4 })]
        [DataRow(new int[] { 3 })]
        [DataRow(new int[] { 3, 3, 3 })]
        [DataRow( new int[] { 3, -2, -4 })]
        public void HasThrees(int[] luckyArr)
        {
            Lucky13 lucky13 = new Lucky13();
            bool expected = false;
            bool result = lucky13.GetLucky(luckyArr);
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(new int[] { 0, 2, 4 })]
        [DataRow(new int[] { 0 })]
        [DataRow(new int[] { 111, 333, 1313 })]
        [DataRow(new int[] { -1, -3 })]
        public void HasOnesAndThrees(int[] luckyArr)
        {
            Lucky13 lucky13 = new Lucky13();
            bool expected = true;
            bool result = lucky13.GetLucky(luckyArr);
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(new int[] { })]
        public void EmptyArray(int[] luckyArr)
        {
            Lucky13 lucky13 = new Lucky13();
            bool expected = true;
            bool result = lucky13.GetLucky(luckyArr);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NullArray()
        {
            Lucky13 lucky13 = new Lucky13();
            int[] emptyArray = null;
            bool expected = true;
            bool result = lucky13.GetLucky(emptyArray);
            Assert.AreEqual(expected, result);
        }
    }
}

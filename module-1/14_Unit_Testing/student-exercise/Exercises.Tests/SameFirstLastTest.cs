using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class SameFirstLastTest
    {
        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { -1, 2, 1 })]
        [DataRow(new int[] { 0, 7, 7 })]
        [DataRow(new int[] { 7, 7, 0 })]
        [DataRow(new int[] { 7, 1 })]
        [DataRow(new int[] { int.MinValue, 6, 23, 191, int.MaxValue })]
        public void FirstAndLastNotSame(int[] firstLastArray)
        {
            SameFirstLast sameFirstLast = new SameFirstLast();
            bool expected = false;
            bool result = sameFirstLast.IsItTheSame(firstLastArray);
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3, 1 })]
        [DataRow(new int[] { 1, 2, 1 })]
        [DataRow(new int[] { -1, 2, -1 })]
        [DataRow(new int[] { 0, 2, 2, 0 })]
        [DataRow(new int[] { int.MaxValue, 7, int.MaxValue })]
        [DataRow(new int[] { int.MinValue, 7, int.MinValue })]
        public void FirstAndLastSame(int[] firstLastArray)
        {
            SameFirstLast sameFirstLast = new SameFirstLast();
            bool expected = true;
            bool result = sameFirstLast.IsItTheSame(firstLastArray);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Array1LessThan1()
        {
            SameFirstLast sameFirstLast = new SameFirstLast();
            int[] emptyArray = new int[0] { };
            bool expected = false;
            bool result = sameFirstLast.IsItTheSame(emptyArray);
            Assert.AreEqual(expected, result);
        }
        
        [TestMethod]
        public void NullArray()
        {
            SameFirstLast sameFirstLast = new SameFirstLast();
            int[] nullArray = null;
            bool expected = false;
            bool result = sameFirstLast.IsItTheSame(nullArray);
            Assert.AreEqual(expected, result);
        }
    }
}

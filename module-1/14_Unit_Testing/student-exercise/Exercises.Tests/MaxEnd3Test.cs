using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class MaxEnd3Test
    {
        /*
         Given an array of ints length 3, figure out which is larger between the first and last elements 
         in the array, and set all the other elements to be that value. Return the changed array.
         MakeArray([1, 2, 3]) → [3, 3, 3]
         MakeArray([11, 5, 9]) → [11, 11, 11]
         MakeArray([2, 11, 3]) → [3, 3, 3]
         */

        [DataTestMethod]
        [DataRow(new int[] { 11, 5, 9 }, new int[] { 11, 11, 11 })]
        [DataRow(new int[] { 10, 99, 5 }, new int[] { 10, 10, 10 })]
        [DataRow(new int[] { 5, 4, -10 }, new int[] { 5, 5, 5 })]
        [DataRow(new int[] { 1, 0, 0 }, new int[] { 1, 1, 1 })]
        public void FirstIsLargest(int[] originalArr, int[] expected)
        {
            MaxEnd3 maxend3 = new MaxEnd3();
            maxend3.MakeArray(originalArr);
            CollectionAssert.AreEqual(expected, originalArr);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 3, 3, 3 })]
        [DataRow(new int[] { 2, 11, 3 }, new int[] { 3, 3, 3 })]
        [DataRow(new int[] { 5, 99, 10 }, new int[] { 10, 10, 10 })]
        [DataRow(new int[] { -10, 4, 5 }, new int[] { 5, 5, 5 })]
        [DataRow(new int[] { 0, 0, 1 }, new int[] { 1, 1, 1 })]
        public void LastIsLargest(int[] originalArr, int[] expected)
        {
            MaxEnd3 maxend3 = new MaxEnd3();
            maxend3.MakeArray(originalArr);
            CollectionAssert.AreEqual(expected, originalArr);
        }
    }
}

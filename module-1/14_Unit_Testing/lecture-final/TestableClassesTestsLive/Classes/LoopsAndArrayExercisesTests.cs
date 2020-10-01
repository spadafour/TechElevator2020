using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestableClasses.Classes;

namespace TestableClassesTestsLive.Classes
{
    [TestClass]
    public class LoopsAndArrayExercisesTests
    {
        //CollectionAssert
        //.AllItemsAreNotNull() - Looks at each item in actual collection for not null
        //.AllItemsAreUnique() - Checks for uniqueness among actual collection
        //.AreEqual() - Checks to see if two collections are equal (same order and quantity)
        //.AreEquivalent() - Checks to see if two collections have same element in same quantity, any order
        //.AreNotEqual() - Opposite of AreEqual
        //.AreNotEquivalent() - Opposite or AreEqualivent
        //.Contains() - Checks to see if collection contains a value/object

        [TestMethod]
        public void MiddleWayTestHappyPath()
        {
            //middleWay([1, 2, 3], [4, 5, 6]) → [2, 5]
            //middleWay([7, 7, 7], [3, 8, 0]) → [7, 8]
            //middleWay([5, 2, 9], [1, 4, 5]) → [2, 4]

            // Arrange
            LoopsAndArrayExercises loopsAndArrayExercises = new LoopsAndArrayExercises();
            int[] first = { 1, 2, 3 };
            int[] second = { 4, 5, 6 };
            int[] expected = { 2, 5 };

            // Act
            int[] result = loopsAndArrayExercises.MiddleWay(first, second);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}

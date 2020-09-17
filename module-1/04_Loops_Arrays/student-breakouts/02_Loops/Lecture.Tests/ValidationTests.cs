using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lecture.Tests
{
    [TestClass]
    public class ValidationTests
    {
        private LectureProblem exercises = new LectureProblem();

        [TestMethod]
        public void Test_06_ReturnCounterFromLoop()
        {
            Assert.AreEqual(18, exercises.ReturnSumArray(), "Are you sure you added correctly?");
        }

        [TestMethod]
        public void Test_07_ReturnCorrectSum()
        {
            Assert.AreEqual(18, exercises.ReturnCorrectSum(new int[] { 2, 0, 7, 9 }), "Are you sure all of the numbers are getting added?");
        }

        [TestMethod]
        public void Test_08_ReturnCorrectSumAgain()
        {
            Assert.AreEqual(18, exercises.ReturnCorrectSumAgain(new int[] { 2, 0, 7, 9 }), "Are you sure all of the numbers are getting added?");
        }

        [TestMethod]
        public void Test_09_ReturnSumEveryOtherNumber()
        {
            Assert.AreEqual(12, exercises.ReturnSumEveryOtherNumber(new int[] { 4, 3, 4, 1, 4, 6 }), "4 + 4 + 4 should add up to 12.");
        }

        [TestMethod]
        public void Test_10_ReturnHighestNumber()
        {
            Assert.AreEqual(13, exercises.FindTheHighestNumber(new int[] { 3, 12, 11, 13, 2, 4 }), "13 is the highest number in { 3, 12, 11, 13, 2, 4 }");
            Assert.AreEqual(103, exercises.FindTheHighestNumber(new int[] { 23, 12, 51, 103, 12, 4 }), "103 is the highest number in { 23, 12, 51, 103, 12, 4 }");

        }
    }
}

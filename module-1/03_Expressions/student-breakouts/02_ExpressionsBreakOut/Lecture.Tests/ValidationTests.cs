using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lecture;

namespace Lecture.Tests
{
    [TestClass]
    public class ValidationTests
    {
        private LectureExample exercises = new LectureExample();

        [TestMethod]
        public void Test_06_ReturnTrueFromIf()
        {
            Assert.IsTrue(exercises.ReturnTrueFromIf(), "If statement should return true");
        }

        [TestMethod]
        public void Test_07_ReturnTrueWhenOneEqualsOne()
        {
            Assert.IsTrue(exercises.ReturnTrueWhenOneEqualsOne(), "If statement should return true");
        }

        [TestMethod]
        public void Test_08_ReturnTrueWhenGreaterThanFive()
        {
            Assert.IsTrue(exercises.ReturnTrueWhenGreaterThanFive(6), "We should return true when parameter is greater than five");
            Assert.IsFalse(exercises.ReturnTrueWhenGreaterThanFive(5), "We should return false when parameter is five");
            Assert.IsFalse(exercises.ReturnTrueWhenGreaterThanFive(4), "We should return false when parameter is smaller than five");
        }

        [TestMethod]
        public void Test_09_ReturnTrueWhenGreaterThanFiveInOneLine()
        {
            Assert.IsTrue(exercises.ReturnTrueWhenGreaterThanFiveInOneLine(6), "We should return true when parameter is greater than five");
            Assert.IsFalse(exercises.ReturnTrueWhenGreaterThanFiveInOneLine(5), "We should return false when parameter is five");
            Assert.IsFalse(exercises.ReturnTrueWhenGreaterThanFiveInOneLine(4), "We should return false when parameter is smaller than five");
        }

        [TestMethod]
        public void Test_10_ReturnNumberAfterAddThreeAndAddFive()
        {
            Assert.AreEqual(9, exercises.ReturnNumberAfterAddThreeAndAddFive(1, true, true), "We should add three and five when both are true");
            Assert.AreEqual(4, exercises.ReturnNumberAfterAddThreeAndAddFive(1, true, false), "We should add three when passed true false");
            Assert.AreEqual(6, exercises.ReturnNumberAfterAddThreeAndAddFive(1, false, true), "We should add five when passed false true");
            Assert.AreEqual(1, exercises.ReturnNumberAfterAddThreeAndAddFive(1, false, false), "We should return the original number when both are false");
        }

       

       

       
    }
}

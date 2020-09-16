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
        public void Test_01_ReturnNotOne()
        {
            Assert.AreNotEqual(1, exercises.ReturnNotOne(), "Value returned shouldn't be one");
        }


        [TestMethod]
        public void Test_02_ReturnNotHalf()
        {
            Assert.AreNotEqual(0.5, exercises.ReturnNotHalf(), 0.001, "Value returned shouldn't be 0.5");
        }

        [TestMethod]
        public void Test_03_ReturnName()
        {
            Assert.IsNotNull(exercises.ReturnName(), "Value returned should be your name");
        }

        [TestMethod]
        public void Test_04_ReturnDoubleOfTwo()
        {
            Assert.IsTrue(exercises.ReturnDoubleOfTwo().GetType() == typeof(double), "Value returned should be a double");
            Assert.AreEqual(2.0, exercises.ReturnDoubleOfTwo(), 0, "Value returned should still equal two");
        }

        [TestMethod]
        public void Test_05_ReturnNameOfLanguage()
        {
            Assert.AreEqual("C#", exercises.ReturnNameOfLanguage(), "Value should equal the name of the programming language you're learning");
        }

        

       
    }
}

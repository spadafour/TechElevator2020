using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class FrontTimesTest
    {
        [DataTestMethod]
        [DataRow("Chocolate", 2, "ChoCho")]
        [DataRow("Chocolate", 3, "ChoChoCho")]
        [DataRow("Abc", 3, "AbcAbcAbc")]
        [DataRow("Hercules", 8, "HerHerHerHerHerHerHerHer")]
        [DataRow("Hercules", 0, "")]
        public void Length3OrMore(string word, int num, string expected)
        {
            FrontTimes frontTimes = new FrontTimes();
            string result = frontTimes.GenerateString(word, num);
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("No", 4, "NoNoNoNo")]
        [DataRow("I", 3, "III")]
        [DataRow("No", 0, "")]

        public void LengthLessThan3(string word, int num, string expected)
        {
            FrontTimes frontTimes = new FrontTimes();
            string result = frontTimes.GenerateString(word, num);
            Assert.AreEqual(expected, result);
        }
        
        [TestMethod]
        public void ZeroLengthWord()
        {
            string word = ""; int num = 3; string expected = "";
            FrontTimes frontTimes = new FrontTimes();
            string result = frontTimes.GenerateString(word, num);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NullString()
        {
            string word = null; int num = 3; string expected = "";
            FrontTimes frontTimes = new FrontTimes();
            string result = frontTimes.GenerateString(word, num);
            Assert.AreEqual(expected, result);
        }
    }
}

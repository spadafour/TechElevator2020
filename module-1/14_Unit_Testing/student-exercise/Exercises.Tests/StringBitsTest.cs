using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class StringBitsTest
    {
        [DataTestMethod]
        [DataRow("Hello", "Hlo")]
        [DataRow("Hi", "H")]
        [DataRow("Heeololeo", "Hello")]
        [DataRow("12345678", "1357")]
        [DataRow("", "")]
        [DataRow("A", "A")]
        public void GetBits(string input, string expected)
        {
            StringBits stringBits = new StringBits();
            string result = stringBits.GetBits(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetBitisNull()
        {
            StringBits stringBits = new StringBits();
            string nullString = null;
            string expected = "";
            string result = stringBits.GetBits(nullString);
            Assert.AreEqual(expected, result);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class NonStartTest
    {
        [DataTestMethod]
        [DataRow("Hello", "There", "ellohere")]
        [DataRow("java", "code", "avaode")]
        [DataRow("shotl", "java", "hotlava")]
        [DataRow("a", "blueberry", "lueberry")]
        [DataRow("guacamole", "b", "uacamole")]
        [DataRow("123", "456", "2356")]
        public void PartialStringTest(string a, string b, string expected)
        {
            NonStart nonStart = new NonStart();
            string result = nonStart.GetPartialString(a, b);
            Assert.AreEqual(expected, result);
        }
    }
}

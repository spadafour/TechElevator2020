using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class WordCountTest
    {
        [TestMethod]
        public void GetCountTest()
        {
            WordCount wordCount = new WordCount();

            string[] inputStrings = new string[]
            {
                "ba", "ba", "black", "sheep"
            };
            Dictionary<string, int> expected = new Dictionary<string, int>
            {
                { "ba", 2 }, { "black", 1 }, { "sheep", 1 }
            };
            Dictionary<string, int> results = wordCount.GetCount(inputStrings);
            CollectionAssert.AreEqual(expected, results);


            inputStrings = new string[]
            {
                "a", "b", "a", "c", "b"
            };
            expected = new Dictionary<string, int>
            {
                { "a", 2 }, { "b", 2 }, { "c", 1 }
            };
            results = wordCount.GetCount(inputStrings);
            CollectionAssert.AreEqual(expected, results);


            inputStrings = new string[]
            {
                "c", "b", "a"
            };
            expected = new Dictionary<string, int>
            {
                {"c", 1 }, {"b", 1 }, {"a", 1}
            };
            results = wordCount.GetCount(inputStrings);
            CollectionAssert.AreEqual(expected, results);
        }


        [TestMethod]
        public void EmptyArray()
        {
            WordCount wordCount = new WordCount();

            string[] inputStrings = new string[] { };
            Dictionary<string, int> expected = new Dictionary<string, int> { };
            Dictionary<string, int> results = wordCount.GetCount(inputStrings);
            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NullArray()
        {
            WordCount wordCount = new WordCount();

            string[] inputStrings = new string[] { null };
            Dictionary<string, int> expected = new Dictionary<string, int> { };
            Dictionary<string, int> results = wordCount.GetCount(inputStrings);
            CollectionAssert.AreEqual(expected, results);
        }
    }
}

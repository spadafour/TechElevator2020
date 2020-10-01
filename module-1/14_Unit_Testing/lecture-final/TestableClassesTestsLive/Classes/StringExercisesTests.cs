using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestableClasses.Classes;

namespace TestableClassesTestsLive.Classes
{
    [TestClass]
    public class StringExercisesTests
    {

        //Assert
        //.AreEqual() - compares expected and actual value for equality
        //.AreSame() - verifies two object variables refer to same object
        //.AreNotSame() - verifies two object variables refer to different objects
        //.Fail() - fails without checking conditions
        //.IsFalse()
        //.IsTrue()
        //.IsNotNull()
        //.IsNull()

        [TestMethod]
        public void MakeAbbaTestHappyPath()
        {
            //makeAbba("Hi", "Bye") → "HiByeByeHi"
            //makeAbba("Yo", "Alice") → "YoAliceAliceYo"
            //makeAbba("What", "Up") → "WhatUpUpWhat"
            //makeAbba("Henry","Mimi) -> "HenryMimiMimiHenry"
            //makeAbba("Tech","Elevator") -> "TechElevatorElevatorTech"

            // Arrange
            StringExercises stringExercises = new StringExercises();
            string expected = "HiByeByeHi";
            string inputOne = "Hi";
            string inputTwo = "Bye";
            string result = "";

            // Act
            result = stringExercises.MakeAbba(inputOne, inputTwo);

            // Assert
            Assert.AreEqual(expected, result);

            // let's do another
            inputOne = "Henry";
            inputTwo = "Mimi";
            expected = "HenryMimiMimiHenry";

            // Act
            result = stringExercises.MakeAbba(inputOne, inputTwo);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MakeAbbaTestExceptions()
        {
            // Arrange
            StringExercises stringExercises = new StringExercises();
            string inputOne = "";
            string inputTwo = "Hello";
            string expected = "HelloHello";

            // Act
            string actually = stringExercises.MakeAbba(inputOne, inputTwo);

            // Assert
            Assert.AreEqual(expected, actually);

            // Arrange
            inputOne = null;
            expected = null;

            // Act
            actually = stringExercises.MakeAbba(inputOne, inputTwo);

            // Assert
            Assert.AreEqual(expected, actually,"Sorry, product owner wants it to be null");

        }
    }
}

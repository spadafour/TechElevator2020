using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class AnimalGroupNameTest
    {
        [DataTestMethod]
        [DataRow("Rhino", "Crash")]
        [DataRow("Giraffe", "Tower")]
        [DataRow("Elephant", "Herd")]
        [DataRow("Lion", "Pride")]
        [DataRow("Crow", "Murder")]
        [DataRow("Pigeon", "Kit")]
        [DataRow("Flamingo", "Pat")]
        [DataRow("Deer", "Herd")]
        [DataRow("Dog", "Pack")]
        [DataRow("Crocodile", "Float")]
        public void AllAnimals(string animalName, string groupName)
        {
            //Arrange
            AnimalGroupName AnimalGroupName = new AnimalGroupName();
            //Act
            string result = AnimalGroupName.GetHerd(animalName);
            //Assert
            Assert.AreEqual(groupName, result);
        }

        [DataTestMethod]
        [DataRow("Rhino", "Crash")]
        [DataRow("Giraffe", "Tower")]
        [DataRow("Elephant", "Herd")]
        [DataRow("Lion", "Pride")]
        [DataRow("Crow", "Murder")]
        [DataRow("Pigeon", "Kit")]
        [DataRow("Flamingo", "Pat")]
        [DataRow("Deer", "Herd")]
        [DataRow("Dog", "Pack")]
        [DataRow("Crocodile", "Float")]
        public void UppercaseInsensitive(string animalName, string groupName)
        {
            //Arrange
            AnimalGroupName animalGroupName = new AnimalGroupName();
            string animalNameUpper = animalName.ToUpper();
            //Act
            string result = animalGroupName.GetHerd(animalNameUpper);
            //Assert
            Assert.AreEqual(groupName, result);
        }

        [DataTestMethod]
        [DataRow("Rhino", "Crash")]
        [DataRow("Giraffe", "Tower")]
        [DataRow("Elephant", "Herd")]
        [DataRow("Lion", "Pride")]
        [DataRow("Crow", "Murder")]
        [DataRow("Pigeon", "Kit")]
        [DataRow("Flamingo", "Pat")]
        [DataRow("Deer", "Herd")]
        [DataRow("Dog", "Pack")]
        [DataRow("Crocodile", "Float")]
        public void LowercaseInsensitive(string animalName, string groupName)
        {
            //Arrange
            AnimalGroupName animalGroupName = new AnimalGroupName();
            string animalNameLower = animalName.ToLower();
            //Act
            string result = animalGroupName.GetHerd(animalNameLower);
            //Assert
            Assert.AreEqual(groupName, result);
        }

        [DataTestMethod]
        [DataRow("Cat")]
        [DataRow("")]
        [DataRow(null)]
        public void IsUnkown(string animalName)
        {
            //Assert
            AnimalGroupName animalGroupName = new AnimalGroupName();
            string expected = "unknown";
            //Act
            string result = animalGroupName.GetHerd(animalName);
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}

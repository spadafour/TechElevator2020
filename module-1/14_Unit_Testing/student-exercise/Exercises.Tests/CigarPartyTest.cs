using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class CigarPartyTest
    {
        [DataTestMethod]
        [DataRow(39, false)]
        [DataRow(40, true)]
        [DataRow(41, true)]
        [DataRow(50, true)]
        [DataRow(59, true)]
        [DataRow(60, true)]
        [DataRow(61, false)]
        [DataRow(120, false)]
        [DataRow(int.MinValue, false)]
        [DataRow(int.MaxValue, false)]
        [DataRow(-1, false)]
        public void WeekdayTest(int cigars, bool expected)
        {
            //Arrange
            CigarParty cigarParty = new CigarParty();
            //Act
            bool result = cigarParty.HaveParty(cigars, false);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(39, false)]
        [DataRow(40, true)]
        [DataRow(41, true)]
        [DataRow(50, true)]
        [DataRow(59, true)]
        [DataRow(60, true)]
        [DataRow(61, true)]
        [DataRow(120, true)]
        [DataRow(int.MinValue, false)]
        [DataRow(int.MaxValue, true)]
        [DataRow(-1, false)]
        public void WeekendTest(int cigars, bool expected)
        {
            CigarParty cigarParty = new CigarParty();
            bool result = cigarParty.HaveParty(cigars, true);
            Assert.AreEqual(expected, result);
        }
    }
}

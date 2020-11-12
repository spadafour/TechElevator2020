using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using System.IO;
using System.Reflection;
using System;
using FlyByNightTests.PageObjects;

namespace FlyByNightTests
{
    [TestClass]
    public class MortgageCalculatorIntegrationTestWithPageObject
    {
        private static IWebDriver webDriver;
        private HomePage homePage;

        [TestInitialize]
        public void TestInit()
        {
            webDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            webDriver.Navigate().GoToUrl(Helper.URL);
            homePage = new HomePage(webDriver);
        }

        [TestCleanup]
        public void CleanUp()
        {
            webDriver.Close();
        }

        [TestMethod]
        public void forms_can_be_edited_and_submitted()
        {
            MortgageCalculatorResultPage resultPage = homePage.clickMortgageCalculatorLink()
                                                        .enterLoanAmount("100000")
                                                        .enterLoanTerm("15 Years")
                                                        .enterInterestRate("4.5")
                                                        .submitForm();

            Assert.AreEqual("$764.99", resultPage.getPaymentAmount());
        }

        [TestMethod]
        public void forms_can_be_edited_and_submitted_high_value()
        {
            MortgageCalculatorResultPage resultPage = homePage.clickMortgageCalculatorLink()
                                                        .enterLoanAmount("1000000")
                                                        .enterLoanTerm("30 Years")
                                                        .enterInterestRate("5.5")
                                                        .submitForm();

            Assert.AreEqual("$5,677.89", resultPage.getPaymentAmount());
        }

    }
}

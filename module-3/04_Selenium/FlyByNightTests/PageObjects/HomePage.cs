using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace FlyByNightTests.PageObjects
{

    public class HomePage
    {
        private IWebDriver webDriver;

        public HomePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public MortgageCalculatorInputPage clickMortgageCalculatorLink()
        {
            IWebElement calculatorLink = webDriver.FindElement(By.LinkText("Mortgage Payment Calculator"));
            calculatorLink.Click();
            return new MortgageCalculatorInputPage(webDriver);
        }

    }
}

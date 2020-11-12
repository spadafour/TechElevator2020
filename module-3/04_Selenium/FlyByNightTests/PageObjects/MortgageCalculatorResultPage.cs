using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace FlyByNightTests.PageObjects
{
    public class MortgageCalculatorResultPage
    {
        private IWebDriver webDriver;

        public MortgageCalculatorResultPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public String getPaymentAmount()
        {
            return webDriver.FindElement(By.XPath("//table[@id=\"loanPaymentCalculationResults\"]//tr[4]/td")).Text;
        }

        public String getTitle()
        {
            return webDriver.Title;
        }
    }
}

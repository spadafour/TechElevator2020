using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace FlyByNightTests.PageObjects
{
    public class MortgageCalculatorInputPage
    {
        private IWebDriver webDriver;

        public MortgageCalculatorInputPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public MortgageCalculatorInputPage enterLoanAmount(String loanAmount)
        {
            IWebElement amountField = webDriver.FindElement(By.Name("loanAmount"));
            amountField.SendKeys(loanAmount);
            return this;
        }

        public MortgageCalculatorInputPage enterLoanTerm(String loanTerm)
        {
            SelectElement termField = new SelectElement(webDriver.FindElement(By.Name("loanTermInYears")));
            termField.SelectByText(loanTerm);
            return this;
        }

        public MortgageCalculatorInputPage enterInterestRate(String rate)
        {
            IWebElement amountField = webDriver.FindElement(By.Name("interestRate"));
            amountField.SendKeys(rate);
            return this;
        }

        public MortgageCalculatorResultPage submitForm()
        {
            IWebElement submitButton = webDriver.FindElement(By.ClassName("formSubmitButton"));
            submitButton.Click();
            return new MortgageCalculatorResultPage(webDriver);
        }
    }
}

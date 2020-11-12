using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using System.IO;
using System.Reflection;
using System;

namespace FlyByNightTests
{
    [TestClass]
    public class MortgageCalculatorIntegrationWithoutPageObject
    {
        private static IWebDriver webDriver;

        [TestInitialize]
        public void TestInit()
        {
            webDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            webDriver.Navigate().GoToUrl(Helper.URL);
        }

        [TestCleanup]
        public void CleanUp()
        {
            webDriver.Close();
        }
        /* In order for Selenium to interact with a web page, it needs to be
         * able to locate elements within the page. It does this using the 
         * WebDriver.findElementBy(...) and WebDriver.findElementsBy(...)
         * methods. Both of these elements take a org.openqa.selenium.By
         * object as an argument. The following static methods return
         * By objects for different kinds of element queries:
         * 
         *  - By.className(String className) .
         *  - By.cssSelector(String selector) 
         *  - By.id(String id)  #
         *  - By.linkText(String linkText)  
         *  - By.name(String name)      name='whatever'
         *  - By.tagName(String name)  <tag>
         */


        /* Whenever possible, it is best to find page elements using the
         * HTML id attribute since this is the most efficient. Remember
         * that the element id is supposed to be unique per page */
        [TestMethod]
        public void elements_can_be_found_by_id()
        {
            IWebElement savingsH2 = webDriver.FindElement(By.Id("savings"));
            IWebElement checkingH2 = webDriver.FindElement(By.Id("checking"));
            IWebElement loansH2 = webDriver.FindElement(By.Id("loans"));
            Assert.AreEqual("Start Saving", savingsH2.Text);
            Assert.AreEqual("Open Checking", checkingH2.Text);
            Assert.AreEqual("Loans", loansH2.Text);
        }

        [TestMethod]
        public void single_elements_can_be_found_by_tag_name()
        {
            IWebElement header = webDriver.FindElement(By.TagName("header"));
            IWebElement footer = webDriver.FindElement(By.TagName("footer"));
            Assert.IsNotNull(header);
            Assert.IsNotNull(footer);
        }

        [TestMethod]
        public void pages_can_be_navigated_by_clicking_on_links()
        {
            // Link elements (i.e. <a> tags) can be found based on their text
            IWebElement calculatorLink = webDriver.FindElement(By.LinkText("Mortgage Payment Calculator")); // <a href="www.whatever.com"> THIS IS THE LINK TEXT</a>
            calculatorLink.Click();

            // The .Title returns the value of the page title
            Assert.IsTrue(webDriver.Title.EndsWith("Mortgage Calculator"));
            IWebElement h2 = webDriver.FindElement(By.TagName("h2"));
            Assert.AreEqual("Mortgage Calculator", h2.Text);
        }

        [TestMethod]
        public void forms_can_be_edited_and_submitted()
        {
            IWebElement calculatorLink = webDriver.FindElement(By.LinkText("Mortgage Payment Calculator"));
            calculatorLink.Click();

            IWebElement amountField = webDriver.FindElement(By.Name("loanAmount"));
            // The sendKeys(...) method can be used to simulate typing in a field
            amountField.SendKeys("100000");

            // To interact with a <select> element, wrap the WebElement in a Select object
            SelectElement termField = new SelectElement(webDriver.FindElement(By.Name("loanTermInYears")));
            termField.SelectByText("15 Years");

            IWebElement interestField = webDriver.FindElement(By.Name("interestRate"));
            interestField.SendKeys("4.5");

            IWebElement submitButton = webDriver.FindElement(By.ClassName("formSubmitButton"));
            submitButton.Click();

            /* Elements without an id can be found using an xPath expression.
             * However, finding elements by xPath should generally be avoided 
             * as it is slow and makes for brittle tests. */
            IWebElement paymentValueTd = webDriver.FindElement(By.XPath("//*[@id=\"loanPaymentCalculationResults\"]/tbody/tr[4]/td"));
            Assert.AreEqual("$764.99", paymentValueTd.Text);

        }
    }
}

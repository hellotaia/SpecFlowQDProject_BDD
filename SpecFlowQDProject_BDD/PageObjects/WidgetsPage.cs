using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SpecFlowQDProject_BDD.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowQDProject_BDD.PageObjects
{
    public class WidgetsPage:BasePage
    {
        public WidgetsPage(IWebDriver driver) : base(driver)
        {
        }

        //auto complete elements
        public IWebElement FieldNameLocator(string fieldValue) =>
            driver.FindElement(By.XPath($"//span[text()='{fieldValue}']/following-sibling::div"));
        public IWebElement RemoveNameLocator(string colorValue) =>
            driver.FindElement(By.XPath($"//div[text()='{colorValue}']/following-sibling::div"));
        public IWebElement ColorNameLocator(string colorValue) =>
            driver.FindElement(By.XPath($"//div[text()='{colorValue}']"));
        //progress bar elements
        public IWebElement StartStopButton => 
            driver.FindElement(By.XPath($"//button[contains(@class,'mt-3')]"));
        public IWebElement ProgressBarLocator => 
            driver.FindElement(By.XPath($"//div[@role='progressbar']"));
        public IList<IWebElement> suggestions =>
                driver.FindElements(By.XPath("//div[contains(@class,'auto-complete__menu-list')]/div"));

        //fills text value to the field
        public WidgetsPage FillsFieldValue (string value, string field)
        {
            var fieldName = FieldNameLocator(field);
            var actions = new Actions(driver);
            fieldName.Click();
            actions.SendKeys(value).Perform();
            return this;
        }
        //suggestions results count
        public WidgetsPage SuggestionsCount(int x)
        {
            int expectedInt = x;
            int actualInt = suggestions.Count();
            Assert.AreEqual(expectedInt, actualInt);
            return this;
        }

        //verifies paramets
        public bool IsSuggestionsContains(string value)
        {
            foreach (IWebElement suggestion in suggestions)
            {
                string text = suggestion.Text.ToLower();
                if (!text.Contains($"{value}"))
                    return false;
            }
            return true;
        }

        //add color value
        public WidgetsPage AddColorName(string color, string field)
        {
            var fieldName = FieldNameLocator(field);
            var actions = new Actions(driver);
            fieldName.Click();
            actions.SendKeys(color).Perform();
            Thread.Sleep(500);
            actions.SendKeys(Keys.Enter).Perform();
            return this;
        }

        //delete color value
        public WidgetsPage DeleteColorName (string color) 
        {
            var button = RemoveNameLocator(color);
            button.Click();
            return this;
        }

        // verify that color is not deleted
        public bool IsColorDisplayed (string color)
        {
            IList<IWebElement> colors =
               driver.FindElements(By.XPath("//div[contains(@class,'auto-complete__multi-value__label')]"));
            foreach (IWebElement colorElement in colors)
            {
                if (colorElement.Text.Contains(color))
                {
                    return true;
                }
            }
            return false;
        }

        //progress bar
        public WidgetsPage VerifyButtonName (string buttonName)
        {
            string actualName = StartStopButton.Text;
            Assert.AreEqual(buttonName, actualName);
            return this;
        }

        public WidgetsPage ProgressBarWaiter (string value)
        {
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(10));
            wait.Until(driver =>
            {
                string progressBarValue = ProgressBarLocator.Text;
                return progressBarValue == value;
            });
            Thread.Sleep(500);
            return this;
        }

        public WidgetsPage VerifyProgressBarValue(string value)
        {
            string actualValue = ProgressBarLocator.Text;
            Assert.AreEqual(value, actualValue);
            return this;
        }
    }
}

    
   
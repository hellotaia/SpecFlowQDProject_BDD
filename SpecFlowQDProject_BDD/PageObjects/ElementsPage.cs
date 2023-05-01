﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowQDProject_BDD.PageObjects
{
    public class ElementsPage : BasePage
    {

        public ElementsPage(IWebDriver driver) :base(driver)
        {
        }

        //text box elements
        private IWebElement FullName => driver.FindElement(By.XPath("//input[@id='userName']"));
        private IWebElement Email => driver.FindElement(By.XPath("//input[@id='userEmail']"));
        private IWebElement CurrentAddress => driver.FindElement(By.XPath("//textarea[@id='currentAddress']"));
        private IWebElement PermanentAddress => driver.FindElement(By.XPath("//textarea[@id='permanentAddress']"));
        private IWebElement SubmitButton => driver.FindElement(By.XPath("//button[@id='submit']"));
        private IList<IWebElement> TableRowsLocator => driver.FindElements(By.XPath("//table[@class='table']//tbody//tr"));
        private IWebElement PageTitleLocator => driver.FindElement(By.XPath($"//div[@class='main-header']"));
        private IWebElement MenuButtonLocator(string buttonName) => driver.FindElement(By.XPath($"//span[text()='{buttonName}']"));
        private IWebElement ButtonByNameLocator(string buttonName) => driver.FindElement(By.XPath($"//button[text()='{buttonName}']"));

        public ElementsPage FillTextBoxForm(Table tableData)
        {
            var expectedData = tableData.Rows[0];
            var fullName = expectedData["Full Name"];
            var email = expectedData["Email"];
            var currentAddress = expectedData["Current Address"];
            var permanentAddress = expectedData["Permanent Address"];

 
            FullName.SendKeys(fullName);
            Email.SendKeys(email);
            CurrentAddress.SendKeys(currentAddress);
            PermanentAddress.SendKeys(permanentAddress);
            return this;
        }

        public ElementsPage VerifyPageTitle(string expectedPageName)
        {
            string actualTitle = PageTitleLocator.Text;
            Assert.AreEqual(expectedPageName, actualTitle, "Titles are not equal");
            return this;
        }

        public ElementsPage VerifyDataAtTheTable(Table expectedData)
        {
            var expectedTableRows = expectedData.Rows;
            var actualTableRows = TableRowsLocator;

            Assert.AreEqual(expectedTableRows.Count, actualTableRows.Count);

            for (int i = 0; i < expectedTableRows.Count; i++)
            {
                var expectedRow = expectedTableRows[i];
                var actualRowCells = actualTableRows[i].FindElements(By.TagName("td"));

                Assert.AreEqual(expectedRow["FullName"], actualRowCells[0].Text);
                Assert.AreEqual(expectedRow["Email"], actualRowCells[1].Text);
                Assert.AreEqual(expectedRow["Current Address"], actualRowCells[2].Text);
                Assert.AreEqual(expectedRow["Permanent Address"], actualRowCells[3].Text);
            }
            return this;
        }

        public ElementsPage ClickOnMenuButton(string menuButtonName)
        {
            MenuButtonLocator(menuButtonName).Click();
            return this;
        }

        public ElementsPage ClickButton(string buttonName)
        {
            ButtonByNameLocator(buttonName).Click();
            return this;
        }
    }
}

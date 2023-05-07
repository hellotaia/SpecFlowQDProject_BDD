using OpenQA.Selenium;
using NUnit.Framework;
using SpecFlowQDProject_BDD.StepDefinitions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace SpecFlowQDProject_BDD.PageObjects
{
    public class ElementsPage : BasePage
    {
        public ElementsPage(IWebDriver driver):base(driver)
        {
        }

        //text box elements
        public IWebElement FullName => driver.FindElement(By.XPath("//input[@id='userName']"));
        public IWebElement Email => driver.FindElement(By.XPath("//input[@id='userEmail']"));
        public IWebElement CurrentAddress => driver.FindElement(By.XPath("//textarea[@id='currentAddress']"));
        public IWebElement PermanentAddress => driver.FindElement(By.XPath("//textarea[@id='permanentAddress']"));
        public IWebElement SubmitButton => driver.FindElement(By.XPath("//button[@id='submit']"));

        private IList<IWebElement> TableRowsLocator => driver.FindElements(By.XPath("//table[@class='table']//tbody//tr"));

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

       
        //check box elements
        private IWebElement FolderLocator(string folderName) => 
            driver.FindElement(By.XPath($"//span[text()='{folderName}']"));
        private IWebElement ToggleLocator(string folderName) => 
            driver.FindElement(By.XPath($"//span[text()='{folderName}']/ancestor::li[1]/span/button"));

        private IList<IWebElement> SelectResultLocator => driver.FindElements(By.XPath("//div[@id='result']/span[text()]"));

        public ElementsPage ClickFolderName(string folderName)
        {
            FolderLocator(folderName).Click();
            return this;
        }

        public ElementsPage ClickToggleName (string folderName)
        {
            ToggleLocator(folderName).Click(); 
            return this;
        }

        public ElementsPage CheckSelectResults(string expectedSelected)
        {
            var expectedString = expectedSelected;
            List<string> elementTexts = new List<string>();
            foreach (IWebElement element in SelectResultLocator)
            {
                elementTexts.Add(element.Text);
            }
            string actualString = string.Join(" ", elementTexts);
            Assert.AreEqual(expectedString, actualString);
            return this;
        }

    }
}

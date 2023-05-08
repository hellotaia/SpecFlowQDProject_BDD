﻿using NUnit.Framework;
using OpenQA.Selenium;

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
            var tElement = driver.FindElement(By.Id("output")).Text;

            var tableRows = tElement.Split("\n");
            for (int i = 0; i < tableRows.Length; i++)
            {
                tableRows[i] = tableRows[i].Trim();
            }
            var tableColumns = tableRows[0].Split("|").Where(c => !string.IsNullOrWhiteSpace(c)).Select(c => c.Trim()).ToList();

            var table = new Table(tableColumns.ToArray());

            for (int i = 1; i < tableRows.Length; i++)
            {
                var tableRowValues = tableRows[i].Split("|").Where(c => !string.IsNullOrWhiteSpace(c)).Select(c => c.Trim()).ToArray();
                table.AddRow(tableRowValues);
            }
            return this;
            Assert.AreEqual(expectedData, table, "The actual table data does not match the expected table data.");
        }

       
        //check box elements
        private IWebElement FolderLocator(string folderName) => 
            driver.FindElement(By.XPath($"//span[text()='{folderName}']"));
        private IWebElement ToggleLocator(string folderName) => 
            driver.FindElement(By.XPath($"//span[text()='{folderName}']/ancestor::li[1]/span/button"));

        private IList<IWebElement> SelectResultLocator => 
            driver.FindElements(By.XPath("//div[@id='result']/span[text()]"));

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

        // web tables elements
        private IWebElement WebTableHeaderLocator(string columnName) =>
            driver.FindElement(By.XPath($"//div[@class='rt-resizable-header-content'][text()='{columnName}']"));
        IReadOnlyCollection<IWebElement> tableRows => driver.FindElements(By.XPath("//div[@class='rt-tr-group']"));

        public ElementsPage SortColumnAsc (string columnName)
        {
            WebTableHeaderLocator(columnName).Click();
            return this;
        }

        public bool IsColumnSortedAsc(string columnName)
        {
            int columnIndex = GetColumnIndex(columnName);
            var rows = tableRows;
            string previousValue = "";
            foreach (IWebElement row in rows)
            {
                IReadOnlyCollection<IWebElement> cells = row.FindElements(By.XPath(".//div[@class='rt-td']"));
                string value = cells.ElementAt(columnIndex).Text;
                if (previousValue != "" && String.Compare(previousValue, value) > 0)
                {
                    return false;
                }
                previousValue = value;
            }
            return true;
        }

        public List<string> GetColumnValues(string columnName)
        {
            List<string> values = new List<string>();
            int columnIndex = GetColumnIndex(columnName);
            var rows = tableRows;
            foreach (IWebElement row in rows)
            {
                IReadOnlyCollection<IWebElement> cells = row.FindElements(By.XPath(".//div[@class='rt-td']"));
                values.Add(cells.ElementAt(columnIndex).Text);
            }
            return values;
        }

        private int GetColumnIndex(string columnName)
        {
            IReadOnlyCollection<IWebElement> headers = driver.FindElements(By.XPath("//div[@class='rt-resizable-header-content']"));
            for (int i = 0; i < headers.Count; i++)
            {
                if (headers.ElementAt(i).Text.Equals(columnName))
                {
                    return i;
                }
            }
            throw new NoSuchElementException($"Column '{columnName}' not found");
        }

        public int GetRowCount()
        {
            var rows = tableRows;
            return rows.Count;
        }

        public ElementsPage DeleteRow(int rowIndex)
        {
            IWebElement row = driver.FindElement(By.XPath($"(//div[@class='rt-tr-group'])[{rowIndex}]"));
            IWebElement deleteButton = row.FindElement(By.XPath(".//div[@class='action-buttons']/span[contains(@class, 'delete')]"));
            deleteButton.Click();
            return this;
        }

    }
}

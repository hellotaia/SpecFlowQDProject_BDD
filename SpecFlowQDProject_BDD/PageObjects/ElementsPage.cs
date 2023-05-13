using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.UI;

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
        private IList<IWebElement> TableRowsLocator => driver.FindElements(By.XPath("//div[@id='output']//p"));
     //check box elements
        private IWebElement FolderLocator(string folderName) =>
            driver.FindElement(By.XPath($"//span[text()='{folderName}']"));
        private IWebElement ToggleLocator(string folderName) =>
            driver.FindElement(By.XPath($"//span[text()='{folderName}']/ancestor::li[1]/span/button"));

        private IList<IWebElement> SelectResultLocator =>
            driver.FindElements(By.XPath("//div[@id='result']/span[text()]"));
     // web tables elements
        private IWebElement WebTableHeaderLocator(string columnName) =>
            driver.FindElement(By.XPath($"//div[@class='rt-resizable-header-content'][text()='{columnName}']"));
        IReadOnlyCollection<IWebElement> tableRows => driver.FindElements(By.XPath("//div[@class='rt-tr-group']"));

        //text box methods
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
            Assert.AreEqual(expectedTableRows.Count, TableRowsLocator.Count, "Number of rows in the table was incorrect"); 
            for (int i = 0; i < expectedTableRows.Count; i++)
            {
                Assert.AreEqual(expectedTableRows[i]["TableValues"], TableRowsLocator[i].Text, "Value at the table was inncorect");
            }
            return this;
            
        }

        //check box methods
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

       //web tables methods
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
            IWebElement deleteButton = driver.FindElement(By.XPath($"//span[@id='delete-record-{rowIndex}']"));
            deleteButton.Click();
            return this;
        }
        public bool VerifyMissingValue (string columnName, string value)
        {
            int columnIndex = GetColumnIndex(columnName);
            var rows = tableRows;
            foreach (IWebElement row in rows)
            {
                IReadOnlyCollection<IWebElement> cells = row.FindElements(By.XPath(".//div[@class='rt-td']"));
                string columnValue = cells.ElementAt(columnIndex).Text;
                if (columnValue.Equals(value))
                {
                    return false;
                }
            }
            Assert.IsTrue(true);
            return true;
        }
        
        // buttons methods
        public ElementsPage ClickButtonName ( string buttonName)
        {
            var button = driver.FindElement(By.XPath($"//button[text() = '{buttonName}']"));
            var actions = new Actions(driver);
            switch (buttonName)
            {
                case "Click Me":
                    actions.Click(button).Build().Perform(); 
                    break;
                case "Double Click Me":
                    actions.DoubleClick(button).Build().Perform();
                    break;
                case "Right Click Me":
                    actions.ContextClick(button).Build().Perform();
                    break;
                default:
                    Assert.Fail($"Button '{buttonName}' not recognized.");
                    break;
            }
            return this;
        }
        public ElementsPage VerifyMsgText(string expectedText)
        {
            var message = driver.FindElement(By.XPath("//div/p[text()]"));
            Assert.That(message.Text, Is.EqualTo(expectedText));
            return this;
        }

        
    }
}

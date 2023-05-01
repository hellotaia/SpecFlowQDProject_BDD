using OpenQA.Selenium;
using SpecFlowQDProject_BDD.StepDefinitions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowQDProject_BDD.PageObjects
{
    public class ElementsPage
    {

        private IWebDriver driver;

        public ElementsPage(IWebDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(driver));
            }

            this.driver = driver;
        }

        //text box elements
        public IWebElement FullName => driver.FindElement(By.XPath("//input[@id='userName']"));
        public IWebElement Email => driver.FindElement(By.XPath("//input[@id='userEmail']"));
        public IWebElement CurrentAddress => driver.FindElement(By.XPath("//textarea[@id='currentAddress']"));
        public IWebElement PermanentAddress => driver.FindElement(By.XPath("//textarea[@id='permanentAddress']"));
        public IWebElement SubmitButton => driver.FindElement(By.XPath("//button[@id='submit']"));

        public void FillTextBoxForm(Table table)
        {
            var fullName = table.Rows[0]["Full Name"];
            var email = table.Rows[0]["Email"];
            var currentAddress = table.Rows[0]["Current Address"];
            var permanentAddress = table.Rows[0]["Permanent Address"];

 
            FullName.SendKeys(fullName);

            Email.SendKeys(email);

            CurrentAddress.SendKeys(currentAddress);
 
            PermanentAddress.SendKeys(permanentAddress);

        }

        /*public IList<IWebElement> TableRows => driver.FindElements(By.XPath("//table[@class='table']//tbody//tr"));*/

        public Table GetTableData()
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

            return table;
        }








    }
}

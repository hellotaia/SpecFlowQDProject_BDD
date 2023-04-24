using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowQDProject_BDD.PageObjects
{
    public class ElementsPage
    {

        private readonly IWebDriver driver;

        public ElementsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //text box elements
        private IWebElement FullName => driver.FindElement(By.XPath("//input[@id='userName']"));
        private IWebElement Email => driver.FindElement(By.XPath("//input[@id='userEmail']"));
        private IWebElement CurrentAddress => driver.FindElement(By.XPath("//textarea[@id='currentAddress']"));
        private IWebElement PermanentAddress => driver.FindElement(By.XPath("//textarea[@id='permanentAddress']"));
        private IWebElement SubmitButton => driver.FindElement(By.XPath("//button[@id='submit']"));

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

        public IList<IWebElement> TableRows => driver.FindElements(By.XPath("//table[@class='table']//tbody//tr"));
    }
}

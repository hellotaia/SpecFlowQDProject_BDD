using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowQDProject_BDD.PageObjects
{
    public class FormsPage:BasePage
    {
        public FormsPage(IWebDriver driver) : base(driver)
        {
        }
        //text fields elements
        public IWebElement FieldLocator(string fieldValue) => driver.FindElement(By.XPath($"//*[@placeholder='{fieldValue}']"));

        //gender radio button elements
        public IWebElement GenderLocator(string genderValue) => 
            driver.FindElement(By.XPath($"//input[@name='gender'][@value='{genderValue}']"));

        //dob field element
        public IWebElement DobField => driver.FindElement(By.XPath($"//input[@id='dateOfBirthInput']"));
        //subject field element
        public IWebElement SubjectField => driver.FindElement(By.XPath($"//input[@id='subjectsInput']"));
        //hobbies checkbox element
        public IWebElement HobbiesCheckbox(string hobbieValue) =>
            driver.FindElement(By.XPath($"//label[text()='{hobbieValue}']/preceding-sibling::input[@type='checkbox']"));
        //statecity element
        public IWebElement DropdownNameLocator(string dropdownName) =>
            driver.FindElement(By.XPath($"//div[text()='Select {dropdownName}']"));
        public IWebElement DropdownValueLocator (string dropdownValue) => 
            driver.FindElement(By.XPath($"//div[text()='{dropdownValue}']"));

        //submit modal elements
        public IWebElement ModalHeader(string header) => 
            driver.FindElement(By.XPath($"//div[@class='modal-header']/div[text()='{header}']"));
        private IList<IWebElement> TableRowsLocator => 
            driver.FindElements(By.XPath("//tbody/tr"));
        private IList<IWebElement> TableLabelLocator => 
            driver.FindElements(By.XPath("//tbody/tr/td[1]"));
        private IList<IWebElement> TableValuelLocator => 
            driver.FindElements(By.XPath("//tbody/tr/td[2]"));

        public FormsPage FillFormFields(Table tableData)
        {
            var firstName = tableData.Rows[0]["value"];
            var lastName = tableData.Rows[1]["value"];
            var email = tableData.Rows[2]["value"];
            var mobileNumber = tableData.Rows[3]["value"];
            var currentAddress = tableData.Rows[4]["value"];

            FieldLocator("First Name").SendKeys(firstName);
            FieldLocator("Last Name").SendKeys(lastName);
            FieldLocator("name@example.com").SendKeys(email);
            FieldLocator("Mobile Number").SendKeys(mobileNumber);
            FieldLocator("Current Address").SendKeys(currentAddress);

            return this;
        }

        public FormsPage SelectGender(string genderValue)
        {
            var button = GenderLocator(genderValue);
            var actions = new Actions(driver);
            actions.MoveToElement(button).Click().Perform();
            return this;
        }

        public FormsPage FillDOB(string dob)
        {
            DobField.Click();
            DobField.SendKeys(Keys.Control + "a");
            DobField.SendKeys(dob);
            DobField.SendKeys(Keys.Enter);
            return this;
        }

        public FormsPage FillSubject(string subjectValue)
        {
            var actions = new Actions(driver);
            actions.Click(SubjectField);
            SubjectField.SendKeys(subjectValue);
            actions.SendKeys(Keys.Enter).Perform();           
            return this;
        }

        public FormsPage SelectHobbies(string hobbiesValue) 
        {
            var actions = new Actions(driver);
            actions.MoveToElement(HobbiesCheckbox(hobbiesValue)).Perform();
            actions.Click(HobbiesCheckbox(hobbiesValue)).Perform();
            actions.Click();
            return this;
        }

        public FormsPage SelectStateCityDropdown (string dropdownValue, string dropdownName) 
        {
            var actions = new Actions(driver);
            DropdownNameLocator(dropdownName).Click();
            actions.SendKeys(dropdownValue);
            actions.MoveToElement(DropdownValueLocator(dropdownValue))
                .Click()
                .Perform();
            return this;
        }

        public FormsPage UploadPictureFile(string filePath)
        {
            IWebElement fileInput = driver.FindElement(By.Id("uploadPicture"));
            fileInput.SendKeys(filePath);
            return this;
        }

        public FormsPage CheckModalHeader (string header)
        {
            string actualTitle = ModalHeader(header).Text;
            Assert.AreEqual(header, actualTitle, "Titles are not equal");
            return this;
        }

        public FormsPage VerifyTableValues (Table expectedData)
        {
            var expectedTableRows = expectedData.Rows;
            for (int i = 0; i < expectedTableRows.Count; i++)
            {
                var expectedLabel = expectedTableRows[i]["Label"];
                var expectedValue = expectedTableRows[i]["Value"];

                Assert.AreEqual(expectedLabel, TableLabelLocator[i].Text, 
                    "Label at the table was incorrect");
                Assert.AreEqual(expectedValue, TableValuelLocator[i].Text, 
                    "Value at the table was incorrect");
            }
            return this;
        }
    }
}

using OpenQA.Selenium;
using SpecFlowQDProject_BDD.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowQDProject_BDD.StepDefinitions
{
    [Binding]
    public class FormsStepDefinitions
    {
        private IWebDriver _driver;
        private FormsPage _formsPage;

        public FormsStepDefinitions(IWebDriver driver)
        {
            _driver = driver;
            _formsPage = new FormsPage(_driver);
        }

        [When(@"User fills the text fields with the following values:")]
        public void WhenUserFillsTheTextFieldsWithTheFollowingValues(Table table)
        {
            _formsPage.FillFormFields(table);
        }


        [When(@"User selects '([^']*)' gender radiobutton")]
        public void WhenUserSelectsGenderRadiobutton(string genderValue)
        {
            _formsPage.SelectGender(genderValue);
        }

        [When(@"User fills '([^']*)' date of birth")]
        public void WhenUserFillsDateOfBirth(string dob)
        {
            _formsPage.FillDOB(dob);
        }

        [When(@"User fills '([^']*)' subject")]
        public void WhenUserFillsSubject(string subjectValue)
        {
            _formsPage.FillSubject(subjectValue);
        }

        [When(@"User selects '([^']*)' hobbie value")]
        public void WhenUserSelectsHobbieValue(string hobbieValue)
        {
            _formsPage.SelectHobbies(hobbieValue);
        }

        [When(@"User selects '([^']*)' in '([^']*)' dropdown")]
        public void WhenUserSelectsInDropdown(string dropdownValue, string dropdownName)
        {
            _formsPage.SelectStateCityDropdown(dropdownValue, dropdownName);
        }

        [When(@"User uploads picture file")]
        public void WhenUserUploadsPictureFile()
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "temp", "1.png");
            _formsPage.UploadPictureFile(filePath);
        }


        [Then(@"'([^']*)' modal is displayed")]
        public void ThenModalIsDisplayed(string header)
        {
            _formsPage.CheckModalHeader(header);
        }

        [Then(@"User verifies that following values are displayed in the modal")]
        public void ThenUserVerifiesThatFollowingValuesAreDisplayedInTheModal(Table table)
        {
            _formsPage.VerifyTableValues(table);
        }


    }
}

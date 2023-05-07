using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SpecFlowQDProject_BDD.PageObjects;
using System.Linq;



namespace SpecFlowQDProject_BDD.StepDefinitions
{
    [Binding]
    public class ElementsStepDefinitions
    {
        private IWebDriver _driver;
        private ElementsPage _elementsPage;

        public ElementsStepDefinitions(IWebDriver driver)
        {
            _driver = driver;
            _elementsPage = new ElementsPage(_driver);
        }


        [When(@"User fills the fields with the following values:")]
        public void WhenUserFillsTheFieldsWithTheFollowingValues(Table table)
        {
          _elementsPage.FillTextBoxForm(table);
        }


        [Then(@"the following table is in the response")]
        public void ThenTheFollowingTableIsInTheResponse(Table expectedData)
        {
            _elementsPage.VerifyDataAtTheTable(expectedData);
        }

        [When(@"User selects '([^']*)' folder")]
        public void WhenUserSelectsFolder(string folderName)
        {
            _elementsPage.ClickFolderName(folderName);
        }

        [When(@"User expands '([^']*)' folder")]
        public void WhenUserExpandsFolder(string folderName)
        {
            _elementsPage.ClickToggleName(folderName);
        }

        [Then(@"User verifies that '([^']*)' is displayed for selected results")]
        public void ThenUserVerifiesThatIsDisplayedForSelectedResults(string results)
        {
            _elementsPage.CheckSelectResults(results);
        }

    }
}
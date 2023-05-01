using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using SpecFlowQDProject_BDD.PageObjects;

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


        [Then(@"'([^']*)' page is displayed")]
        public void ThenPageIsDisplayed(string pageName)
        {
            _elementsPage.VerifyPageTitle(pageName);

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

        [When(@"User clicks '([^']*)' menu button")]
        public void WhenUserClicksMenuButton(string menuButton)
        {
            _elementsPage.ClickOnMenuButton(menuButton);
        }
        [When(@"User clicks '([^']*)' button")]
        public void WhenUserClicksButton(string button)
        {
            _elementsPage.ClickButton(button);
        }
    }
}

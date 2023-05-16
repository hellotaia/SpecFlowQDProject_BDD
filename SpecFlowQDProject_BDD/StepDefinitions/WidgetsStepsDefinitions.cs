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
    public class WidgetsStepsDefinitions
    {
        private IWebDriver _driver;
        private WidgetsPage _widgetsPage;

        public WidgetsStepsDefinitions(IWebDriver driver)
        {
            _driver = driver;
            _widgetsPage = new WidgetsPage(_driver);
        }

        [When(@"User fills '([^']*)' into '([^']*)' field")]
        public void WhenUserFillsIntoField(string value, string field)
        {
            _widgetsPage.FillsFieldValue(value, field);
        }

        [Then(@"User verifies that '([^']*)' suggestion options are displayed")]
        public void ThenUserVerifiesThatSuggestionOptionsAreDisplayed(int x)
        {
            _widgetsPage.SuggestionsCount(x);
        }

        [Then(@"User verifies that each suggestion contains '([^']*)'")]
        public void ThenUserVerifiesThatEachSuggestionContains(string value)
        {
            _widgetsPage.IsSuggestionsContains(value);
        }

        [When(@"User adds '([^']*)' into '([^']*)' field")]
        public void WhenUserAddsIntoField(string colorValue, string field)
        {
            _widgetsPage.AddColorName(colorValue,field);
        }

        [When(@"User deletes '([^']*)' item")]
        [Then(@"User deletes '([^']*)' item")]
        public void ThenUserDeletesItem(string colorValue)
        {
            _widgetsPage.DeleteColorName(colorValue);
        }

        [Then(@"User verifies that '([^']*)' item is displayed")]
        public void ThenUserVerifiesThatItemIsDisplayed(string color)
        {
            _widgetsPage.IsColorDisplayed(color);
        }

        //progress bar
        [Then(@"User verifies that '([^']*)' button name is displayed")]
        public void ThenUserVerifiesThatButtonNameIsDisplayed(string buttonName)
        {
            _widgetsPage.VerifyButtonName(buttonName);
        }

        [When(@"User waits until the Progress Bar value reaches '([^']*)'")]
        [Then(@"User waits until the Progress Bar value reaches '([^']*)'")]
        public void ThenUserWaitsUntilTheProgressBarValueReaches(string value)
        {
            _widgetsPage.ProgressBarWaiter(value);
        }

        [Then(@"Progress Bar value is '([^']*)'")]
        public void ThenProgressBarValueIs(string value)
        {
            _widgetsPage.VerifyProgressBarValue(value);
        }


    }
}

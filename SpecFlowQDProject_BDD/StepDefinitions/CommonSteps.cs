using NuGet.Frameworks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowQDProject_BDD.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowQDProject_BDD.StepDefinitions
{
    [Binding]
    public class CommonSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;

        public CommonSteps (IWebDriver driver)
        {
            _driver = driver;
            _homePage = new HomePage (_driver);
        }
        

        [Given(@"User navigates to '([^']*)'")]
        public void GivenUserNavigatesTo(string pageUrl)
        {
            _homePage.NavigateToPage(pageUrl);
        }

        [Given(@"User choose '([^']*)' category")]
        public void WhenUserChooseCategory(string category)
        {
            _homePage.ClickOnCategory(category);
        }

        [When(@"User clicks '([^']*)' menu button")]
        public void WhenUserClicksMenuButton(string menuButton)
        {
            _homePage.ClickOnMenuButton(menuButton);
        }
        [When(@"User clicks '([^']*)' button")]
        public void WhenUserClicksButton(string menuButton)
        {
            _homePage.ClickButton(menuButton);
        }

        [Then(@"'([^']*)' page is displayed")]
        public void ThenPageIsDisplayed(string pageName)
        {
            _homePage.VerifyPageTitle(pageName);
        }

    }
}

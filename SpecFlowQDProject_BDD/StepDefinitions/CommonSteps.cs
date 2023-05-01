using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowQDProject_BDD.PageObjects;

namespace SpecFlowQDProject_BDD.StepDefinitions
{
    [Binding]
    public class CommonSteps
    {

        private readonly IWebDriver _driver;
       
        private readonly HomePage _homePage;

        public CommonSteps(IWebDriver driver) 
        {
            _driver = driver;
            _homePage = new HomePage(_driver);
        }

        [Given(@"User navigates to '([^']*)'")]
        public void GivenUserNavigatesTo(string pageUrl)
        {
            _homePage.NavigateToPage(pageUrl);
            
        }

        [Given(@"User choose '([^']*)' category")]
        [When(@"User choose '([^']*)' category")]
        public void WhenUserChooseCategory(string category)
        {
            _homePage.ClickOnCategory(category);
        }

    }
}

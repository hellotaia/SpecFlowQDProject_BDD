using NuGet.Frameworks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowQDProject_BDD.StepDefinitions
{
    [Binding]
    internal class CommonSteps
    {

        private IWebDriver driver;
        private string homePage = "https://demoqa.com/";



        [Given(@"User navigates to '([^']*)'")]
        public void GivenUserNavigatesTo(string url)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
        }

        [When(@"User choose '([^']*)' category")]
        public void WhenUserChooseCategory(string category)
        {
            IWebElement categoryChoosen = driver.FindElement(By.XPath($"//div/h5[text()='{category}']"));
            categoryChoosen.Click();
        }

        [When(@"User clicks '([^']*)' menu button")]
        public void WhenUserClicksMenuButton(string menuButton)
        {
            IWebElement menuClick = driver.FindElement(By.XPath($"//span[text()='{menuButton}']"));
            menuClick.Click();
        }
        [When(@"User clicks '([^']*)' button")]
        public void WhenUserClicksButton(string button)
        {
            IWebElement buttonToClick = driver.FindElement(By.XPath($"//button[text()='{button}']"));
            buttonToClick.Click();
        }

        [Then(@"'([^']*)' page is displayed")]
        public void ThenPageIsDisplayed(string page)
        {
            string expectedTitle = page;
            string actualTitle = driver.FindElement(By.XPath($"//div[@class='main-header']")).Text;
            Assert.AreEqual(actualTitle,expectedTitle,"Titles are not equal");
        }
    }
}

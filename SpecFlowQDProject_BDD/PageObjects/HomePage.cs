using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace SpecFlowQDProject_BDD.PageObjects
{
    public class HomePage : BasePage
    {
       public HomePage(IWebDriver driver) : base(driver)
        {
        }
        private IWebElement CategoryNameLocator(string category) => driver.FindElement(By.XPath($"//div/h5[text()='{category}']"));
        private IWebElement PageTitleLocator => driver.FindElement(By.XPath($"//div[@class='main-header']"));
        private IWebElement MenuButtonLocator(string buttonName) => driver.FindElement(By.XPath($"//span[text()='{buttonName}']"));
        private IWebElement ButtonByNameLocator(string buttonName) => driver.FindElement(By.XPath($"//button[text()='{buttonName}']"));

        public HomePage NavigateToPage (string pageUrl)
        {
            driver.Navigate().GoToUrl(pageUrl); 
            return this;
        }

        public HomePage ClickOnCategory(string categoryName)
        {
            CategoryNameLocator(categoryName).Click();
            return this;
        }
        public HomePage VerifyPageTitle(string expectedPageName)
        {
            string actualTitle = PageTitleLocator.Text;
            Assert.AreEqual(expectedPageName, actualTitle, "Titles are not equal");
            return this;
        }

        public HomePage ClickOnMenuButton(string menuButtonName)
        {
            MenuButtonLocator(menuButtonName).Click();
            return this;
        }

        public HomePage ClickButton(string buttonName)
        {
            ButtonByNameLocator(buttonName).Click();
            return this;
        }

        public HomePage PressButton(string keyButton) 
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(keyButton).Perform();
            return this;
        }
       
    }
}

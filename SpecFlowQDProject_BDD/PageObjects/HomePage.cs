using NUnit.Framework;
using OpenQA.Selenium;

namespace SpecFlowQDProject_BDD.PageObjects
{
    public class HomePage : BasePage
    {

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement CategoryNameLocator(string category) => driver.FindElement(By.XPath($"//div/h5[text()='{category}']"));

        public HomePage NavigateToPage(string pageUrl)
        {
            driver.Navigate().GoToUrl(pageUrl);
            return this;
        }

        public HomePage ClickOnCategory(string categoryName)
        {
            CategoryNameLocator(categoryName).Click();
            return this;
        }

    }
}

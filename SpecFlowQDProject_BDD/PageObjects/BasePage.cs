using OpenQA.Selenium;

namespace SpecFlowQDProject_BDD.PageObjects
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}

using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowQDProject_BDD.PageObjects
{
    [Binding]
    public class Hooks
    {
        protected IWebDriver driver;
        private readonly IObjectContainer container;

        public Hooks(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario]
        public void GetDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            container.RegisterInstanceAs(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            IWebDriver driver = container.Resolve<IWebDriver>();
            driver.Quit();
        }
    }
}

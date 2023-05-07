using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;
using SpecFlow;
using OpenQA.Selenium.Edge;
using BoDi;

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
            container.RegisterInstanceAs(driver);
        }

        /*[AfterScenario]
        public void AfterScenario()
        {
            IWebDriver driver = container.Resolve<IWebDriver>();
            driver.Quit();
        }*/
    }
}

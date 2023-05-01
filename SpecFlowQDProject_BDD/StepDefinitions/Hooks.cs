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

namespace SpecFlowQDProject_BDD.StepDefinitions
{
    public class Hooks
    {
        private IWebDriver _driver;
        public Hooks()
        {
            this._driver = new ChromeDriver();

        }

        public IWebDriver Driver => _driver;

/*        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
        }
*/
        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
        }

        public IWebDriver GetDriver()
        {
            return Driver;
        }
    }
}

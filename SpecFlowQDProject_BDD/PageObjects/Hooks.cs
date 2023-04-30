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
using OpenQA.Selenium.Chrome;

namespace SpecFlowQDProject_BDD.PageObjects
{
    public class Hooks
    {
        private IWebDriver driver;
        public Hooks(IWebDriver driver)
        {
            this.driver = driver;
            driver = new ChromeDriver();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowQDProject_BDD.PageObjects
{
    public class AlertsPage : BasePage
    {
        public AlertsPage(IWebDriver driver) : base(driver)
        {
        }

        public void SwitchToNewWindow()
        {
            var mainWindow = driver.CurrentWindowHandle;
            var windows = driver.WindowHandles;

            foreach (var window in windows)
            {
                if (window != mainWindow)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }
        }

        public AlertsPage IsTextPresent(string text)
        {
            Assert.AreEqual(text, "This is a sample page");
            return this;
        }
    }

}
  

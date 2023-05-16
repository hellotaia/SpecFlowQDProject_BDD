using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowQDProject_BDD.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SpecFlowQDProject_BDD.StepDefinitions
{
    [Binding]
    public class AlertsStepDefinitions
    {
        private IWebDriver _driver;
        private AlertsPage _alertsPage;

        public AlertsStepDefinitions(IWebDriver driver)
        {
            _driver = driver;
            _alertsPage = new AlertsPage(_driver);
        }
        //new tab
        [When(@"User switches focus to the new tab")]
        public void WhenUserSwitchesFocusToTheNewTab()
        {
            _alertsPage.SwitchToNewWindow();
            
        }

        [Then(@"'([^']*)' text is displayed on the new tab")]
        public void ThenTextIsDisplayedOnTheNewTab(string text)
        {
            _alertsPage.IsTextPresent(text);
        }

        //new window 
        [When(@"User switches focus to the new window")]
        public void WhenUserSwitchesFocusToTheNewWindow()
        {
            _alertsPage.SwitchToNewWindow();
        }

        [Then(@"'([^']*)' is displayed on the new window")]
        public void ThenIsDisplayedOnTheNewWindow(string text)
        {
            _alertsPage.IsTextPresent(text);
        }

    }
}

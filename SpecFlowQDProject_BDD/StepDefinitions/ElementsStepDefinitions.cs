using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SpecFlowQDProject_BDD.PageObjects;
using System.Linq;



namespace SpecFlowQDProject_BDD.StepDefinitions
{
    [Binding]
    public class ElementsStepDefinitions
    {

        private ElementsPage elementsPage;

        public ElementsStepDefinitions(Hooks hooks)
        {

            elementsPage = new ElementsPage(hooks.Driver);
        }


        [When(@"User fills the fields with the following values:")]
        public void WhenUserFillsTheFieldsWithTheFollowingValues(Table table)
        {
            elementsPage.FillTextBoxForm(table);
        }


        [Then(@"the following table is in the response")]
        public void ThenTheFollowingTableIsInTheResponse(Table expectedTable)
        {

            Table actualTable = elementsPage.GetTableData();
            Assert.AreEqual(expectedTable, actualTable, "The actual table data does not match the expected table data.");
        }
    }
}
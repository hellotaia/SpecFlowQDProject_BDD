using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using SpecFlowQDProject_BDD.PageObjects;

namespace SpecFlowQDProject_BDD.StepDefinitions
{
    [Binding]
    public class ElementsStepDefinitions
    {
        IWebDriver driver;
        private readonly ElementsPage elementsPage;


        [When(@"User fills the fields with the following values:")]
        public void WhenUserFillsTheFieldsWithTheFollowingValues(Table table)
        {
            elementsPage.FillTextBoxForm(table);
        }


        [Then(@"the following table is in the response")]
        public void ThenTheFollowingTableIsInTheResponse(Table table)
        {
            var expectedTableRows = table.Rows;
            var actualTableRows = elementsPage.TableRows;

            Assert.AreEqual(expectedTableRows.Count, actualTableRows.Count);

            for (int i = 0; i < expectedTableRows.Count; i++)
            {
                var expectedRow = expectedTableRows[i];
                var actualRowCells = actualTableRows[i].FindElements(By.TagName("td"));

                Assert.AreEqual(expectedRow["FullName"], actualRowCells[0].Text);
                Assert.AreEqual(expectedRow["Email"], actualRowCells[1].Text);
                Assert.AreEqual(expectedRow["Current Address"], actualRowCells[2].Text);
                Assert.AreEqual(expectedRow["Permanent Address"], actualRowCells[3].Text);
            }
        }
    }
}

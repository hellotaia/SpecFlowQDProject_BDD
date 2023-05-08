using OpenQA.Selenium;
using SpecFlowQDProject_BDD.PageObjects;



namespace SpecFlowQDProject_BDD.StepDefinitions
{
    [Binding]
    public class ElementsStepDefinitions
    {
        private IWebDriver _driver;
        private ElementsPage _elementsPage;

        public ElementsStepDefinitions(IWebDriver driver)
        {
            _driver = driver;
            _elementsPage = new ElementsPage(_driver);
        }

        //text box page
        [When(@"User fills the fields with the following values:")]
        public void WhenUserFillsTheFieldsWithTheFollowingValues(Table table)
        {
          _elementsPage.FillTextBoxForm(table);
        }

        //text box page
        [Then(@"the following table is in the response")]
        public void ThenTheFollowingTableIsInTheResponse(Table expectedData)
        {
            _elementsPage.VerifyDataAtTheTable(expectedData);

        }

        // check box page
        [When(@"User selects '([^']*)' folder")]
        public void WhenUserSelectsFolder(string folderName)
        {
            _elementsPage.ClickFolderName(folderName);
        }

        // check box page
        [When(@"User expands '([^']*)' folder")]
        public void WhenUserExpandsFolder(string folderName)
        {
            _elementsPage.ClickToggleName(folderName);
        }

        // check box page
        [Then(@"User verifies that '([^']*)' is displayed for selected results")]
        public void ThenUserVerifiesThatIsDisplayedForSelectedResults(string results)
        {
            _elementsPage.CheckSelectResults(results);
        }

        // web tables page
        [When(@"User clicks '([^']*)' column header")]
        public void WhenUserClicksColumnHeader(string columnName)
        {
            _elementsPage.SortColumnAsc(columnName);
        }

        // web tables page
        [Then(@"User verifies that '([^']*)' coulumn values are sorted in ascending order")]
        public void ThenUserVerifiesThatCoulumnValuesAreSortedInAscendingOrder(string columnName)
        {
            _elementsPage.IsColumnSortedAsc(columnName);
        }


    }
}
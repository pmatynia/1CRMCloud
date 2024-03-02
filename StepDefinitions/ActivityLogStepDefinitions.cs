using CRMCloud.Drivers;
using CRMCloud.PageObjects;
using NUnit.Framework;

namespace CRMCloud.StepDefinitions
{
    [Binding]
    public class ActivityLogStepDefinitions
    {
        private readonly ActivityLogPage _activityLogPage;
        private readonly ScenarioContext _scenarioContext;

        public ActivityLogStepDefinitions(BrowserDriver browserDriver, ScenarioContext scenarioContext)
        {
            _activityLogPage = new ActivityLogPage(browserDriver.Current);
            _scenarioContext = scenarioContext;
            
        }

        [When(@"the user deletes first '([^']*)' items in the table")]
        public void WhenTheUserDeletesFirstItemsInTheTable(int numberOfItems)
        { 
            _scenarioContext.Set(_activityLogPage.GetActivityItems(numberOfItems), "ItemsToDelete");
            _activityLogPage.DeleteActivityItems(numberOfItems);
        }

        [Then(@"items should be deleted")]
        public void ThenItemsShouldBeDeleted()
        {
            var actualItemsOnPage = _activityLogPage.GetAllActivityItemsOnPage();
            var deletedItems = _scenarioContext.Get<List<string>>("ItemsToDelete");

            Assert.That(actualItemsOnPage.All(deletedItems.Contains), Is.False);
        }
    }
}

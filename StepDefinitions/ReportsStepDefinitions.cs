using CRMCloud.Drivers;
using CRMCloud.PageObjects;

namespace CRMCloud.StepDefinitions
{
    [Binding]
    public class ReportsStepDefinitions
    {
        private readonly ReportsPage _reportsPage;

        public ReportsStepDefinitions(BrowserDriver browserDriver)
        {
            _reportsPage = new ReportsPage(browserDriver.Current);
        }

        [When(@"the user runs a '([^']*)' report")]
        public void WhenTheUserRunsAReport(string report)
        {
            _reportsPage.RunReport(report);
        }

        [Then(@"some results are returned")]
        public void ThenSomeResultsAreReturned()
        {
            _reportsPage.GetNumberOfResults().Should().BeGreaterThan(0);
        }
    }
}

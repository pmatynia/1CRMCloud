using CRMCloud.Utils;
using OpenQA.Selenium;

namespace CRMCloud.PageObjects
{
    public class ReportsPage
    {
        private readonly IWebDriver _webDriver;

        public ReportsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        private IWebElement SearchFilterTxtBox => _webDriver.FindElement(By.Id("filter_text"));
        private IWebElement Results(string report) => _webDriver.FindElement(By.XPath($"//a[text()='{report}']"));
        private IWebElement RunReportBtn => _webDriver.FindElement(By.XPath("(//button[contains(.,'Run Report')])"));
        private ICollection<IWebElement> ResultListView => _webDriver.FindElements(By.XPath("//tbody/tr[contains(@class,'listViewRow')]"));

        public void RunReport(string report)
        {
            SearchFilterTxtBox.Clear();
            SearchFilterTxtBox.SendKeys(report + Keys.Enter);
            Results(report).Click();
            Helper.WaitForPageToBeLoaded();
            RunReportBtn.Click();
        }

        public int GetNumberOfResults()
        {
            return ResultListView.Count;
        }
    }
}

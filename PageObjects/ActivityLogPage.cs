using CRMCloud.Utils;
using OpenQA.Selenium;

namespace CRMCloud.PageObjects
{
    public class ActivityLogPage
    {
        private readonly IWebDriver _webDriver;

        public ActivityLogPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        private IEnumerable<IWebElement> ActivityItemsCheckbox => _webDriver.FindElements(By.XPath("//tbody/tr[contains(@class,'listViewRow')]//input"));
        private IEnumerable<IWebElement> ActivityItems => _webDriver.FindElements(By.XPath("(//tr[contains(@class,'listViewRow')])//span[@class='detailLink']//a"));
        private IWebElement ActivityItem(int index = 1) => _webDriver.FindElement(By.XPath($"(((//tr[contains(@class,'listViewRow')])//span[@class='detailLink']//a)[{index}])[1]"));
        private IWebElement ActionsDropdown => _webDriver.FindElement(By.CssSelector(".listview-actions"));
        private IWebElement DeleteBtn => _webDriver.FindElement(By.XPath("//div[text()='Delete']"));

        public void DeleteActivityItems(int numberOfItems)
        {
            for (var i = 0; i < numberOfItems; i++)
            {
                ActivityItemsCheckbox.ElementAt(i).Click();
            }

            ActionsDropdown.Click();
            DeleteBtn.Click();
            AlertAccept();
            Helper.WaitForPageToBeLoaded();
        }

        public void AlertAccept()
        {
            _webDriver.SwitchTo().Alert().Accept();
        }

        public List<string> GetActivityItems(int numberOfItems)
        {
            var listOfItems = new List<string>();
            for (var i = 1; i <= numberOfItems; i++)
            {
                listOfItems.Add(ActivityItem(i).Text);
            }
            return listOfItems;
        }

        public List<string> GetAllActivityItemsOnPage()
        {
            var listOfItems = new List<string>();
            for (var i = 1; i <= ActivityItems.Count(); i++)
            {
                listOfItems.Add(ActivityItem(i).Text);
            }
            return listOfItems;
        }
    }
}

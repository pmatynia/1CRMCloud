using CRMCloud.Utils;
using OpenQA.Selenium;

namespace CRMCloud.PageObjects
{
    public class MenuHeader
    {
        private readonly IWebDriver _webDriver;

        public MenuHeader(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        private IWebElement MenuOptionLink(string option) => _webDriver.FindElement(By.XPath($"//a[contains(.,'{option}')]"));

        public void NavigateToSubMenu(string submenu)
        {
            switch (submenu)
            {
                case "Activity Log":
                case "Reports":
                    MenuOptionLink("Reports & Settings").Click();
                    break;
                case "Create Contact":
                    MenuOptionLink("Sales & Marketing").Click();
                    break;
                default:
                    throw new Exception("Submenu not exists or not supported.");
            }
            
            MenuOptionLink(submenu).Click();

            Helper.WaitForPageToBeLoaded();
        }
    }
}

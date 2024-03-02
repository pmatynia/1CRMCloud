using OpenQA.Selenium;
using CRMCloud.Models;
using CRMCloud.Utils;

namespace CRMCloud.PageObjects
{
    public class ContactsPage
    {
        private readonly IWebDriver _webDriver;

        public ContactsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        private IWebElement FirstNameTxtBox => _webDriver.FindElement(By.XPath("//input[@name='first_name']"));
        private IWebElement LastNameTxtBox => _webDriver.FindElement(By.XPath("//input[@name='last_name']"));
        private IWebElement BusinessRoleDropdown => _webDriver.FindElement(By.Id("DetailFormbusiness_role-input-label"));
        private IWebElement OptionDropdown(string option) => _webDriver.FindElement(By.XPath($"//div[text()='{option}']"));
        private IWebElement CategoryDropdown => _webDriver.FindElement(By.Id("DetailFormcategories-input"));
        private IWebElement SaveBtn => _webDriver.FindElement(By.Id("DetailForm_save2"));
        private IWebElement HeaderLbl => _webDriver.FindElement(By.XPath("(//h3)[2]"));
        private IWebElement CategoryLbl => _webDriver.FindElement(By.XPath("//li[contains(.,'Category')]"));
        private IWebElement BusinessRoleLbl => _webDriver.FindElement(By.XPath("//p[text()='Business Role']//following-sibling::div"));
        private IWebElement DeleteBtn => _webDriver.FindElement(By.XPath("(//button[contains(.,'Delete')])"));

        public void CreateContact(CreateContact contact)
        {
            FirstNameTxtBox.SendKeys(contact.FirstName);
            LastNameTxtBox.SendKeys(contact.LastName);

            foreach (var category in contact.Category)
            {
                CategoryDropdown.Click();
                OptionDropdown(category).Click();
                Thread.Sleep(1000);
            }

            BusinessRoleDropdown.Click();
            OptionDropdown(contact.BusinessRole).Click();
            SaveBtn.Click();
            Helper.WaitForPageToBeLoaded();
        }

        public void DeleteContact()
        {
            DeleteBtn.Click();
            _webDriver.SwitchTo().Alert().Accept();
            Helper.WaitForPageToBeLoaded();
        }

        public string GetContactHeaderText()
        {
            return HeaderLbl.Text;
        }

        public string GetCategoryText()
        {
            return CategoryLbl.Text;
        }

        public string GetBusinessRoleText()
        {
            return BusinessRoleLbl.Text;
        }
    }
}

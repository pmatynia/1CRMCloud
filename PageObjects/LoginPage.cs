using OpenQA.Selenium;
using CRMCloud.Models;
using CRMCloud.Utils;

namespace CRMCloud.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver _webDriver;

        public LoginPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        private IWebElement UserNameTxtBox => _webDriver.FindElement(By.Id("login_user"));
        private IWebElement PasswordTxtBox => _webDriver.FindElement(By.Id("login_pass"));
        private IWebElement LoginBtn => _webDriver.FindElement(By.Id("login_button"));

        public void Login(LoginUser user)
        {
            UserNameTxtBox.SendKeys(user.UserName);
            PasswordTxtBox.SendKeys(user.Password);
            LoginBtn.Click();
        }

        public void OpenLoginPage()
        {
            _webDriver.Navigate().GoToUrl(Config.LoginUrl);
        }
    }
}

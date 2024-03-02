using TechTalk.SpecFlow.Assist;
using CRMCloud.Drivers;
using CRMCloud.Models;
using CRMCloud.PageObjects;

namespace CRMCloud.StepDefinitions
{
    [Binding]
    public class CommonStepDefinitions
    {
        private readonly LoginPage _loginPage;
        private readonly MenuHeader _menuHeader;

        public CommonStepDefinitions(BrowserDriver browserDriver)
        {
            _loginPage = new LoginPage(browserDriver.Current);
            _menuHeader = new MenuHeader(browserDriver.Current);
        }

        [Given(@"the user login with following data")]
        public void GivenTheUserLoginWithFollowingData(Table table)
        {
            var loginUser = table.CreateInstance<LoginUser>();
            _loginPage.OpenLoginPage();
            _loginPage.Login(loginUser);
        }

        [Given(@"the user is on the '([^']*)' page")]
        public void GivenTheUserIsOnPage(string submenu)
        {
            _menuHeader.NavigateToSubMenu(submenu);
        }
    }
}

using CRMCloud.Drivers;
using CRMCloud.Models;
using CRMCloud.PageObjects;
using TechTalk.SpecFlow.Assist;

namespace CRMCloud.StepDefinitions
{
    [Binding]
    public class ContactsStepDefinitions
    {
        private readonly ContactsPage _contactPage;
        private readonly ScenarioContext _scenarioContext;

        public ContactsStepDefinitions(BrowserDriver browserDriver, ScenarioContext scenarioContext)
        {
            _contactPage = new ContactsPage(browserDriver.Current);
            _scenarioContext = scenarioContext;
        }

        [When(@"the user adds new contact with following data")]
        public void WhenTheUserAddsNewContactWithFollowingData(Table table)
        {
            var contact = table.CreateInstance<CreateContact>();
            _scenarioContext.Set(contact);
            _contactPage.CreateContact(contact);
        }

        [Then(@"contact is created with all data matching")]
        public void ThenContactIsCreatedWithAllDataMatching()
        {
            var contact = _scenarioContext.Get<CreateContact>();

            _contactPage.GetContactHeaderText().Should().Contain($"{contact.FirstName} {contact.LastName}");

            foreach (var category in contact.Category)
            {
                _contactPage.GetCategoryText().Should().Contain(category);
            }

            _contactPage.GetBusinessRoleText().Should().Be(contact.BusinessRole);
        }

        [AfterScenario("CreateContact")]
        public void DeleteContact()
        {
            _contactPage.DeleteContact();
        }
    }
}

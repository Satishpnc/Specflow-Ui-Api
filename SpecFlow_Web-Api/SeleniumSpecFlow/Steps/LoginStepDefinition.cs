using NUnit.Framework;
using SeleniumSpecFlow.Utilities;
using TechTalk.SpecFlow;
using TestLibrary.Utilities;
using WebLibrary.Pages;

namespace SeleniumSpecFlow.Steps
{
    [Binding]
    public class LoginStepDefinition : ObjectFactory
    {
        private readonly LoginPage _loginPage;
        private readonly ChallengePage _challengePage;
        private readonly string _userName = Util.RandomString();

        public LoginStepDefinition(LoginPage loginPage,
            ChallengePage challengePage)
        {
            _loginPage = loginPage;
            _challengePage = challengePage;
        }

        [Given(@"I enter to Responsive Fight of Covid19 application")]
        public void GivenIEnterToResponsiveFightOfCovidApplication()
        {
            //
        }

        [Given(@"I login to to Responsive Fight of Covid19 application")]
        [When(@"I create a warrior name with random name")]
        public void WhenUserCreateWarriorName()
            => _loginPage.CreateWarrior(_userName);

        [Then(@"I should see the new user has been created")]
        public void ThenTheUserHasBeenCreated()
            => Assert.AreEqual(_userName, _challengePage.GetUserName());

        [Then(@"I should see the dashboard of Responsive Fight of Covid19")]
        public void ThenTheDashboardIsDisplayed()
            => Assert.AreEqual("COVID-19 THE GAME", _challengePage.GetPageTitle());
    }
}

using NUnit.Framework;
using TechTalk.SpecFlow;
using SeleniumSpecFlow.Utilities;
using WebLibrary.Pages;
using static WebLibrary.Pages.ChallengePage;

namespace SeleniumSpecFlow.Steps
{
    [Binding]
    public sealed class ChallengeStepDefinition
    {
        private readonly ChallengePage _challengePage;
        private readonly LeaderBoardPage _leaderBoardPage;
        private readonly ModalDialog _modalDialog;

        public ChallengeStepDefinition(ChallengePage challengePage,
            LeaderBoardPage leaderBoardPage,
            ModalDialog modalDialog)
        {
            _challengePage = challengePage;
            _leaderBoardPage = leaderBoardPage;
            _modalDialog = modalDialog;
        }

        [When(@"the user start the challenge '(.*)'")]
        public void WhenTheUserStartTheChallenge(string challengeName)
        {
            _challengePage.SelectChallenge(challengeName).Start();
        }

        [When(@"the user choose the correct answer")]
        public void WhenTheUserChooseTheCorrectAnswer()
        {
            _challengePage.SelectAnswerForBus(1);
        }


        [Then(@"the score '(.*)' is displayed")]
        public void ThenTheScoreIsDisplayed(string score)
        {
            Assert.AreEqual(score, _modalDialog.GetScore());
        }

        [When(@"the user check the final score")]
        public void WhenTheUserCheckTheFinalScore()
        {
            _modalDialog.CheckScore();
        }

        [Then(@"the final score '(.*)' is displayed")]
        public void ThenTheFinalScoreIsDisplayed(string score)
        {
            Assert.AreEqual(score, _leaderBoardPage.GetFinalScore(score));
        }

        [When(@"the user choose the incorrect answer")]
        public void WhenTheUserChooseTheIncorrectAnswer()
        {
            _challengePage.SelectAnswerForBus(2);
        }

        [Then(@"the next challenge is displayed")]
        public void ThenTheNextChallengeIsDisplayed()
        {
            Assert.IsTrue(_modalDialog.NextChallengeIsDisplayed());
        }

        [When(@"the challenge timeout")]
        public void WhenTheChallengeTimeout()
            => _challengePage.WaitforTimeout(10000);  

        [Then(@"the covid poster is displayed")]
        public void ThenTheCovidPosterIsDisplayed()
        {
            Assert.IsTrue(_modalDialog.CovidPosterIsDisplayed());
        }

        [Then(@"the try again option is displayed")]
        public void ThenTheTryAgainOptionIsDisplayed()
        {
            Assert.IsTrue(_challengePage.TryAgainIsDisplayed());
        }
    }
}

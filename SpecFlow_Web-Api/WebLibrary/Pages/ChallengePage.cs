using OpenQA.Selenium;
using System;
using System.Threading;

namespace WebLibrary.Pages
{
    public partial class ChallengePage : PageBase
    {
        public ChallengePage(IWebDriver webDriver) : base(webDriver)
        {
        }

        private IWebElement UsernameField
            => Driver.FindElement(By.Id("welcome_text"));

        private IWebElement PageTitle
            => Driver.FindElement(By.XPath("//p[@class='alpha-heading']"));

        private IWebElement ChallengeNameButton(string challengeName)
            => Driver.FindElement(By.XPath($"//a[normalize-space()='" + challengeName + "']"));

        private IWebElement SelectedOption(int option)
            => Driver.FindElement(By.Id("bus_answer_" + option));

        public string GetPageTitle()
        {
            return PageTitle.Text;
        }

        public string GetUserName()
        {
            string text = UsernameField.Text;
            string[] texts = text.Split(' ');
            return texts[texts.Length - 1];
        }

        public ModalDialog SelectChallenge(string challengeName)
        {
            ChallengeNameButton(challengeName).Click();

            return new ModalDialog(Driver);
        }

        public void SelectAnswerForBus(int option)
            => SelectedOption(option).Click();

        internal string GetScore()
        {
            var dialog = new ModalDialog(Driver);
            var score = dialog.GetScore();
            return score;
        }

        internal void CheckScore()
        {
            var dialog = new ModalDialog(Driver);
            dialog.CheckScore();
        }

        public bool? TryAgainIsDisplayed()
        {
            var dialog = new ModalDialog(Driver);
            return dialog.TryAgainIsDisplayed();
        }

        internal bool? TryNextChallengeIsDisplayed()
        {
            var dialog = new ModalDialog(Driver);
            return dialog.NextChallengeIsDisplayed();
        }

        public void WaitforTimeout(int seconds)
        {
            Thread.Sleep(seconds);
        }

        internal bool? CovidPosterIsDisplayed()
        {
            var dialog = new ModalDialog(Driver);
            return dialog.CovidPosterIsDisplayed();
        }

        protected override bool EvaluateLoadedStatus()
        {
            try
            {
                WaitForElement(PageTitle);
                return true;
            }
            catch
            {
                throw new Exception("Challenge page not load");
            }
        }
    }
}

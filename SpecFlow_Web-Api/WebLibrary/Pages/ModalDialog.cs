using OpenQA.Selenium;
using System;

namespace WebLibrary.Pages
{
    public partial class ChallengePage
    {
        public class ModalDialog : PageBase
        {
            private IWebElement Dialog 
                => Driver.FindElement(By.ClassName("modal-dialog"));
            private IWebElement TryAgainButton 
                => Driver.FindElement(By.XPath("//button[text()='Try again']"));
            private IWebElement TryNexChallengetButton 
                => Driver.FindElement(By.XPath("//button[text()='Try the next battle']"));
            private IWebElement Score 
                => Driver.FindElement(By.XPath("//p[@id='score']"));
            private IWebElement CheckScoreButton 
                => Driver.FindElement(By.Id("leaderboard_link"));
            private IWebElement CovidPoster 
                => Driver.FindElement(By.Id("img-protection_poster"));

            private IWebElement StartButton
                => Driver.FindElement(By.XPath("//button[text()='Start']"));

            public ModalDialog(IWebDriver driver) : base(driver)
            {
                
            }
            public void Start()
            => StartButton.Click();

            public string GetScore()
            {
                WaitForElement(Score);

                string text = Score.Text;
                string[] texts = text.Split(' ');
                string score = texts[4].Trim();

                return score;
            }

            public bool? TryAgainIsDisplayed()
            {
                WaitForElement(TryAgainButton);

                return TryAgainButton.Displayed;
            }

            public bool? NextChallengeIsDisplayed()
            {
                WaitForElement(TryNexChallengetButton);


                return TryNexChallengetButton.Displayed;
            }

            public bool? CovidPosterIsDisplayed()
            {
                WaitForElement(CovidPoster);
                return CovidPoster.Displayed;
            }

            public void CheckScore()
            {
                CheckScoreButton.Click();
            }

            protected override bool EvaluateLoadedStatus()
            {
                try
                {
                    WaitForElement(Dialog);
                    return true;
                }
                catch
                {
                    throw new Exception("Modal Dialog not load");
                }
            }
        }
    }
}

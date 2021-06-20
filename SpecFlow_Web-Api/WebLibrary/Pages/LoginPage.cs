using OpenQA.Selenium;
using System;

namespace WebLibrary.Pages
{
    public class LoginPage : PageBase
    {
        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {
        }
        private IWebElement UserNameInputField 
            => Driver.FindElement(By.XPath("//input[@id='worrior_username']"));
        private IWebElement CreateWarriorButton 
            => Driver.FindElement(By.Id("warrior"));
        private IWebElement StartJourneyButton 
            => Driver.FindElement(By.Id("start"));

        public void CreateWarrior(string userNameInput)
        {
            UserNameInputField.SendKeys(userNameInput);

            CreateWarriorButton.Click();

            StartJourney();
        }
      
        public void StartJourney()
        {
            WaitForElement(StartJourneyButton);

            StartJourneyButton.Click();
        }

        protected override bool EvaluateLoadedStatus()
        {
            try
            {
                WaitForElement(UserNameInputField);
                return true;
            }
            catch
            {
                throw new Exception("Create warrior page not load");
            }    
        }
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace WebLibrary.Pages
{
    public class LeaderBoardPage : PageBase
    {
        public LeaderBoardPage(IWebDriver webDriver) : base(webDriver)
        {
        }
        private IWebElement PageTitle
            => Driver.FindElement(By.ClassName("option-label"));

        private IList<IWebElement> LeaderBoardRows
            => Driver.FindElements(By.XPath("//tbody//tr"));

        private IWebElement SelectedOption(int option)
            => Driver.FindElement(By.Id("bus_answer_" + option));

        public string GetFinalScore(string username)
        {
            WaitForElement(LeaderBoardRows[0]);

            for (int i = 1; i <= LeaderBoardRows.Count; i++)
            {
                if (LeaderBoardRows[i].Text.Contains(username))
                    return LeaderBoardRows[i].FindElement(By.XPath("//td[3]")).Text;
            }

            return null;
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
                throw new Exception("Leader Board page not load");
            }
        }
    }
}

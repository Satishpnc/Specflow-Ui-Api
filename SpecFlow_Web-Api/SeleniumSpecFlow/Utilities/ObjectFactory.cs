using ApiLibrary.RequestDTO;
using System;
using WebLibrary.Pages;

namespace SeleniumSpecFlow.Utilities
{
    public class ObjectFactory
    {
        public Lazy<DriverFactory> DriverFactory = new Lazy<DriverFactory>();

        public Lazy<NewUserCreationPayLoad> PayLoad = new Lazy<NewUserCreationPayLoad>();

        public Lazy<LoginPage> LoginPage = new Lazy<LoginPage>(() => new LoginPage(Hooks.Driver));

        public Lazy<ChallengePage> ChallengePage = new Lazy<ChallengePage>(() => new ChallengePage(Hooks.Driver));

        public Lazy<LeaderBoardPage> LeaderBoardPage = new Lazy<LeaderBoardPage>(() => new LeaderBoardPage(Hooks.Driver));
    }

}
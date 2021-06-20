using ApiLibrary;
using ApiLibrary.Models;
using ApiLibrary.RequestDTO;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using SeleniumSpecFlow;
using SeleniumSpecFlow.Utilities;
using System;
using System.Collections.Generic;
using System.Text.Json;
using TechTalk.SpecFlow;
using TestLibrary.Utilities;

namespace TestLibrary.Steps
{
    [Binding]
    public class ApiTestSteps : ObjectFactory
    {
        private readonly RestClient _restClient = Hooks.restClient;
        private readonly string _newRandomUserName = Util.RandomString();
        private readonly Random _latestScore = new Random();
        private string _resource;
        public IRestResponse restResponse { get; private set; }


        [Given(@"I want to validate the users endpoint")]
        [Given(@"I want to validate the creation of new user's endpoint")]
        public void GivenIWantToValidateTheUsersEndpoint()
        {
            _resource = "/user";
        }

        [When(@"I requested ""(.*)"" operation to create new user to fetch the response")]
        public void WhenIRequestedOperationToCreateNewUserToFetchTheResponse(string method)
        {
            NewUserCreationPayLoad newUserCreationPayLoad = new NewUserCreationPayLoad { UserName = _newRandomUserName, Score = 0 };
            restResponse = ApiHelper.CreateRequest(JsonConvert.SerializeObject(newUserCreationPayLoad), method, _restClient, _resource);
        }

        [When(@"I requested ""(.*)"" operation to amend the score for the user ""(.*)"" and fetch the response")]
        public void WhenIRequestedOperationToAmendTheScoreForTheUserAndFetchTheResponse(string method, string userName)
        {
            var amendedScoreForAnUser = new { UserName = userName, Score = _latestScore.Next(0, 1000) };
            restResponse = ApiHelper.CreateRequest(JsonConvert.SerializeObject(amendedScoreForAnUser), method, _restClient, _resource);
        }

        [When(@"I requested ""(.*)"" operation and fetch the response")]
        public void WhenIRequestedFor(string method)
                => restResponse = ApiHelper.CreateRequest(string.Empty, method, _restClient, _resource);

        [Then(@"I should see the status of pull request list (.*)")]
        public void ThenIValidateStatusShouldBe(string status)
        {
            string Status = restResponse.StatusCode.ToString();
            Assert.AreEqual(status, Status, "Status code is not " + status);
        }

        [Then(@"I should see the (.*) status code")]
        public void ThenIValidateResponseStatusShouldBe(int status)
        {
            int StatusCode = (int)restResponse.StatusCode;
            Assert.AreEqual(status, StatusCode, "Status code is not " + status);
        }

        [Then(@"I should validate the users response")]
        public void ThenIShouldValidateTheUsersResponse()
        {
            var userDetails = JArray.Parse(restResponse.Content).ToObject<List<UsersResponse>>();
            foreach (var user in userDetails)
            {
                Assert.Greater(user.UserId, 0, "Verify the UserId doesnt have positive integer");
                Assert.GreaterOrEqual(user.Score, 0, "Verify the Score should be always greater than or equal to zero");
                Assert.IsNotEmpty(user.UserName, "UserName should be empty");
            }
        }

        [Then(@"I see the response of new user being created successfully")]
        public void ThenISeeTheResponseOfNewUserBeingCreatedSuccessfully()
        {
            var response = JsonConvert.DeserializeObject<UserMandatesResponse>(restResponse.Content);
            Assert.AreEqual(response.Status, "success");
            Assert.AreEqual(response.Message, "User added.");
        }

        [Then(@"I see the response of the user score has been updated successfully")]
        public void ThenISeeTheResponseOfUserScoreAmendedSuccessfully()
        {
            var response = JsonConvert.DeserializeObject<UserMandatesResponse>(restResponse.Content);
            Assert.AreEqual(response.Status, "success");
            Assert.AreEqual(response.Message, "User added with updated score");
        }
    }
}

using BookRequests.Model;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;

namespace BookRequests
{
    public class Tests
    {
        private const string BaseUrl = "http://localhost:3000";
        private const string ApplicationJson = "application/json";
        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>()
        {
            { "G-Token", "ROM831ESV" },
            { "Content-Type", ApplicationJson }
        };
        private RestClient _client;
        private User _createdUser1;
        private User _createdUser2;

        [SetUp]
        public void Setup()
        {
            _client = new RestClient(BaseUrl);
            _client.AddDefaultHeaders(_headers);
        }

        [Test]
        public void Task1_CreateNewHousehold()
        {
            string newHouseholdName = $"HouseHold - {GenerateRandomTestString()}";
            var household = new Household() { Name = newHouseholdName };

            RestRequest request = new RestRequest("/households", Method.POST);
            request.AddParameter(ApplicationJson, household.ToJson(), ParameterType.RequestBody);
            _client.Post(request);

            Assert.AreEqual(newHouseholdName, household.Name);
        }


        [Test]
        public void Task2_AddTwoDifferentUsers()
        {
            string user1Random = GenerateRandomTestString();
            string user2Random = GenerateRandomTestString();

            var user1 = new User()
            {
                Email = $"user-{user1Random}@mailinator.com",
                FirstName = $"user-{user1Random}",
                LastName = $"{user1Random}",
                HouseholdId = 1
            };

            var user2 = new User()
            {
                Email = $"user-{user2Random}@mailinator.com",
                FirstName = $"user-{user2Random}",
                LastName = $"{user2Random}",
                HouseholdId = 1
            };

            string createdUser1Response = CreateUserRequest("/users", user1).Content;
            _createdUser1 = User.FromJson(createdUser1Response);


            string createdUser2Response = CreateUserRequest("/users", user2).Content;
            _createdUser2 = User.FromJson(createdUser2Response);


        }

        [Test]
        public void Task3_()
        {
            int a = _createdUser1.Id;
            int b = _createdUser2.Id;
        }


        private string GenerateRandomTestString()
        {
            int randomNumber = new Random().Next(0, int.MaxValue);
            return $"Test{randomNumber}";
        }

        private IRestResponse CreateUserRequest(string endPoint, User userForCreation)
        {
            RestRequest request = new RestRequest("/users", Method.POST);
            request.AddParameter(ApplicationJson, userForCreation.ToJson(), ParameterType.RequestBody);
            return _client.Post(request);
        }
    }
}
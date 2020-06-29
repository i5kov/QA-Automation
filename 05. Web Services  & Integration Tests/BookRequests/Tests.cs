using BookRequests.Model;
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
        private Household _createdHousehold;
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
            string content = _client.Post(request).Content;

            _createdHousehold = Household.FromJson(content);

            Assert.AreEqual(newHouseholdName, household.Name);
        }

        [Test]
        public void Task2_AddTwoDifferentUsers()
        {
            string user1Random = GenerateRandomTestString();
            string user2Random = GenerateRandomTestString();
            int householdId = _createdHousehold.Id;

            var user1 = new User()
            {
                Email = $"user-{user1Random}@mailinator.com",
                FirstName = $"user-{user1Random}",
                LastName = $"{user1Random}",
                HouseholdId = householdId
            };

            var user2 = new User()
            {
                Email = $"user-{user2Random}@mailinator.com",
                FirstName = $"user-{user2Random}",
                LastName = $"{user2Random}",
                HouseholdId = householdId
            };

            string createdUser1Response = CreateUserRequest("/users", user1).Content;
            _createdUser1 = User.FromJson(createdUser1Response);


            string createdUser2Response = CreateUserRequest("/users", user2).Content;
            _createdUser2 = User.FromJson(createdUser2Response);
        }

        [Test]
        public void Task3_AddTwoBooksForNewCreatedUser()
        {
            int user1WishlistId = _createdUser1.WishlistId;
            int user2WishlistId = _createdUser2.WishlistId;

            AddBooksForUser(new int[] { 1, 2 }, user1WishlistId);
            AddBooksForUser(new int[] { 3, 4 }, user2WishlistId);
        }

        [Test]
        public void Task4_AddTwoBooksForNewCreatedUser()
        {
            int householdId = _createdHousehold.Id;

            RestRequest restRequest = new RestRequest($"/households/{householdId}/wishlistBooks", Method.GET);
            IRestResponse restResponse = _client.Get(restRequest);


        }



        private string GenerateRandomTestString()
        {
            int randomNumber = new Random().Next(0, int.MaxValue);
            return $"Test{randomNumber}";
        }

        private IRestResponse CreateUserRequest(string endPoint, User userForCreation)
        {
            var restRequest = Post(endPoint).AddParameter(ApplicationJson, userForCreation.ToJson(), ParameterType.RequestBody);
            return _client.Post(restRequest);
        }

        private void AddBooksForUser(int[] bookIds, int userWishlistId)
        {
            for (int i = 0; i < bookIds.Length; i++)
            {
                _client.Post(Post($"wishlists/{userWishlistId}/books/{bookIds[i]}"));
            }
        }

        private RestRequest Post(string endPoint)
        {
            RestRequest request = new RestRequest(endPoint, Method.POST);
            return request;
        }
    }
}
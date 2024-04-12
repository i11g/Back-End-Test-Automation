using Eventmi.Core.Models.Event;
using Eventmi.Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using System.Net;

namespace EventMi.Tests
{
    public class Tests
    {   

        private RestClient _client;

        private string _baseUrl= "https://localhost:7236/";

        [SetUp]
        public void Setup()
        {
            _client = new RestClient(_baseUrl);
        }

        [Test]
        public async Task GetAllEvents_ReturnsSuccessStatusCode()
        {
            //Arange

            var request = new RestRequest("/Event/All", Method.Get);

            //Act
            var response=await _client.ExecuteAsync(request);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]

        public async Task Add_GetRequests_ReturnsAddView()
        {
            //Arrange
            var request = new RestRequest("/Event/Add", Method.Get);

            //Act

            var reponse = await _client.ExecuteAsync(request);
            //Assert
            Assert.That(reponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test] 

        public async Task Add_PostRequest_AddsNewEventAndRedirect()
        {
            //Arrange
            var input = new EventFormModel()
            {
                Name = "DitCome",
                Place = "Sofia",
                Start = new DateTime(2024, 10, 10, 10, 0, 0),
                End = new DateTime(2024, 10, 11, 14, 0, 0)
            };

            var request = new RestRequest("/Event/Add", Method.Post);

            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddParameter("Name", input.Name);
            request.AddParameter("Place", input.Place);
            request.AddParameter("Start", input.Start.ToString("MM/dd/yyyy hh:mm tt"));
            request.AddParameter("End", input.End.ToString("MM/dd/yyyy hh:mm tt"));

            //Act
            var response = await _client.ExecuteAsync(request);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.True(CheckIfEventExist(input.Name), "Event was not added to the database");
        } 

        private bool CheckIfEventExist(string name)
        {
            var options = new DbContextOptionsBuilder<EventmiContext>
                ().UseSqlServer("Server = DESKTOP - 6BKV1M0\\SQLEXPRESS").Options;

            using var context = new EventmiContext(options);

            return context.Events.Any(x=>x.Name==name);
        }

        [Test] 

        public async Task Deatails_GetRequest_ShouldReturnDetailedView ()
        {   
            //Arrange
            var eventId = 1;
            var request = new RestRequest($"Event/Details/{eventId}", Method.Get);
            //Act
            var response=await _client.ExecuteAsync(request);
            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test] 

        public async Task EditAction_ReturnViewForValidID()
        {   
            //Arrange
            var eventId = 1;
            var request = new RestRequest($"/Event/Edit{eventId}");
            //Act
            var response = await _client.ExecuteAsync(request);
            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }

        [Test]
    }
}
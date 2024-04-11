using Eventmi.Core.Models.Event;
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
            var request = new RestRequest("Event/Add", Method.Get);

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
                End = new DateTime(2024, 10, 10, 20, 0, 0)
            };

            var request = new RestRequest("/Event/All", Method.Post);
            request.AddHeader("Content-Type", "applocation/x-www-form-urlendcoded");
            request.AddParameter("Name", input.Name);
            request.AddParameter("Place", input.Place);
            request.AddParameter("Start", input.Start.ToString("MM/dd/yy/ hh:mm:ss"));
            request.AddParameter("End",input.End.ToString("MM/dd/yy/ hh:mm:ss"));

            //Act
            var response = await _client.ExecuteAsync(request);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        } 
    }
}
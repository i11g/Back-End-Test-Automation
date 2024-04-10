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
    }
}
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
        public void GetAllEvents_ReturnsSuccessStatusCode()
        {
            //Arange

            var request = new RestRequest("/Event/All", Method.Get);

            //Act
            var response=_client.Execute(request);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
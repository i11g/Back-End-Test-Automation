using RestSharp;
using RestSharp.Authenticators;
using System.Net;

namespace RestSharpTest_Project
{
    public class Tests
    {
        private RestClient client;

        [SetUp]
        public void Setup()
        {
            var options = new RestClientOptions("http://api.github.com")
            {
                Authenticator = new HttpBasicAuthenticator("i11g", "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"),
                MaxTimeout = 3000
            };

            this.client = new RestClient(options);

        }

        [Test]
        public void Test_GitIssuesEndPoint()
        {
            //Arrange
            var client = new RestClient("https://api.github.com");

            var request = new RestRequest("repos/testnakov/test-nakov-repos/issues", Method.Get);

            //Act

            var response = client.Execute(request);

            //Assert 

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
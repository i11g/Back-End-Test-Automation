using System.Text.Json;
using System.Text.Json.Nodes;

namespace RestSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://api.github.com");

            var request = new RestRequest("/users/softuni/repos", Method.Get);

            var response = client.Execute(request);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.StatusCode);

            //Segmentation 

            var client1 = new RestClinet("https://api.github.com");

            var request1 = new restRequest("/repos/{user}/{repo}/issues/{id}");

            request1.AddUrlSegment("user", "testNakov");
            request1.AddUrlSegment("repo", "test-nakov-repo");
            request1.AddUrlSegment("id", "1");

            //Deserialization JSON Respnse 

            var client2 = new RestClient("https://api.github.com");
            var request2 = new RestRequest("/users/softuni/repos", Method.Get);

            var response2=client2.Execute(request2);

            var repos=JsonSerializer.Deserialize<List<Repo>>(response2.Content);

            //HTTP Post Request 

            var client3 = new RestClient(new RestOptions("https://api.github.com")
            {

                Authenticator = new HttpBasicAuthenticator("i11g", "")

            });

            var request3 = new RestRequest("/repos/testnakov/test-nakov-repo/issues", Method.Post);

            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { title = "Title", body = "Body" });

            var response3 = client3.Execute(request3);
            Console.WriteLine(response3.StatusCode);

        }
    }
}

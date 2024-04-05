using System.Text.Json.Serialization;
using Newtonsoft.Json;
using RestSharp;

namespace RestSharp_Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("http://api.github.com");

            var request = new RestRequest("/users/softuni/repos", Method.Get);

            var response = client.Execute(request);

            Console.WriteLine(response);

            //URL Segmentation 

            var client1 =new RestClient("http://api.github.com");

            var request1 = new RestRequest("/repos/{user}/{repo}/issues/{id}", Method.Get);

            request.AddUrlSegment("user", "testnakov");
            request.AddUrlSegment("repo", "test-nakov-repo");
            request.AddUrlSegment("id", "1"); 

            var response1=client.Execute(request1);

            Console.WriteLine(response1.StatusCode);
            Console.WriteLine(response1.Content);

            //Deserializing JSON Responses 


            var client2 = new RestClient("http://api.github.com");

            var request2 = new RestRequest("/users/softuni/repos", Method.Get);

            var response2 =client2.Execute(request2);

            var repoObject = JsonConvert.DeserializeObject<Repo>(response2.Content);
        }
    }
}

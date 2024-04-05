using RestSharp;

namespace RestSharp_Proect_with_Authenticator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient(new RestOptions("http://api.github.com"))
            {
                Authenticator = new HttpBasicAuthenticator("i11g", "...")
            };

            var request = new RestRequest("repos/testnakov/test-nakov-repo/issues", Method.Post);

            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { title = "Title", body = "Body" });

            var response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
        }


        
    }
}

using RestSharp;
using RestSharp.Authenticators;

namespace RestSharp_Proect_with_Authenticator
{
    public class Program
    {
        static void Main(string[] args)
        {
            private RestClient client;

        var options = new RestClientOptions("http://api.github.com")
        {
            Authenticator = new HttpBasicAuthenticator("i11g", "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")
        };

        ClientCertificateOption=
        
            var request = new RestRequest("repos/testnakov/test-nakov-repo/issues", Method.Post);

        request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { title = "Title", body = "Body" });

            var response = client.Execute(request);
    Console.WriteLine(response.StatusCode);
        
       }


    }
}

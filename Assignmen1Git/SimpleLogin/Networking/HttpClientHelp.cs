using System;
using System.Net.Http;

namespace SimpleLogin.Networking
{
  
    public class HttpClientHelp
    {
        protected string Uri { get; } = "https://localhost:5003";

        protected static void RequestCodeCheck(HttpResponseMessage responseMessage)
        {
            Console.WriteLine("Checking request");
            if (!responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine("Not good");
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
        }
        
    }
}
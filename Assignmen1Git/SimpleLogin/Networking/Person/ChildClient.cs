using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entity.Models;

namespace SimpleLogin.Networking.Person
{
    public class ChildClient : HttpClientHelp, IChildClient
    {
        
         
        /*
         * AddChildAsync og AddPetAsync
         * 2 Metoder der ligner hindanden kan nok fixes hjælpemetode der bruger generic  
         */
        public async Task<Child> AddChildAsync(Child child)
        {
            using HttpClient httpClient = new HttpClient();

            string childAsJson = JsonSerializer.Serialize(child);
            StringContent childAsStringContent = new StringContent(childAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await httpClient.PostAsync(Uri + "/Child", childAsStringContent);
            
            RequestCodeCheck(responseMessage);

            string createdAsJson = await responseMessage.Content.ReadAsStringAsync();

            Child created = JsonSerializer.Deserialize<Child>(createdAsJson, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            return created;
        }

    }
}
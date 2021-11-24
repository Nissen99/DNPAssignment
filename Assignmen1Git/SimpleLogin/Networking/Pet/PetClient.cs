using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleLogin.Networking.Pet
{
    public class PetClient : HttpClientHelp, IPetClient
    {
        
        public async Task<Entity.Models.Pet> AddPetAsync(Entity.Models.Pet pet)
        {
            using HttpClient httpClient = new HttpClient();

            string petAsJson = JsonSerializer.Serialize(pet);
            
            StringContent petAsStringContent = new StringContent(petAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await httpClient.PostAsync(Uri + "/Pet", petAsStringContent);
            
            RequestCodeCheck(responseMessage);

            string createdAsJson = await responseMessage.Content.ReadAsStringAsync();

            Entity.Models.Pet created = JsonSerializer.Deserialize<Entity.Models.Pet>(createdAsJson, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            return created;
        }
    }
}
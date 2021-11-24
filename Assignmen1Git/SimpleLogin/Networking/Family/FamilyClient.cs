using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entity.Models;
using SimpleLogin.Networking;


public class FamilyClient  : HttpClientHelp, IFamilyClient
    {
        
        
        public async Task<Family> GetFamilyAsync(string streetName, int houseNumber)
        {
           
            using HttpClient httpClient = new HttpClient();
            
            HttpResponseMessage responseMessage =
                await httpClient.GetAsync( Uri + $"/Family?StreetName={streetName}&HouseNumber={houseNumber}"); 
            
            RequestCodeCheck(responseMessage);

            string inFromServer = await responseMessage.Content.ReadAsStringAsync();
            
            IList<Family> listOfFamiliesFromServer = JsonSerializer.Deserialize<IList<Entity.Models.Family>>(inFromServer,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

            Family familyFromServer = listOfFamiliesFromServer[0];

            return familyFromServer;
        }
        
        
        public async Task AddFamilyAsync(Family family)
        {
            using HttpClient httpClient = new HttpClient();
            
            string familyAsJson = JsonSerializer.Serialize(family);

            StringContent familyAsStringContent = new StringContent(familyAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await httpClient.PostAsync(Uri + "/Family", familyAsStringContent);
            
            RequestCodeCheck(responseMessage);

        }
        
        public async Task<IList<Family>> GetAllFamiliesAsync()
        {
            using HttpClient httpClient = new HttpClient();
            
            HttpResponseMessage responseMessage = await httpClient.GetAsync(Uri + "/Family");
            
            RequestCodeCheck(responseMessage);

            string allFamiliesAsJson = await responseMessage.Content.ReadAsStringAsync();
            IList<Family> allFamilies = JsonSerializer.Deserialize<IList<Family>>(allFamiliesAsJson, new JsonSerializerOptions() {
                PropertyNameCaseInsensitive = true
            });
            
            return allFamilies;
        }
        
        public async Task UpDateFamilyAsync(Family family)
        {
            using HttpClient httpClient = new HttpClient();
            string familyAsJson = JsonSerializer.Serialize(family);

            StringContent familyAsStringContent = new StringContent(familyAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await httpClient.PatchAsync(Uri + "/Family", familyAsStringContent);
            
            RequestCodeCheck(responseMessage);

        }
        
        public async Task RemoveFamilyAsync(Family family)
        {
            using HttpClient httpClient = new HttpClient();
            
            HttpResponseMessage responseMessage = await httpClient.DeleteAsync(Uri + $"/Family?HouseNumber={family.HouseNumber}&&StreetName={family.StreetName}");
            
            RequestCodeCheck(responseMessage);
        }


    }

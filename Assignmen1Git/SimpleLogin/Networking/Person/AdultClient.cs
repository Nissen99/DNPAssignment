using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entity.Models;

namespace SimpleLogin.Networking.Person
{
    public class AdultClient : HttpClientHelp, IAdultClient
    {
        
        public async Task<Adult> AddAdultAsync(Adult adult)
        {            
            using HttpClient httpClient = new HttpClient();

            string adultAsJson = JsonSerializer.Serialize(adult);
            StringContent adultAsStringContent = new StringContent(adultAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await httpClient.PostAsync(Uri + "/Adult", adultAsStringContent);
            
            RequestCodeCheck(responseMessage);

            string CreatedAsJson = await responseMessage.Content.ReadAsStringAsync();

            Adult Created = JsonSerializer.Deserialize<Adult>(CreatedAsJson, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            return Created;
        }
        
        public async Task<IList<Adult>> GetAllAdultsAsync()
        {
            using HttpClient httpClient = new HttpClient();

            HttpResponseMessage responseMessage = await httpClient.GetAsync(Uri + "/Adult");

           
            RequestCodeCheck(responseMessage);

            string responseFromServer = await responseMessage.Content.ReadAsStringAsync();

            IList<Adult> adultsFromServer = JsonSerializer.Deserialize<IList<Adult>>(responseFromServer,
                new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});

            return adultsFromServer;
        }
        
        public async Task RemoveAdultAsync(Adult adult)
        {
            using HttpClient httpClient = new HttpClient();
            HttpResponseMessage responseMessage = await httpClient.DeleteAsync(Uri + $"/Adult?Id={adult.Id}");
            
            RequestCodeCheck(responseMessage);
        }


        
    }
}
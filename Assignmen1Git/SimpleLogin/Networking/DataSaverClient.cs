using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;


namespace SimpleLogin.Networking
{
    public class DataSaverClient : IDataSaverClient
    {
        private string uri = "https://localhost:5003";
        
        
        public async Task AddFamilyAsync(Family family)
        {
            HttpClient httpClient = new HttpClient();
            
            string familyAsJson = JsonSerializer.Serialize(family);

            StringContent familyAsStringContent = new StringContent(familyAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await httpClient.PostAsync(uri + "/Family", familyAsStringContent);
            
            RequestCodeCheck(responseMessage);

        }

        public async Task<IList<Family>> GetAllFamiliesAsync()
        {
            HttpClient httpClient = new HttpClient();
            
            HttpResponseMessage responseMessage = await httpClient.GetAsync(uri + "/Family");
            
            RequestCodeCheck(responseMessage);

            string allFamiliesAsJson = await responseMessage.Content.ReadAsStringAsync();
            IList<Family> allFamilies = JsonSerializer.Deserialize<IList<Family>>(allFamiliesAsJson, new JsonSerializerOptions() {
                PropertyNameCaseInsensitive = true
            });

            Console.WriteLine(allFamilies[0].StreetName+ "CLINES");
            return allFamilies;
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {            
            HttpClient httpClient = new HttpClient();

            string adultAsJson = JsonSerializer.Serialize(adult);
            StringContent adultAsStringContent = new StringContent(adultAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await httpClient.PostAsync(uri + "/Adult", adultAsStringContent);
            
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

           HttpResponseMessage responseMessage = await httpClient.GetAsync(uri + "/Adult");

           
            RequestCodeCheck(responseMessage);

            string responseFromServer = await responseMessage.Content.ReadAsStringAsync();

            IList<Adult> adultsFromServer = JsonSerializer.Deserialize<IList<Adult>>(responseFromServer,
                new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});

            return adultsFromServer;
        }

        public async Task UpDateFamilyAsync(Family family)
        {
            HttpClient httpClient = new HttpClient();
            string FamilyAsJson = JsonSerializer.Serialize(family);

            StringContent FamilyAsStringContent = new StringContent(FamilyAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await httpClient.PatchAsync(uri + "/Family", FamilyAsStringContent);
            
            RequestCodeCheck(responseMessage);

            Console.WriteLine("From server : " + responseMessage.StatusCode);
        }

        public async Task RemoveAdultAsync(Adult adult)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage responseMessage = await httpClient.DeleteAsync(uri + $"/Adult?Id={adult.Id}");
            
            RequestCodeCheck(responseMessage);
        }


        private static void RequestCodeCheck(HttpResponseMessage responseMessage)
        {
            Console.WriteLine("Checking request");
            if (!responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine("Not good");
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
        }

        public async Task RemoveFamilyAsync(Family family)
        {
            HttpClient httpClient = new HttpClient();
            
            HttpResponseMessage responseMessage = await httpClient.DeleteAsync(uri + $"/Family?HouseNumber={family.HouseNumber}&&StreetName={family.StreetName}");
            
            RequestCodeCheck(responseMessage);
        }

        
        /*
         * AddChildAsync og AddPetAsync
         * 2 Metoder der ligner hindanden kan nok fixes hjælpemetode der bruger generic  
         */
        public async Task<Child> AddChildAsync(Child child)
        {
            HttpClient httpClient = new HttpClient();

            string childAsJson = JsonSerializer.Serialize(child);
            StringContent childAsStringContent = new StringContent(childAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await httpClient.PostAsync(uri + "/Child", childAsStringContent);
            
            RequestCodeCheck(responseMessage);

            string createdAsJson = await responseMessage.Content.ReadAsStringAsync();

            Child created = JsonSerializer.Deserialize<Child>(createdAsJson, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            return created;
        }

        public async Task<Pet> AddPetAsync(Pet pet)
        {
            HttpClient httpClient = new HttpClient();

            string petAsJson = JsonSerializer.Serialize(pet);
            
            StringContent petAsStringContent = new StringContent(petAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await httpClient.PostAsync(uri + "/Pet", petAsStringContent);
            
            RequestCodeCheck(responseMessage);

            string createdAsJson = await responseMessage.Content.ReadAsStringAsync();

            Pet created = JsonSerializer.Deserialize<Pet>(createdAsJson, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            return created;
        }

        public async Task<User> ValidateLoginAsync(string username, string password)
        {
            using HttpClient httpClient = new HttpClient();

            HttpResponseMessage responseMessage = await httpClient.GetAsync(uri + $"/User?username={username}&&password={password}");

           
            RequestCodeCheck(responseMessage);

            string responseFromServer = await responseMessage.Content.ReadAsStringAsync();

            User userFromServer = JsonSerializer.Deserialize<User>(responseFromServer,
                new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});

            return userFromServer;            

        }
    }
}
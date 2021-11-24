using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleLogin.Networking.User
{
    public class UserClient : HttpClientHelp, IUserClient
    {
        
        public async Task<Entity.Data.User> ValidateLoginAsync(string username, string password)
        {
            using HttpClient httpClient = new HttpClient();

            HttpResponseMessage responseMessage = await httpClient.GetAsync(Uri + $"/User?username={username}&&password={password}");

           
            RequestCodeCheck(responseMessage);

            string responseFromServer = await responseMessage.Content.ReadAsStringAsync();

            Entity.Data.User userFromServer = JsonSerializer.Deserialize<Entity.Data.User>(responseFromServer,
                new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});

            return userFromServer;            

        }

    }
}
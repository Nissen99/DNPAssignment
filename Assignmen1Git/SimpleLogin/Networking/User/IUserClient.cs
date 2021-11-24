using System.Threading.Tasks;

namespace SimpleLogin.Networking.User
{
    public interface IUserClient
    {
        Task<Entity.Data.User> ValidateLoginAsync(string username, string password);
    }
}
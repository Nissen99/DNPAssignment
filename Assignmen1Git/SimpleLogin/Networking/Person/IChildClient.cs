using System.Threading.Tasks;
using Entity.Models;

namespace SimpleLogin.Networking.Person
{
    public interface IChildClient
    {
        Task<Child> AddChildAsync(Child child);

    }
}
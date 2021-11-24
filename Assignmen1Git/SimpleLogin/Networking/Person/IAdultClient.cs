using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Models;

namespace SimpleLogin.Networking.Person
{
    public interface IAdultClient
    {
        Task<Adult> AddAdultAsync(Adult adult);
        Task<IList<Adult>> GetAllAdultsAsync();
        Task RemoveAdultAsync(Adult adult);
    }
}
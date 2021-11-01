using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace SimpleLogin.BuisnessModels
{
    public interface IAdultModel
    {
        Task<Adult> AddAdultAsync(Adult adult);

        Task RemoveAdultAsync(Adult adult);
        Task<IList<Adult>> GetAllAdultsAsync();

    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Models;

namespace SimpleLogin.BuisnessModels.PersonModel
{
    public interface IAdultModel
    {
        Task<Adult> AddAdultAsync(Adult adult);

        Task RemoveAdultAsync(Adult adult);
        Task<IList<Adult>> GetAllAdultsAsync();

    }
}
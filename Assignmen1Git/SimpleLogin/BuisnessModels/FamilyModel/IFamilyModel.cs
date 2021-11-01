using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace SimpleLogin.BuisnessModels.FamilyModel
{
    public interface IFamilyModel
    {
        Task AddFamilyAsync(Family family);

        Task<IList<Family>> GetAllFamiliesAsync();
        Task RemoveFamilyAsync(Family family);
    }
}
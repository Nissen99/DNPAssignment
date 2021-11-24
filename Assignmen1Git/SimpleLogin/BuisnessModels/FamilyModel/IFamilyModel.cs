using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Models;

namespace SimpleLogin.BuisnessModels.FamilyModel
{
    public interface IFamilyModel
    {
        Task AddFamilyAsync(Family family);

        Task<IList<Family>> GetAllFamiliesAsync();
        Task RemoveFamilyAsync(Family family);
        Task<Family> GetFamilyAsync(string streetName, int houseNumber);
    }
}
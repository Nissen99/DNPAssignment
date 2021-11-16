using System.Threading.Tasks;
using Entity.Models;

namespace SimpleLogin.BuisnessModels.FamilyConnectionModels
{
    public interface IFamilyAdultModel
    {
        Task RemoveAdultFromFamilyAsync(Family family, Adult adult);
        
        Task AddAdultToFamilyAsync(Adult adult, Family family);

    }
}
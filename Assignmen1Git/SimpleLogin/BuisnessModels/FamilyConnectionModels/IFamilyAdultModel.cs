using System.Threading.Tasks;
using Models;

namespace SimpleLogin.BuisnessModels.FamilyConnectionModels
{
    public interface IFamilyAdultModel
    {
        Task RemoveAdultFromFamilyAsync(Family family, Adult adult);
        
        Task AddAdultToFamilyAsync(Adult adult, Family family);

    }
}
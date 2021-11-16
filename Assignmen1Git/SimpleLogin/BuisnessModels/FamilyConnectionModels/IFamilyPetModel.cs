using System.Threading.Tasks;
using Entity.Models;

namespace SimpleLogin.BuisnessModels.FamilyConnectionModels
{
    public interface IFamilyPetModel
    {
        Task AddPetToFamilyAsync(Family family, Pet pet);

    }
}
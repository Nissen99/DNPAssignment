using System.Threading.Tasks;
using Models;

namespace SimpleLogin.BuisnessModels.FamilyConnectionModels
{
    public interface IFamilyPetModel
    {
        Task AddPetToFamilyAsync(Family family, Pet pet);

    }
}
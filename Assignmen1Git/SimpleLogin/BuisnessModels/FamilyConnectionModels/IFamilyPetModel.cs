using System.Threading.Tasks;
using SimpleLogin.Models;

namespace SimpleLogin.BuisnessModels.FamilyConnectionModels
{
    public interface IFamilyPetModel
    {
        Task AddPetToFamilyAsync(Family family, Pet pet);

    }
}
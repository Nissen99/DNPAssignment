using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Data;
using Entity.Models;

namespace SimpleLogin.Networking
{
    public interface IDataSaverClient
    {
        Task AddFamilyAsync(Family family);
        Task<IList<Family>> GetAllFamiliesAsync();
        Task<Adult> AddAdultAsync(Adult adult);

        Task<IList<Adult>> GetAllAdultsAsync();

        Task UpDateFamilyAsync(Family family);
        Task RemoveAdultAsync(Adult adult);
        Task RemoveFamilyAsync(Family family);
        Task<Child> AddChildAsync(Child child);
        Task<Pet> AddPetAsync(Pet pet);

        Task<User> ValidateLoginAsync(string username, string password);
        Task<Family> GetFamilyAsync(string streetName, int houseNumber);
    }
}
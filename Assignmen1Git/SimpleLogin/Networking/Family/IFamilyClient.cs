using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Models;


    public interface IFamilyClient
    {
        Task<Family> GetFamilyAsync(string streetName, int houseNumber);
        Task AddFamilyAsync(Family family);
        Task<IList<Family>> GetAllFamiliesAsync();
        Task UpDateFamilyAsync(Family family);
        Task RemoveFamilyAsync(Family family);
    }

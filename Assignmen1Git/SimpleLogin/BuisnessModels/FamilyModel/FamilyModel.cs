using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Models;


namespace SimpleLogin.BuisnessModels.FamilyModel
{
    public class FamilyModel : IFamilyModel
    {
        private readonly IFamilyClient _familyClient;

        public FamilyModel(IFamilyClient familyClient)
        {
            _familyClient = familyClient;
        }

        public async Task AddFamilyAsync(Family family)
        {
            await _familyClient.AddFamilyAsync(family);
        }

        public async Task<IList<Family>> GetAllFamiliesAsync()
        {
            IList<Family> allFamilies = await _familyClient.GetAllFamiliesAsync();
            return allFamilies;
        }

        public async Task RemoveFamilyAsync(Family family)
        {
            await _familyClient.RemoveFamilyAsync(family);
        }

        public async Task<Family> GetFamilyAsync(string streetName, int houseNumber)
        {
            return await _familyClient.GetFamilyAsync(streetName, houseNumber);
        }
    }
}
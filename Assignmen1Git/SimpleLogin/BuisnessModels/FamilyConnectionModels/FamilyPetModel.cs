using System.Threading.Tasks;
using Entity.Models;


namespace SimpleLogin.BuisnessModels.FamilyConnectionModels
{
    public class FamilyPetModel : IFamilyPetModel
    {
        private readonly IFamilyClient _familyClient;

        public FamilyPetModel(IFamilyClient familyClient)
        {
            _familyClient = familyClient;
        }
        
        public async Task AddPetToFamilyAsync(Family family, Pet pet)
        {
            family.Pets.Add(pet);
            await _familyClient.UpDateFamilyAsync(family);
        }

    }
}
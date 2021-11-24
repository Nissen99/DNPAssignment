using System.Threading.Tasks;
using Entity.Models;
using SimpleLogin.Networking.Pet;

namespace SimpleLogin.BuisnessModels.FamilyModel
{
    public class PetModel : IPetModel
    {
        private readonly IFamilyClient _familyClient;
        private readonly IPetClient _petClient;

        public PetModel(IFamilyClient familyClient, IPetClient petClient)
        {
            _familyClient = familyClient;
            _petClient = petClient;
        }
        
        public async Task RemovePetAsync(Family family, Pet pet)
        {
            family.Pets.Remove(pet);
            await _familyClient.UpDateFamilyAsync(family);

        }

  
        public Task<Pet> AddPetAsync(Pet pet)
        {
            return _petClient.AddPetAsync(pet);
        }

  
    }
}
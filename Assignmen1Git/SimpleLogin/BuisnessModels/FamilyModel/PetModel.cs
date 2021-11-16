using System.Threading.Tasks;
using Entity.Models;
using SimpleLogin.Networking;

namespace SimpleLogin.BuisnessModels.FamilyModel
{
    public class PetModel : IPetModel
    {
        private IDataSaverClient dataSaverClient;

        public PetModel(IDataSaverClient dataSaverClient)
        {
            this.dataSaverClient = dataSaverClient;
        }
        
        public async Task RemovePetAsync(Family family, Pet pet)
        {
            family.Pets.Remove(pet);
            await dataSaverClient.UpDateFamilyAsync(family);

        }

  
        public Task<Pet> AddPetAsync(Pet pet)
        {
            return dataSaverClient.AddPetAsync(pet);
        }

  
    }
}
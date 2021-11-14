using System.Threading.Tasks;
using SimpleLogin.Models;
using SimpleLogin.Networking;

namespace SimpleLogin.BuisnessModels.FamilyConnectionModels
{
    public class FamilyPetModel : IFamilyPetModel
    {
        private IDataSaverClient dataSaverClient;

        public FamilyPetModel(IDataSaverClient dataSaverClient)
        {
            this.dataSaverClient = dataSaverClient;
        }
        
        public async Task AddPetToFamilyAsync(Family family, Pet pet)
        {
            family.Pets.Add(pet);
            await dataSaverClient.UpDateFamilyAsync(family);
        }

    }
}
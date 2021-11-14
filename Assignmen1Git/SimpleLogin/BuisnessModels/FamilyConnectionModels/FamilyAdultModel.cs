using System;
using System.Linq;
using System.Threading.Tasks;
using SimpleLogin.Models;
using SimpleLogin.Networking;

namespace SimpleLogin.BuisnessModels.FamilyConnectionModels
{
    public class FamilyAdultModel : IFamilyAdultModel
    {
        private IDataSaverClient dataSaverClient;

        public FamilyAdultModel(IDataSaverClient dataSaverClient)
        {
            this.dataSaverClient = dataSaverClient;
        }
        
        public async Task RemoveAdultFromFamilyAsync(Family family, Adult adult)
        {
            family.Adults.Remove(adult);
            await dataSaverClient.UpDateFamilyAsync(family);
        }
        
        public async Task AddAdultToFamilyAsync(Adult adult, Family family)
        {
            Adult checkIfAlreadyInList = family.Adults.FirstOrDefault(f => f.Id == adult.Id);
            if (family.Adults.Count < 2 && checkIfAlreadyInList == null)
            {
                family.Adults.Add(adult);
            }
            else
            {
                throw new Exception("Adult list full");
            }

            await dataSaverClient.UpDateFamilyAsync(family);
        }
    }
}
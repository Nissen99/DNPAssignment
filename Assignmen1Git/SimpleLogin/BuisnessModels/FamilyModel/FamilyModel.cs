using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleLogin.Models;
using SimpleLogin.Networking;

namespace SimpleLogin.BuisnessModels.FamilyModel
{
    public class FamilyModel : IFamilyModel
    {
        private IDataSaverClient dataSaverClient;

        public FamilyModel(IDataSaverClient dataSaverClient)
        {
            this.dataSaverClient = dataSaverClient;
        }

        public async Task AddFamilyAsync(Family family)
        {
            await dataSaverClient.AddFamilyAsync(family);
        }

        public async Task<IList<Family>> GetAllFamiliesAsync()
        {
            IList<Family> allFamilies = await dataSaverClient.GetAllFamiliesAsync();
            return allFamilies;
        }

        public async Task RemoveFamilyAsync(Family family)
        {
            await dataSaverClient.RemoveFamilyAsync(family);
        }


    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleLogin.Models;
using SimpleLogin.Networking;

namespace SimpleLogin.BuisnessModels
{
    public class AdultModel : IAdultModel
    {
        private IDataSaverClient dataSaverClient;

        public AdultModel(IDataSaverClient dataSaverClient)
        {
            this.dataSaverClient = dataSaverClient;
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
           return await dataSaverClient.AddAdultAsync(adult);
        }

        public async Task RemoveAdultAsync(Adult adult)
        {
              await dataSaverClient.RemoveAdultAsync(adult);
        }

        public async Task<IList<Adult>> GetAllAdultsAsync()
        {
            return await dataSaverClient.GetAllAdultsAsync();
        }

   
    }
}
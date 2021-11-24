using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Models;
using SimpleLogin.Networking.Person;

namespace SimpleLogin.BuisnessModels.PersonModel
{
    public class AdultModel : IAdultModel
    {
        private IAdultClient _adultClient;

        public AdultModel(IAdultClient adultClient)
        {
            _adultClient = adultClient;
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
           return await _adultClient.AddAdultAsync(adult);
        }

        public async Task RemoveAdultAsync(Adult adult)
        {
              await _adultClient.RemoveAdultAsync(adult);
        }

        public async Task<IList<Adult>> GetAllAdultsAsync()
        {
            return await _adultClient.GetAllAdultsAsync();
        }

   
    }
}
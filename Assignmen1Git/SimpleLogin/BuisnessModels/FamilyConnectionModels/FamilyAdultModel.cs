using System;
using System.Linq;
using System.Threading.Tasks;
using Entity.Models;
using Entity.Util;
using SimpleLogin.Networking;

namespace SimpleLogin.BuisnessModels.FamilyConnectionModels
{
    public class FamilyAdultModel : IFamilyAdultModel
    {
        private IDataSaverClient dataSaverClient;
        private IFamilyInputValidation _inputValidation;

        public FamilyAdultModel(IDataSaverClient dataSaverClient, IFamilyInputValidation familyInputValidation)
        {
            this.dataSaverClient = dataSaverClient;
            _inputValidation = familyInputValidation;
        }
        
        public async Task RemoveAdultFromFamilyAsync(Family family, Adult adult)
        {
            family.Adults.Remove(adult);
            await dataSaverClient.UpDateFamilyAsync(family);
        }
        
        public async Task AddAdultToFamilyAsync(Adult adult, Family family)
        {
            _inputValidation.IfAdultInFamily(adult, family);

            _inputValidation.FamilyAdultNotFull(family);
            
            family.Adults.Add(adult);
                
            await dataSaverClient.UpDateFamilyAsync(family);
        }
    }
}
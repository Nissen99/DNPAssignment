using System.Threading.Tasks;
using Entity.Models;
using Entity.Util;

namespace SimpleLogin.BuisnessModels.FamilyConnectionModels
{
    public class FamilyAdultModel : IFamilyAdultModel
    {
        private readonly IFamilyClient _familyClient;
        private readonly IFamilyInputValidation _inputValidation;

        public FamilyAdultModel(IFamilyClient familyClient, IFamilyInputValidation familyInputValidation)
        {
            _familyClient = familyClient;
            _inputValidation = familyInputValidation;
        }
        
        public async Task RemoveAdultFromFamilyAsync(Family family, Adult adult)
        {
            family.Adults.Remove(adult);
            await _familyClient.UpDateFamilyAsync(family);
        }
        
        public async Task AddAdultToFamilyAsync(Adult adult, Family family)
        {
            _inputValidation.IfAdultInFamily(adult, family);

            _inputValidation.FamilyAdultNotFull(family);
            
            family.Adults.Add(adult);
                
            await _familyClient.UpDateFamilyAsync(family);
        }
    }
}
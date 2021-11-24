using System.Threading.Tasks;
using Entity.Models;
using Entity.Util;


namespace SimpleLogin.BuisnessModels.FamilyConnectionModels
{
    public class FamilyChildModel : IFamilyChildModel
    {
        private readonly IFamilyClient _familyClient;
        private readonly IFamilyInputValidation _inputValidation;

        public FamilyChildModel(IFamilyClient familyClient, IFamilyInputValidation familyInputValidation)
        {
            _familyClient = familyClient;
            _inputValidation = familyInputValidation;
        }

        public async Task AddChildToFamilyAsync(Child child, Family family)
        {
            _inputValidation.FamilyChildrenNotFull(family);
            
            family.Children.Add(child);
            
            await _familyClient.UpDateFamilyAsync(family);
        }
    }
}
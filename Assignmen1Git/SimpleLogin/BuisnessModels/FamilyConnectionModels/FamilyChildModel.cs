using System;
using System.Threading.Tasks;
using Entity.Models;
using Entity.Util;
using SimpleLogin.Networking;

namespace SimpleLogin.BuisnessModels.FamilyConnectionModels
{
    public class FamilyChildModel : IFamilyChildModel
    {
        private IDataSaverClient dataSaverClient;
        private IFamilyInputValidation _inputValidation;


        public FamilyChildModel(IDataSaverClient dataSaverClient, IFamilyInputValidation familyInputValidation)
        {
            this.dataSaverClient = dataSaverClient;
            _inputValidation = familyInputValidation;
        }

        public async Task AddChildToFamilyAsync(Child child, Family family)
        {
            _inputValidation.FamilyChildrenNotFull(family);
            
            family.Children.Add(child);
            
            await dataSaverClient.UpDateFamilyAsync(family);
        }
    }
}
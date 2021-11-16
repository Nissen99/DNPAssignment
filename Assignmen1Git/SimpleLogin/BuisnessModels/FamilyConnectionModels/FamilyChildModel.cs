using System;
using System.Threading.Tasks;
using Entity.Models;
using SimpleLogin.Networking;

namespace SimpleLogin.BuisnessModels.FamilyConnectionModels
{
    public class FamilyChildModel : IFamilyChildModel
    {
        private IDataSaverClient dataSaverClient;

        public FamilyChildModel(IDataSaverClient dataSaverClient)
        {
            this.dataSaverClient = dataSaverClient;
        }

        public async Task AddChildToFamilyAsync(Child child, Family family)
        {
            if (family.Children.Count < 7)
            {
                family.Children.Add(child);
            }
            else
            {
                throw new Exception("Child list full");
            }
            
            await dataSaverClient.UpDateFamilyAsync(family);
        }
    }
}
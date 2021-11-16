using System.Threading.Tasks;
using Entity.Models;
using SimpleLogin.Networking;

namespace SimpleLogin.BuisnessModels
{
    public class ChildModel : IChildModel
    {
        private IDataSaverClient dataSaverClient;

        public ChildModel(IDataSaverClient dataSaverClient)
        {
            this.dataSaverClient = dataSaverClient;
        }

        public async Task<Child> AddChildAsync(Child child)
        {
            return await dataSaverClient.AddChildAsync(child);
        }

        public async Task RemoveChildAsync(Family family, Child child)
        {
            family.Children.Remove(child);
            await dataSaverClient.UpDateFamilyAsync(family);
        }
    }
}
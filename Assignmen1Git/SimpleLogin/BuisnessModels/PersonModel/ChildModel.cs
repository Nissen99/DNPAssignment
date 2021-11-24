using System.Threading.Tasks;
using Entity.Models;
using SimpleLogin.Networking.Person;

namespace SimpleLogin.BuisnessModels.PersonModel
{
    public class ChildModel : IChildModel
    {
        private IChildClient _childClient;
        private IFamilyClient _familyClient;

        public ChildModel(IFamilyClient familyClient, IChildClient childClient)
        {
            _familyClient = familyClient;
            _childClient = childClient;
        }

        public async Task<Child> AddChildAsync(Child child)
        {
            return await _childClient.AddChildAsync(child);
        }

        public async Task RemoveChildAsync(Family family, Child child)
        {
            family.Children.Remove(child);
            await _familyClient.UpDateFamilyAsync(family);
        }
    }
}
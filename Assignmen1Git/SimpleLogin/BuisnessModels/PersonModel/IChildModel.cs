using System.Threading.Tasks;
using Entity.Models;

namespace SimpleLogin.BuisnessModels.PersonModel
{
    public interface IChildModel
    {
        Task<Child> AddChildAsync(Child child);
        Task RemoveChildAsync(Family family, Child child);
    }
}
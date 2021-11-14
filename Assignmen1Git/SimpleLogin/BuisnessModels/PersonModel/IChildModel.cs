using System.Threading.Tasks;
using SimpleLogin.Models;

namespace SimpleLogin.BuisnessModels
{
    public interface IChildModel
    {
        Task<Child> AddChildAsync(Child child);
        Task RemoveChildAsync(Family family, Child child);
    }
}
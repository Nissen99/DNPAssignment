using System.Threading.Tasks;
using SimpleLogin.Models;

namespace SimpleLogin.BuisnessModels.FamilyConnectionModels
{
    public interface IFamilyChildModel
    {
        Task AddChildToFamilyAsync(Child child, Family family);
    }
}
using System.Threading.Tasks;
using Entity.Models;

namespace SimpleLogin.BuisnessModels.FamilyConnectionModels
{
    public interface IFamilyChildModel
    {
        Task AddChildToFamilyAsync(Child child, Family family);
    }
}
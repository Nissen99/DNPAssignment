using System.Threading.Tasks;

namespace SimpleLogin.Networking.Pet
{
    public interface IPetClient
    {
        Task<Entity.Models.Pet> AddPetAsync(Entity.Models.Pet pet);
    }
}
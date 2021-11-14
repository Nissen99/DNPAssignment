using AssignmentDataServer.Models;

namespace AssignmentDataServer.Persistence
{
    public class PetDAO : IPetDAO
    {
        public void AddPet(Pet pet)
        {
            using DatabaseContext databaseContext = new DatabaseContext();
            databaseContext.Pets.Add(pet);
            databaseContext.SaveChanges();
        }
    }
}
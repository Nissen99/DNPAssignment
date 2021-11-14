using System.Collections.Generic;
using AssignmentDataServer.Data;
using AssignmentDataServer.Models;

namespace AssignmentDataServer.Persistence
{
    public interface IDataSaver
    {
        void AddAdult(Adult adult);
        void AddFamily(Family family);
        IList<Adult> GetAllAdults();
        IList<Family> GetAllFamilies();
        void RemoveAdult(Adult adult);
        void UpdateFamily(Family family);
        void RemoveFamily(int? houseNumber, string streetName);
        void AddChild(Child child);
        User ValidateUser(string username, string password);
        void AddPet(Pet pet);
    }
}
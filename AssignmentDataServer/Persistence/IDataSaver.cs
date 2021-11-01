using System.Collections.Generic;
using AssignmentDataServer.Models;

namespace AssignmentDataServer.Persistence
{
    public interface IDataSaver
    {
        void AddAdult(Adult adult);
        void AddFamily(Family family);
        public IList<Adult> Adults { get; }
        public IList<Family> Families { get; }
        public void SaveChanges();
        void RemoveAdult(Adult adult);
        int GetNextId();
        void UpdateFamily(Family family);
        void RemoveFamily(int? houseNumber, string streetName);
        User ValidateUser(string username, string password);
    }
}
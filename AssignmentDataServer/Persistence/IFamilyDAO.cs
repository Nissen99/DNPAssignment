using System.Collections.Generic;
using AssignmentDataServer.Models;

namespace AssignmentDataServer.Persistence
{
    public interface IFamilyDAO
    {
        void AddFamily(Family family);
        IList<Family> GetAllFamilies();
        void UpdateFamily(Family family);
        void RemoveFamily(int? houseNumber, string streetName);



    }
}
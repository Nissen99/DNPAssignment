using System.Collections.Generic;
using System.Linq;
using AssignmentDataServer.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentDataServer.Persistence
{
    public class FamilyDAO : IFamilyDAO
    {
        public void AddFamily(Family family)
        {
            using DatabaseContext databaseContext = new DatabaseContext();
            databaseContext.Families.Add(family);
            databaseContext.SaveChanges();
        }

        public IList<Family> GetAllFamilies()
        {
            using DatabaseContext databaseContext = new DatabaseContext();

            return databaseContext.Families.
                Include(family => family.Adults).
                Include(family => family.Pets).
                Include(family => family.Children).
                ThenInclude(child => child.Interests).
                Include(family => family.Children).
                ThenInclude(child => child.Pets).ToList();
            
            
          
        }

        public void RemoveFamily(int? houseNumber, string streetName)
        {
            using DatabaseContext databaseContext = new DatabaseContext();
            Family familyToRemove = databaseContext.Families.FirstOrDefault(family => family.HouseNumber == houseNumber &&
                family.StreetName.Equals(streetName));
            if (familyToRemove != null)
            {
                databaseContext.Families.Remove(familyToRemove);
                databaseContext.SaveChanges(); 
            }
       
            
        }
        
        
        public void UpdateFamily(Family family)
        {
            using DatabaseContext databaseContext = new DatabaseContext();
            databaseContext.Families.Update(family);
            databaseContext.SaveChanges();        
        }

    }
}
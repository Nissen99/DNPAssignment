using System.Collections.Generic;
using System.Linq;
using AssignmentDataServer.Data;
using AssignmentDataServer.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentDataServer.Persistence
{
    public class DatabaseConnection : IDataSaver
    {
        public DatabaseConnection()
        {
            using DatabaseContext databaseContext = new DatabaseContext();
            User seeIfTroelsThere = databaseContext.Users.FirstOrDefault(user => user.Username.Equals("Troels")); 
            
            if (seeIfTroelsThere == null)
            {
                databaseContext.Users.Add(new User()
                {
                    Username = "Troels",
                    Password = "Troels1",
                    Roles = new List<Role>() {new Role() {RoleName = "Admin"}}
                });
                databaseContext.Users.Add(new User()
                {
                    Username = "Kasper",
                    Password = "Kasper1",
                });
                databaseContext.SaveChanges(); 
            }
           
        }

        public void AddAdult(Adult adult)
        {
            using DatabaseContext databaseContext = new DatabaseContext();
            databaseContext.Adults.Add(adult);
            databaseContext.SaveChanges();
        }

        public void AddFamily(Family family)
        {
            using DatabaseContext databaseContext = new DatabaseContext();
            databaseContext.Families.Add(family);
            databaseContext.SaveChanges();
        }


        public IList<Adult> GetAllAdults()
        {
            using DatabaseContext databaseContext = new DatabaseContext();
            return databaseContext.Adults.Include(adult => adult.Job).ToList();
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



        public void RemoveAdult(Adult adult)
        {
            using DatabaseContext databaseContext = new DatabaseContext();
            databaseContext.Adults.Remove(adult);
            databaseContext.SaveChanges();        
        }
        

        public void UpdateFamily(Family family)
        {
            using DatabaseContext databaseContext = new DatabaseContext();
            databaseContext.Families.Update(family);
            databaseContext.SaveChanges();        
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

        public void AddChild(Child child)
        {
            using DatabaseContext databaseContext = new DatabaseContext();
            databaseContext.Children.Add(child);
            databaseContext.SaveChanges();
        }

        public User ValidateUser(string username, string password)
        {
            using DatabaseContext databaseContext = new DatabaseContext();
            User foundUser = databaseContext.Users.Include(user => user.Roles).FirstOrDefault(user => user.Username.Equals(username) && user.Password.Equals(password));
            return foundUser;
        }

        public void AddPet(Pet pet)
        {
            using DatabaseContext databaseContext = new DatabaseContext();
            databaseContext.Pets.Add(pet);
            databaseContext.SaveChanges();
        }
    }
}
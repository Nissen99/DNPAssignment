using System.Collections.Generic;
using System.Linq;
using AssignmentDataServer.Data;
using Microsoft.EntityFrameworkCore;

namespace AssignmentDataServer.Persistence
{
    public class UserDAO : IUserDAO
    {
        public UserDAO()
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

        public User ValidateUser(string username, string password)
        {
            using DatabaseContext databaseContext = new DatabaseContext();
            User foundUser = databaseContext.Users.Include(user => user.Roles).FirstOrDefault(user => user.Username.Equals(username) && user.Password.Equals(password));
            return foundUser;
        }

    }
}
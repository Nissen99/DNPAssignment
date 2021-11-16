using System.Collections.Generic;
using System.Linq;
using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentDataServer.Persistence
{
    public class AdultDAO : IAdultDAO
    {

        
        public void RemoveAdult(Adult adult)
        {
            using DatabaseContext databaseContext = new DatabaseContext();
            databaseContext.Adults.Remove(adult);
            databaseContext.SaveChanges();        
        }
        
        public void AddAdult(Adult adult)
        {
            using DatabaseContext databaseContext = new DatabaseContext();
            databaseContext.Adults.Add(adult);
            databaseContext.SaveChanges();
        }  
        
        public IList<Adult> GetAllAdults()
        {
            using DatabaseContext databaseContext = new DatabaseContext();
            return databaseContext.Adults.Include(adult => adult.Job).ToList();
        }
    }
}
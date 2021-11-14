using AssignmentDataServer.Data;
using AssignmentDataServer.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentDataServer.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlite(@"Data Source = C:\Users\Mikkel\RiderProjects\DNPAssignment2Version3\AssignmentDataServer\Family.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Family>().HasKey(family => new
            {
                family.StreetName, family.HouseNumber
            });
        }
        
    }
}
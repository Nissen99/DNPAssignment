using Entity.Data;
using Entity.Models;
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

        /*
         * In description of assignment it says that every property on person is required, i cannot figure out how to 
         * make that constraint here, could put [Required] on model classes, but they should not be tampered with based
         * on what database is being used, so as of now the database will rely  on it only getting "valid" models.
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Family>().HasKey(family => new
            {
                family.StreetName, family.HouseNumber
            });
            modelBuilder.Entity<Role>().HasKey(role => new
            {
                role.RoleName
            });
            modelBuilder.Entity<User>().HasKey(user => new
            {
                user.Username
            });
            

        }
        
    }
}
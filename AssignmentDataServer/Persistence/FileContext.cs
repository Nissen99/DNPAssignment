using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using AssignmentDataServer.Models;

namespace AssignmentDataServer.Persistence
{
    public class FileContext : IDataSaver
    {
        public IList<Family> Families { get; private set; }


        public IList<Adult> Adults { get; private set; }
        
        private List<User> users;

        private readonly string familiesFile = "families.json";
        private readonly string adultsFile = "adults.json";

        public FileContext()
        {
            Families = File.Exists(familiesFile) ? ReadData<Family>(familiesFile) : new List<Family>();
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
            
            users = new List<User>();
            users.Add(new User {
                Username = "Troels",
                Password = "Troels1",
                Roles = new[] {"Admin"}
            });
            users.Add(new User {
                Username = "Kasper",
                Password = "Kasper1",
                Roles = new string[] { }
            });

        }

        public void AddAdult(Adult adult)
        {
     
            adult.Id = GetNextId();
            Adults.Add(adult);
            SaveChanges();
        }

        public void AddFamily(Family family)
        {
           Families.Add(family);
           SaveChanges();
        }
        
   
        
        public void RemoveAdult(Adult adult)
        {
            Adults.Remove(adult);
            foreach (Family family in Families)
            {
                try
                {
                    Adult adultToRemoveFromFam = family.Adults.First(a => a.Id == adult.Id);
                    family.Adults.Remove(adultToRemoveFromFam);
                }
                catch (Exception e) { }
            }
            
            SaveChanges();
        }

        
        /*
         * Så længe denne metode burges til alt givning af Id sikre vi os at 2 ting ikke har samme id
         */
       //TODO Fix den her Metode, Det krævede for meget brain power at komme med en god løsning (muligvis gem højste id i fil)
        public int GetNextId()
        {
            int id = 0;
            foreach (Family family in Families)
            {
                try
                {
                    if (family.Children.Count != 0)
                    {
                        int maxIdChildren = family.Children.Max(maxId => maxId.Id);
                        if (maxIdChildren > id)
                        {
                            id = maxIdChildren;
                        }

                      
                        foreach (Child familyChild in family.Children)
                        {
                            if (familyChild.Pets.Count != 0)
                            {
                                int maxIdChildrenPets = familyChild.Pets.Max(maxId => maxId.Id);
                                if (maxIdChildrenPets > id)
                                {
                                    id = maxIdChildrenPets;
                                } }
                        }
                    }



                    if (family.Pets.Count != 0)
                    {
                        int maxIdForPets = family.Pets.Max(maxId => maxId.Id);
                    
                        if (maxIdForPets > id)
                        {
                            id = maxIdForPets;
                        }

                    }

                    if (family.Adults.Count != 0)
                    {
                        int maxIdAdults = family.Adults.Max(maxId => maxId.Id);
                        if (maxIdAdults > id)
                        {
                            id = maxIdAdults;
                        }
                    }    
                
                }
                catch (Exception e) { }
             
            }
            try
            {
                if (Adults.Count != 0)
                {
                    int maxIdNotInFamilies = Adults.Max(maxId => maxId.Id);
                    if (maxIdNotInFamilies > id)
                    {
                        id = maxIdNotInFamilies;
                    }
                }
              
            }
            catch (Exception e) { }
          
            return ++id;
        }

        public void UpdateFamily(Family family)
        {
            IList<Family> allFamilies = Families;

            Family indexHackFamily = allFamilies.First(f =>
                f.StreetName.Equals(family.StreetName) && f.HouseNumber == family.HouseNumber);
            
            int i = allFamilies.IndexOf(indexHackFamily);
            
            if (i == -1)
            {
                throw new Exception("Not found");
            }

            Families[i] = family;

            SaveChanges();
        }

        public void RemoveFamily(int? houseNumber, string streetName)
        {
            Family familyToRemove = Families.First(f =>
                f.StreetName.Equals(streetName) && f.HouseNumber == houseNumber);

            Families.Remove(familyToRemove);
            SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User ValidateUser(string username, string password)
        {
            
            var user = users.Find(u => u.Username.Equals(username) && u.Password.Equals(password));
            if (user != null) {
                Console.WriteLine("Found user");
            }

            return user;
        }

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges()
        {
            // storing families
            
            string jsonFamilies = JsonSerializer.Serialize(Families, new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            });
            using (StreamWriter outputFile = new StreamWriter(familiesFile, false))
            {
                outputFile.Write(jsonFamilies);
            }
            

            // storing persons
            string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            });
            using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
            
      
        }
    }
}
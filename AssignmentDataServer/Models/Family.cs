using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentDataServer.Models {
    
    //TODO Could limit Adult and children list (dont know how)
public class Family {
    
    //public int Id { get; set; }
    public string Name { get; set; }
    public string StreetName { get; set; }
    public int HouseNumber{ get; set; }
    public List<Adult> Adults { get; set; }
    public List<Child> Children{ get; set; }
    public List<Pet> Pets{ get; set; }

    public Family() {
        Adults = new List<Adult>();
        Children = new List<Child>();
        Pets = new List<Pet>();
    }
}


}
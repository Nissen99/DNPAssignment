using System.ComponentModel.DataAnnotations;

namespace AssignmentDataServer.Models {
public class Interest {
    
    [Key] public int InterestId { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }

}
}
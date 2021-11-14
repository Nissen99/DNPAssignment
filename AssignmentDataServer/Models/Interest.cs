using System.ComponentModel.DataAnnotations;

namespace AssignmentDataServer.Models {
public class Interest {
    
    [Key] public int InterestId { get; set; }
    [Required] public string Type { get; set; }
    [Required] public string Description { get; set; }

}
}
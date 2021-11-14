using System.ComponentModel.DataAnnotations;

namespace AssignmentDataServer.Data
{
    public class Role
    {
        [Key]
        public string RoleName { get; set; }
        
    }
}
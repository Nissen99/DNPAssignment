using System.ComponentModel.DataAnnotations;

namespace SimpleLogin.Data
{
    public class Role
    {
        [Key]
        public string RoleName { get; set; }
        
    }
}
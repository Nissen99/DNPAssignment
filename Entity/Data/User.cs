using System.Collections.Generic;

namespace Entity.Data
{
    public class User
    {
        public string Username { get; set; }

        public string Password { get; set; }

        //The property 'User.Roles' could not be mapped because it is of type 'string[]', which is not a supported primitive type or a valid entity type.
        //So made to to IList
        public List<Role> Roles {get; set;}

        public User()
        {
            Roles = new List<Role>();
        }

        public override string ToString() {
            return Username;
        }   
    }
}
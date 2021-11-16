using Entity.Models;

namespace Entity.Util
{
    public class PersonInputValidation : IPersonInputValidation
    {
        /*
* In assignment description it states that everything inherited from person is mandatory
*/
        public bool CheckValidPerson(Person person) 
        {
            if (person.Height == 0 || person.Sex == null || person.Weight == 0 || person.EyeColor == null
                || person.FirstName == null || person.HairColor == null || person.LastName == null)
            {
                return false;
            }
            return true;
            
        }
    }
}
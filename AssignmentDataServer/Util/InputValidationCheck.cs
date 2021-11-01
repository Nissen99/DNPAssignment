using System;
using AssignmentDataServer.Models;

namespace AssignmentDataServer
{
    public class InputValidationCheck : IInputValidationCheck
    {
        /*
       * Der står alt den inheriter er mandetory, selvom vi har tjek på klienten skal vi tjekke begge steder
       * Hvis der bliver udviklet en ny klient der ikke tjekker
       * Her tjekker vi ikke age da 0 teknisk set er en valid værdi
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

        /*
         * Her går jeg udfra man ikke kan bo i hus nummer 0
         */
        public bool CheckFamilyValid(Family family)
        {
            if (family.StreetName == null || family.HouseNumber == 0)
            {
                return false;
            }

            return true;
        }
    }
}
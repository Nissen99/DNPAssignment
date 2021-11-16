using Entity.Models;

namespace Entity.Util
{
    public class FamilyInputValidation : IFamilyInputValidation
    {
        
        /*
      * Assumed here that it is not possible to live in house number 0
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
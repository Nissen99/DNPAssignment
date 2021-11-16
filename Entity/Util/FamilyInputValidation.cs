using System;
using System.Linq;
using Entity.Models;

namespace Entity.Util
{
    public class FamilyInputValidation : IFamilyInputValidation
    {
        
        /*
      * Assumed here that it is not possible to live in house number 0
      */
        public bool FamilyHasStreetAndHouseNumber(Family family)
        {
            if (family.StreetName == null || family.HouseNumber == 0)
            {
                return false;
            }

            return true;
        }

        public void IfAdultInFamily(Adult adult, Family family)
        {
            
            Adult checkIfAlreadyInList = family.Adults.FirstOrDefault(f => f.Id == adult.Id);
            if (checkIfAlreadyInList == null)
            {
                return;
            }
            
            throw new Exception("Adult already in family");

        }

        public void FamilyAdultNotFull(Family family)
        {
            if (family.Adults.Count < 2)
            {
                return;
            }
            
            throw new Exception("Family has to many Adults");

        }

        public void FamilyChildrenNotFull(Family family)
        {
            if (family.Children.Count < 7)
            {
             return;
            }
            throw new Exception("Child list full");
        }
    }
}
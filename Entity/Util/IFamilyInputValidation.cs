using Entity.Models;

namespace Entity.Util
{
    public interface IFamilyInputValidation
    {
        bool FamilyHasStreetAndHouseNumber(Family family);

        void IfAdultInFamily(Adult adult, Family family);
        void FamilyAdultNotFull(Family family);
        void FamilyChildrenNotFull(Family family);
    }
}
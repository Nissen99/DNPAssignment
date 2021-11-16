using Entity.Models;

namespace AssignmentDataServer.Util
{
    public interface IInputValidationCheck
    {
        bool CheckValidPerson(Person person);
        bool CheckFamilyValid(Family family);
    }
}
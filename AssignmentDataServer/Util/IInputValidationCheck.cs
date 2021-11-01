using AssignmentDataServer.Models;

namespace AssignmentDataServer
{
    public interface IInputValidationCheck
    {
        bool CheckValidPerson(Person person);
        bool CheckFamilyValid(Family family);
    }
}
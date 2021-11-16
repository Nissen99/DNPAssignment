using Entity.Models;

namespace Entity.Util
{
    public interface IPersonInputValidation
    {
        bool CheckValidPerson(Person person);

    }
}
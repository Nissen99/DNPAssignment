using AssignmentDataServer.Data;

namespace AssignmentDataServer.Persistence
{
    public interface IUserDAO
    {
        User ValidateUser(string username, string password);

    }
}
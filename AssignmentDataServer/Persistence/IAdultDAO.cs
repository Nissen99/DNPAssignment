using System.Collections.Generic;
using Entity.Models;

namespace AssignmentDataServer.Persistence
{
    public interface IAdultDAO
    {
        void AddAdult(Adult adult);
        IList<Adult> GetAllAdults();
        void RemoveAdult(Adult adult);



    }
}
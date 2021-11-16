using Entity.Models;

namespace AssignmentDataServer.Persistence
{
    public class ChildDAO : IChildDAO
    {
        public void AddChild(Child child)
        {
            using DatabaseContext databaseContext = new DatabaseContext();
            databaseContext.Children.Add(child);
            databaseContext.SaveChanges();
        }

    }
}
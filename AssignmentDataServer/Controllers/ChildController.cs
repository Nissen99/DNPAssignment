
using AssignmentDataServer.Models;
using AssignmentDataServer.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentDataServer.Controllers
{ 
    [Controller]
    [Route("[controller]")]

    public class ChildController : ControllerBase
    {
        private IDataSaver DataSaver;

        public ChildController(IDataSaver dataSaver)
        {
            DataSaver = dataSaver;
        }


        /*
         * Gemmer ikke pt Child objecter, men lavet så den kan i fremtiden, for nu er det en fancy id generator 
         */
        [HttpPost]
        public ActionResult<Child> AddChild([FromBody] Child child)
        {
            child.Id = DataSaver.GetNextId();
            return Created("New Id: " + child.Id, child);
        }


    }

 
}
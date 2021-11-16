using Entity.Models;
using AssignmentDataServer.Persistence;
using AssignmentDataServer.Util;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentDataServer.Controllers
{ 
    [Controller]
    [Route("[controller]")]

    public class ChildController : ControllerBase
    {
        private IChildDAO childDao;
        private IInputValidationCheck inputValidationCheck;


        public ChildController(IChildDAO childDao, IInputValidationCheck inputValidationCheck)
        {
            this.childDao = childDao;
            this.inputValidationCheck = inputValidationCheck;

        }

        
        
        [HttpPost]
        public ActionResult<Child> AddChild([FromBody] Child child)
        {
            if (!inputValidationCheck.CheckValidPerson(child))
            {
                return BadRequest();
            }
            childDao.AddChild(child);
            return Created("New Id: " + child.Id, child);
        }
    }

 
}
using Entity.Models;
using AssignmentDataServer.Persistence;
using Entity.Util;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentDataServer.Controllers
{ 
    [Controller]
    [Route("[controller]")]

    public class ChildController : ControllerBase
    {
        private IChildDAO childDao;
        private IPersonInputValidation inputValidation;


        public ChildController(IChildDAO childDao, IPersonInputValidation personInputValidation)
        {
            this.childDao = childDao;
            inputValidation = personInputValidation;

        }

        
        
        [HttpPost]
        public ActionResult<Child> AddChild([FromBody] Child child)
        {
            if (!inputValidation.CheckValidPerson(child))
            {
                return BadRequest();
            }
            childDao.AddChild(child);
            return Created("New Id: " + child.Id, child);
        }
    }

 
}
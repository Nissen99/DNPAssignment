
using System;
using AssignmentDataServer.Models;
using AssignmentDataServer.Persistence;
using AssignmentDataServer.Util;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentDataServer.Controllers
{ 
    [Controller]
    [Route("[controller]")]

    public class ChildController : ControllerBase
    {
        private IDataSaver DataSaver;
        private IInputValidationCheck inputValidationCheck;


        public ChildController(IDataSaver dataSaver, IInputValidationCheck inputValidationCheck)
        {
            DataSaver = dataSaver;
            this.inputValidationCheck = inputValidationCheck;

        }


        /*
         * Gemmer ikke pt Child objecter, men lavet så den kan i fremtiden, for nu er det en fancy id generator 
         */
        [HttpPost]
        public ActionResult<Child> AddChild([FromBody] Child child)
        {

            if (!inputValidationCheck.CheckValidPerson(child))
            {
                return BadRequest();
            }

            DataSaver.AddChild(child);
            return Created("New Id: " + child.Id, child);
        }


    }

 
}
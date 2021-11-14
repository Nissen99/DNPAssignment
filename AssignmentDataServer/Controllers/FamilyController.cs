using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentDataServer.Models;
using AssignmentDataServer.Persistence;
using AssignmentDataServer.Util;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentDataServer.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class FamilyController : ControllerBase
    {
        private IDataSaver DataSaver;
        private IInputValidationCheck inputValidationCheck;


        public FamilyController(IDataSaver dataSaver, IInputValidationCheck inputValidationCheck)
        {
            DataSaver = dataSaver;
            this.inputValidationCheck = inputValidationCheck;

        }

        /*
         * Tjek for StreetName + House Number server side, incase new client will not
         */
        
        [HttpPost]
        public async Task<ActionResult<Family>> AddFamily([FromBody] Family family)
        {
            
            if (!inputValidationCheck.CheckFamilyValid(family))
            {
                return BadRequest("Family needs Primay key, StreetName + House number");
            }
            
            DataSaver.AddFamily(family);
            return Created("Family created", family);

        }

        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetFamilies([FromQuery] string StreetName, int? HouseNumber)
        {

            if (StreetName == null && HouseNumber == null)
            {
                IList<Family> allFamilies = DataSaver.GetAllFamilies();
            
                if (allFamilies.Count == 0)
                {
                    return NotFound("No families found");
                }
            
                return Ok(allFamilies);
            }

            try
            {
                Family Family = DataSaver.GetAllFamilies().First(f =>
                    f.StreetName.Equals(StreetName) && f.HouseNumber == HouseNumber);
                return Ok(Family);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateFamily([FromBody] Family family)
        {

            if (family.Adults.Count > 2 || family.Children.Count > 7)
            {
                Console.WriteLine("Bad Request");
                return BadRequest("Family size error");
            }

            try
            {
                DataSaver.UpdateFamily(family);

            }
            catch (Exception e)
            {
                return NotFound("Could Not find Family ");
            }

            return Ok();
        }


        [HttpDelete]
        public ActionResult RemoveFamily([FromQuery] int? HouseNumber, string StreetName)
        {
            if (HouseNumber == null || StreetName == null)
            {
                return BadRequest("Number or name = null");
            }

            try
            {
                DataSaver.RemoveFamily(HouseNumber, StreetName);

            }
            catch (Exception e)
            {
                BadRequest();
            }

            return Ok();
        }

        
      
     
    }
}
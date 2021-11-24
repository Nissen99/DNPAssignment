using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Models;
using AssignmentDataServer.Persistence;
using Entity.Util;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentDataServer.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class FamilyController : ControllerBase
    {
        private IFamilyDAO familyDao;
        private IFamilyInputValidation inputValidation;


        public FamilyController(IFamilyDAO familyDao, IFamilyInputValidation familyInputValidation)
        {
            this.familyDao = familyDao;
            inputValidation = familyInputValidation;

        }

        /*
         * Tjek for StreetName + House Number server side, incase new client will not
         */
        
        [HttpPost]
        public ActionResult<Family> AddFamily([FromBody] Family family)
        {
            
            if (!inputValidation.FamilyHasStreetAndHouseNumber(family))
            {
                return BadRequest("Family needs Primay key, StreetName + House number");
            }
            
            familyDao.AddFamily(family);
            return Created("Family created", family);

        }
        
        [HttpGet("GetByNameAndNumber/StreetName={StreetName}&HouseNumber={HouseNumber}")]
        public ActionResult<Family> GetFamiliesOnStreetAndNumber(string StreetName, int? HouseNumber)
        {
            Console.WriteLine("STREET ANAD NUMBER ");
            Console.WriteLine("Street: " + StreetName);
            Console.WriteLine("Number: " + HouseNumber);
            try
            {
                Family Family = familyDao.GetAllFamilies().First(f =>
                    f.StreetName.Equals(StreetName) && f.HouseNumber == HouseNumber);
                Console.WriteLine("Family found: " + Family.Name);
                return Ok(Family);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult<IList<Family>> GetFamilies()
        {
       
                IList<Family> allFamilies = familyDao.GetAllFamilies();
            
                if (allFamilies.Count == 0)
                {
                    return NotFound("No families found");
                }
                Console.WriteLine("ALL");

                return Ok(allFamilies);
                
            
        }

        [HttpPatch]
        public ActionResult UpdateFamily([FromBody] Family family)
        {

            if (family.Adults.Count > 2 || family.Children.Count > 7)
            {
                Console.WriteLine("Bad Request");
                return BadRequest("Family size error");
            }

            try
            {
                familyDao.UpdateFamily(family);

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
                familyDao.RemoveFamily(HouseNumber, StreetName);

            }
            catch (Exception e)
            {
                BadRequest();
            }

            return Ok();
        }

        
      
     
    }
}
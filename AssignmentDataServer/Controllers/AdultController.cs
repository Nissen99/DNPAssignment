using System;
using System.Collections.Generic;
using System.Linq;
using AssignmentDataServer.Persistence;
using AssignmentDataServer.Util;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentDataServer.Controllers
{        
    [ApiController]
    [Route("[controller]")]
    public class AdultController : ControllerBase
    {
        private IAdultDAO adultDao;
        private IInputValidationCheck inputValidationCheck;
        

        public AdultController(IAdultDAO adultDao, IInputValidationCheck inputValidationCheck)
        {
            this.adultDao = adultDao;
            this.inputValidationCheck = inputValidationCheck;
        }

        [HttpGet]
        public ActionResult<IList<Adult>> GetAdults()
        {
            IList<Adult> allAdults = adultDao.GetAllAdults();

            if (allAdults.Count == 0)
            {
                return NotFound("No adults found");
            }

            return Ok(allAdults);
        }


        [HttpPost]
        public ActionResult<Adult> AddAdult([FromBody] Adult adult)
        {

            if (!inputValidationCheck.CheckValidPerson(adult))
            {
                BadRequest("Something in Adult not set");

            }
      
        
            adultDao.AddAdult(adult);
            return Created("New Id: " + adult.Id, adult);
        }

      
      

        [HttpDelete]
        public ActionResult RemoveAdult([FromQuery] int Id)
        {
            Adult adultToRemove;
            try
            {
                adultToRemove  = adultDao.GetAllAdults().First(a => a.Id == Id);

            }
            catch (Exception e)
            {
                return NotFound();
            }
            
            adultDao.RemoveAdult(adultToRemove);
            

            return Ok();
        }
        
        

    }
}
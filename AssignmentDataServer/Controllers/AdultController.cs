﻿using System;
using System.Collections.Generic;
using System.Linq;
using AssignmentDataServer.Models;
using AssignmentDataServer.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentDataServer.Controllers
{        
    [ApiController]
    [Route("[controller]")]
    public class AdultController : ControllerBase
    {
        private IDataSaver DataSaver;

        public AdultController(IDataSaver dataSaver)
        {
            DataSaver = dataSaver;
        }

        [HttpGet]
        public ActionResult<IList<Adult>> GetAdults()
        {
            IList<Adult> allAdults = DataSaver.Adults;

            if (allAdults.Count == 0)
            {
                return NotFound("No adults found");
            }

            return Ok(allAdults);
        }


        [HttpPost]
        public ActionResult<Adult> AddAdult([FromBody] Adult adult)
        {
            DataSaver.AddAdult(adult);
            return Created("New Id: " + adult.Id, adult);
        }

        [HttpDelete]
        public ActionResult RemoveAdult([FromQuery] int Id)
        {
            Adult adultToRemove;
            try
            {
                adultToRemove  = DataSaver.Adults.First(a => a.Id == Id);

            }
            catch (Exception e)
            {
                return NotFound();
            }
            
            DataSaver.RemoveAdult(adultToRemove);
            

            return Ok();
        }
        
        

    }
}
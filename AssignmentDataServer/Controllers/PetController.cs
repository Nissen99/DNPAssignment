using System;
using AssignmentDataServer.Models;
using AssignmentDataServer.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentDataServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {
        
        private IDataSaver DataSaver;

        public PetController(IDataSaver dataSaver)
        {
            DataSaver = dataSaver;
        }


        [HttpPost]
        public ActionResult<Pet> AddPet([FromBody] Pet pet)
        {
            Console.WriteLine("BEFORE: " + pet.Id);
            DataSaver.AddPet(pet);
            Console.WriteLine("AFTER: " + pet.Id);
            return Created("New Id: " + pet.Id, pet);
        }
    }
}
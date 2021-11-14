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
        
        private IPetDAO petDao;

        public PetController(IPetDAO petDao)
        {
            this.petDao = petDao;
        }


        [HttpPost]
        public ActionResult<Pet> AddPet([FromBody] Pet pet)
        {
            Console.WriteLine("BEFORE: " + pet.Id);
            petDao.AddPet(pet);
            Console.WriteLine("AFTER: " + pet.Id);
            return Created("New Id: " + pet.Id, pet);
        }
    }
}
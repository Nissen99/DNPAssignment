using System;
using Entity.Models;
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
            petDao.AddPet(pet);
            return Created("New Id: " + pet.Id, pet);
        }
    }
}
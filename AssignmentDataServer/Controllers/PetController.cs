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
            pet.Id = DataSaver.GetNextId();
            return Ok(pet);
        }
    }
}
using System;

using Entity.Data;
using AssignmentDataServer.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentDataServer.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    
    public class UserController : ControllerBase
    {

        private IUserDAO userDao;

        public UserController(IUserDAO userDao)
        {
            this.userDao = userDao;
        }
        
        
        [HttpGet]
        public ActionResult<User> ValidateLogin([FromQuery] string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("Enter username");
            }

            if (string.IsNullOrEmpty(password))
            {
                return BadRequest("Enter password");
            }

            try
            {
                return Ok(userDao.ValidateUser(username, password));

            }
            catch (Exception e)
            {
                return NotFound();
            }
            
        }
        
    }
}
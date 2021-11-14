using System;
using System.Collections.Generic;
using System.Security.Claims;
using AssignmentDataServer.Data;
using AssignmentDataServer.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentDataServer.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    
    public class UserController : ControllerBase
    {

        private IDataSaver DataSaver;

        public UserController(IDataSaver dataSaver)
        {
            DataSaver = dataSaver;
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
                return Ok(DataSaver.ValidateUser(username, password));

            }
            catch (Exception e)
            {
                return NotFound();
            }
            

        }

        
        
        private ClaimsIdentity SetupClaimsForUser(User user) {
            ClaimsIdentity identity;
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Username));
            claims.Add(new Claim(ClaimTypes.Role, user.Username));

            foreach (Role role in user.Roles) {
                claims.Add(new Claim("Role", role.RoleName));
            }

            identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
    }
}
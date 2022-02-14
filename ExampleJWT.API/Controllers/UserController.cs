using ExampleJWT.API.Services;
using ExampleJWT.Models.Models;
using ExampleJWT.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExampleJWT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Get a user
        /// </summary>
        /// <param name="userId">user id</param>
        [HttpPost("[action]")]
        public IActionResult Get(string token)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                int userId = WebToken.GetUserId(token);
                User user = new UserService().Get(userId);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

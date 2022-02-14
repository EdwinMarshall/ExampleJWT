using ExampleJWT.API.Services.Interfaces;
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
    public class LoginController : BaseController
    {
        private IAuthService _userService;

        public LoginController(IAuthService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Authenticates a user an return a email with a token
        /// </summary>
        /// <param name="authRequest">Email and password</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] AuthRequest authRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int userId = _userService.AuthenticateUser(authRequest);
                string token = WebToken.GetToken(userId);

                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

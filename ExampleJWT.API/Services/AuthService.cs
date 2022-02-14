using ExampleJWT.Models.Models;
using ExampleJWT.API.Services.Interfaces;
using System;

namespace ExampleJWT.API.Services
{
    public class AuthService : IAuthService
    {
        /// <summary>
        /// Authenticates a user
        /// </summary>
        /// <param name="authRequest">Email and password</param>
        /// <returns>User Id</returns>
        public int AuthenticateUser(AuthRequest authRequest)
        {
            try
            {
                User user = new UserService().Users.Find(x => x.Email == authRequest.Email && x.Password == authRequest.Password);
                if(user != null)
                {
                    return user.UserId;
                }
                else
                {
                    throw new Exception("Invalid Credentials");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

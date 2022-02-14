using ExampleJWT.Models.Models;

namespace ExampleJWT.API.Services.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Authenticates a user
        /// </summary>
        /// <param name="authRequest">Email and password</param>
        /// <returns>User Id</returns>
        int AuthenticateUser(AuthRequest authRequest);
    }
}

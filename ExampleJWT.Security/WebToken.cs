using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ExampleJWT.Security
{
    public class WebToken
    {
        /// <summary>
        /// Generates a token
        /// </summary>
        /// <param name="userId">valid user</param>
        /// <returns>token</returns>
        public static string GetToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(GlobalConfiguration.KeyToken);
            var lifeTime = GlobalConfiguration.MinutesExpiresToken;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, userId.ToString())
                    }
                    ),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(lifeTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Get the userId from the token
        /// </summary>
        /// <param name="token">Token</param>
        /// <returns>user Id</returns>
        public static int GetUserId(string token)
        {
            var dec = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;

            return Convert.ToInt32(dec.Claims.First(claim => claim.Type == "nameid").Value);
        }
    }
}

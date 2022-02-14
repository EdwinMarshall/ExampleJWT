using ExampleJWT.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExampleJWT.UI.Services
{
    public interface ISocialApi
    {
        #region LOGIN
        [Post("/Login")]
        Task<ApiResponse<string>> AuthUser([FromBody] AuthRequest model);
        #endregion

        #region WEATHERFORECAST
        [Get("/WeatherForecast/Get")]
        [Headers("Authorization: Bearer")]
        Task<ApiResponse<IEnumerable<WeatherForecast>>> WeatherForecast_Get();
        #endregion

        #region USER
        [Post("/User/Get")]
        [Headers("Authorization: Bearer")]
        Task<ApiResponse<User>> User_Get([FromBody] string token);
        #endregion
    }
}

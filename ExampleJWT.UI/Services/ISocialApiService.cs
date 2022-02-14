using ExampleJWT.API;
using ExampleJWT.Models.Models;
using ExampleJWT.Models.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleJWT.UI.Services
{
    interface ISocialApiService
    {
        Task<ApiResponse<string>> AuthUser([FromBody] AuthRequest model);

        Task<ApiResponse<IEnumerable<WeatherForecast>>> WeatherForecast_Get();

        Task<ApiResponse<User>> User_Get([FromBody] string token);
    }
}

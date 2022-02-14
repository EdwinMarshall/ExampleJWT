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
    public class SocialApi : ISocialApiService
    {
        private readonly ISocialApi _api;

        public SocialApi(ISocialApi api)
        {
            _api = api;
        }

        public async Task<ApiResponse<string>> AuthUser([FromBody] AuthRequest model)
        {
            return await _api.AuthUser(model);
        }

        public async Task<ApiResponse<IEnumerable<WeatherForecast>>> WeatherForecast_Get()
        {
            return await _api.WeatherForecast_Get();
        }

        public async Task<ApiResponse<User>> User_Get([FromBody] string token)
        {
            return await _api.User_Get(token);
        }
    }
}

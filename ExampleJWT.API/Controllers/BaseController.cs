using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ExampleJWT.API.Controllers
{
    public class BaseController : ControllerBase
    {
        public int UserId
        {
            get
            {
                return int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            }
        }
    }
}

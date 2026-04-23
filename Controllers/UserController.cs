using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetUsers()
        {
            // Logic to retrieve users from the database
            return Ok(new { message = "Get all users" });
        }
    }
}

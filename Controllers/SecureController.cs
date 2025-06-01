using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecureController : Controller
    {
        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminEndpoint()
        {
            return Ok("只有 Admin 能看到這個");
        }

        [HttpGet("user")]
        [Authorize(Roles = "User,Admin")]
        public IActionResult UserEndpoint()
        {
            return Ok("Admin 或 User 都可以看到這個");
        }
    }
}

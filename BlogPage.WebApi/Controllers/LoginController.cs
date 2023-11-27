using Microsoft.AspNetCore.Mvc;

namespace BlogPage.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        [HttpPost]
        public IActionResult Login()
        {
            return Created("",new JwtToken.JwtGenerateToken().GenerateToken());
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace BlogPage.Api.Controllers
{
    [ApiController]
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        public async Task<IActionResult> List()
        {
            return View();
        }
    }
}

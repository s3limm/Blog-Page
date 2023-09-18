using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Controllers
{
	public class Credentials : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

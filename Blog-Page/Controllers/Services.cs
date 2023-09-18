using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Controllers
{
	public class Services : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

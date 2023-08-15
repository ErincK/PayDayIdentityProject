using Microsoft.AspNetCore.Mvc;
using PayDayIdentityProject.PresentationLayer.Models;

namespace PayDayIdentityProject.PresentationLayer.Controllers
{
	public class ConfirmMailController : Controller
	{
		[HttpGet]
		public IActionResult Index(int id)
		{
			var value = TempData["Mail"];
			ViewBag.v = value + " aa a";
			return View();
		}

		[HttpPost]
		public IActionResult Index(ConfirmMailViewModel confirmMailViewModel)
		{
			return View();
		}
	}
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayDayIdentityProject.EntityLayer.Concrete;
using PayDayIdentityProject.PresentationLayer.Models;

namespace PayDayIdentityProject.PresentationLayer.Controllers
{
	public class ConfirmMailController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
		public IActionResult Index()
		{
			var value = TempData["Mail"];
			ViewBag.v=value;
			//confirmMailViewModel.Mail = value.ToString();
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Index(ConfirmMailViewModel confirmMailViewModel)
		{
            var user = await _userManager.FindByEmailAsync(confirmMailViewModel.Mail);
			if (user.ConfirmCode == confirmMailViewModel.ConfirmCode)
			{
				user.EmailConfirmed = true;  // We need to set the new state of Email.
				await _userManager.UpdateAsync(user); // We need to Update the new state of "EmailConfirmed".
                return RedirectToAction("Index","Login");
			}
            return View();
		}
	}
}

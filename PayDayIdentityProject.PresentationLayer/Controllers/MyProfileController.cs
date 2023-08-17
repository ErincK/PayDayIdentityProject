using Microsoft.AspNetCore.Mvc;

namespace PayDayIdentityProject.PresentationLayer.Controllers
{
    public class MyProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

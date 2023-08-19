using Microsoft.AspNetCore.Mvc;

namespace PayDayIdentityProject.PresentationLayer.Controllers
{
    public class MyAccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

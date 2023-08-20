using Microsoft.AspNetCore.Mvc;

namespace PayDayIdentityProject.PresentationLayer.Controllers
{
    public class MyLastProcessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

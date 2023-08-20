using Microsoft.AspNetCore.Mvc;

namespace PayDayIdentityProject.PresentationLayer.Controllers
{
    public class CustomerLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

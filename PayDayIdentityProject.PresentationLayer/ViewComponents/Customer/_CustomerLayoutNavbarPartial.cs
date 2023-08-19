using Microsoft.AspNetCore.Mvc;

namespace PayDayIdentityProject.PresentationLayer.ViewComponents.Customer
{
    public class _CustomerLayoutNavbarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

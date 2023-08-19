using Microsoft.AspNetCore.Mvc;

namespace PayDayIdentityProject.PresentationLayer.ViewComponents.Customer
{
    public class _CustomerLayoutFooterPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace YummyWebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _NavbarAdminLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

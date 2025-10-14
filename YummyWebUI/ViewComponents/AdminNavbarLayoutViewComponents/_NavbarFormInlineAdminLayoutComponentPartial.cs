using Microsoft.AspNetCore.Mvc;

namespace YummyWebUI.ViewComponents.AdminNavbarLayoutViewComponents
{
    public class _NavbarFormInlineAdminLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

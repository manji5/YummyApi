using Microsoft.AspNetCore.Mvc;

namespace YummyWebUI.ViewComponents
{
    public class _NavbarDefaultPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

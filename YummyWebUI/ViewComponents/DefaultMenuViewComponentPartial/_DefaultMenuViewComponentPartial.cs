using Microsoft.AspNetCore.Mvc;

namespace YummyWebUI.ViewComponents.DefaultMenuViewComponents
{
    public class _DefaultMenuViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}

using Microsoft.AspNetCore.Mvc;

namespace YummyWebUI.ViewComponents
{
    public class _AboutDefaultPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

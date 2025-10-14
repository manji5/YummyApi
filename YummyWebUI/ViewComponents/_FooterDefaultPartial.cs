using Microsoft.AspNetCore.Mvc;

namespace YummyWebUI.ViewComponents
{
    public class _FooterDefaultPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

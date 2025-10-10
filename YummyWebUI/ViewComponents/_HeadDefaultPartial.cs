using Microsoft.AspNetCore.Mvc;

namespace YummyWebUI.ViewComponents
{
    public class _HeadDefaultPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

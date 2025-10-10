using Microsoft.AspNetCore.Mvc;

namespace YummyWebUI.ViewComponents
{
    public class _FeatureDefaultPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

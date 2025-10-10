using Microsoft.AspNetCore.Mvc;

namespace YummyWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

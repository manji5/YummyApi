using Microsoft.AspNetCore.Mvc;

namespace YummyWebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Luxifer.Controllers
{
    public class HelpCenterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

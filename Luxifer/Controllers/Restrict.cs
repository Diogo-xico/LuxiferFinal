using Luxifer.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Luxifer.Controllers
{
    [PaginaUserLogado]
    public class Restrict : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

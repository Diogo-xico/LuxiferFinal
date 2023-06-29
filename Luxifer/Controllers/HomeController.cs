using Luxifer.Filters;
using Luxifer.Helper;
using Luxifer.Models;
using Luxifer.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Luxifer.Controllers
{
    [PaginaUserLogado]

   
    public class HomeController : Controller
    {
        private readonly ILuminariaRepo _luminariaRepo;
        private readonly ISessao _sessao;
        public HomeController(ILuminariaRepo luminariaRepo, ISessao sessao)
        {
            _luminariaRepo = luminariaRepo;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            User userLoged = _sessao.ProcurarSessaoUser();
            List<Luminaria> luminarias = _luminariaRepo.ListarLuminarias(userLoged.Id);

            teste teste = new teste
            {
                User = userLoged,
                Luminarias = luminarias

            };
            return View(teste);
        }

        public IActionResult SiteInicial()
        {

            return View();
        }

        public IActionResult HelpCenter()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
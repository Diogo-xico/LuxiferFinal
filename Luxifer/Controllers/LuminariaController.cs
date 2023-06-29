using Luxifer.Filters;
using Luxifer.Helper;
using Luxifer.Models;
using Luxifer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Luxifer.Controllers
{
    [PaginaUserLogado]
    public class LuminariaController : Controller
    {
        private readonly ILuminariaRepo _luminariaRepo;
        private readonly ISessao _sessao;
        public LuminariaController(ILuminariaRepo luminariaRepo, ISessao sessao)
        {
            _luminariaRepo = luminariaRepo;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            User userLoged = _sessao.ProcurarSessaoUser();
            List<Luminaria> luminarias = _luminariaRepo.ListarLuminarias(userLoged.Id);
            return View(luminarias);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            Luminaria luminaria = _luminariaRepo.ListarPorId(id);
            return View(luminaria);
        }

        public IActionResult Delete(int id)
        {
            Luminaria luminaria = _luminariaRepo.ListarPorId(id);
            return View(luminaria);
        }

        public IActionResult DeleteFinal(int id)
        {
            _luminariaRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Luminaria luminaria = _luminariaRepo.ListarPorId(id);
            return View(luminaria);
        }



        [HttpPost]
        public IActionResult Create(Luminaria luminaria)
        {
         
            _luminariaRepo.Create(luminaria);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Luminaria luminaria)
        {
            User userLoged = _sessao.ProcurarSessaoUser();
            luminaria.UserId = userLoged.Id;

            _luminariaRepo.Edit(luminaria);
            return RedirectToAction("Index");
        }
    }
}


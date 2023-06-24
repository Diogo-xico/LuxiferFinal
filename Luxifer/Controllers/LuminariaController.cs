using Luxifer.Models;
using Luxifer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Luxifer.Controllers
{
    public class LuminariaController : Controller
    {
        private readonly ILuminariaRepo _luminariaRepo;
        public LuminariaController(ILuminariaRepo luminariaRepo)
        {
            _luminariaRepo = luminariaRepo;
        }
        public IActionResult Index()
        {
            List<Luminaria> luminarias = _luminariaRepo.ListarLuminarias();
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

        public IActionResult DeleteFinal(int id) {
            _luminariaRepo.Delete(id);
            return RedirectToAction("Index");
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
            _luminariaRepo.Edit(luminaria);
            return RedirectToAction("Index");
        }
    }
} 

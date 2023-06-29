using Luxifer.Filters;
using Luxifer.Helper;
using Luxifer.Models;
using Luxifer.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System;
using Luxifer.Migrations;

namespace Luxifer.Controllers
{
    [PaginaUserLogado]
    public class GruposController : Controller
    {
        private readonly IGrupoRepo _grupoRepo;
        private readonly ILuminariaRepo _luminariaRepo;
        private readonly ISessao _sessao;

        public GruposController(IGrupoRepo grupoRepo, ILuminariaRepo luminariaRepo, ISessao sessao)
        {
            _grupoRepo = grupoRepo;
            _luminariaRepo = luminariaRepo;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            User userLoged = _sessao.ProcurarSessaoUser();
            List<Grupo> grupos = _grupoRepo.ListarGrupos(userLoged.Id);

            return View(grupos);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {

            Grupo grupo = _grupoRepo.ListarPorId(id);

            List<Luminaria> luminarias = _luminariaRepo.ListarLuminariasPorGrupoId(id);

            MultipleModels multipleModels = new MultipleModels
            {
                Grupo = grupo,
                Luminarias = luminarias,
            };

            return View(multipleModels);
        }

        public IActionResult Edit(int id)
        {
            Grupo grupos = _grupoRepo.ListarPorId(id);
            return View(grupos);
        }

        public IActionResult Delete(int id)
        {
            Grupo grupo = _grupoRepo.ListarPorId(id);
            return View(grupo);
        }

        public IActionResult DeleteFinal(int id)
        {
            _grupoRepo.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(Grupo grupo)
        {
            User userLoged = _sessao.ProcurarSessaoUser();
            grupo.UserId = userLoged.Id;

            grupo = _grupoRepo.Create(grupo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Grupo grupo)
        {
            User userLoged = _sessao.ProcurarSessaoUser();
            grupo.UserId = userLoged.Id;

            grupo = _grupoRepo.Edit(grupo);
            return RedirectToAction("Index");
        }
    }
}
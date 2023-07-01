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
            try
            {
                if (ModelState.IsValid)
                {
                    _grupoRepo.Delete(id);
                    TempData["MensagemAdicionarSucesso"] = "Eliminado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(id);
            }
            catch (System.Exception)
            {
                TempData["MensagemEliminarSucesso"] = "Grupo não foi adicionado";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Create(Grupo grupo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User userLoged = _sessao.ProcurarSessaoUser();
                    grupo.UserId = userLoged.Id;

                    grupo = _grupoRepo.Create(grupo);
                    TempData["MensagemAdicionarSucesso"] = "Adicionado com sucesso";
                    return RedirectToAction("Index");

                }
                else
                {
                    User userLoged = _sessao.ProcurarSessaoUser();
                    grupo.UserId = userLoged.Id;

                    grupo = _grupoRepo.Create(grupo);
                    TempData["MensagemAdicionarSucesso"] = "Adicionado com sucesso";
                    return RedirectToAction("Index");
                }              
            }
            catch (System.Exception)
            {
                TempData["MensagemEliminarSucesso"] = "Grupo não foi adicionado";
                return RedirectToAction("Index");
            }
        }

         [HttpPost]
        public IActionResult Edit(Grupo grupo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User userLoged = _sessao.ProcurarSessaoUser();
                    grupo.UserId = userLoged.Id;

                    grupo = _grupoRepo.Edit(grupo);
                    TempData["MensagemAdicionarSucesso"] = "Editado com sucesso";
                    return RedirectToAction("Index");
                }
                else
                {
                    User userLoged = _sessao.ProcurarSessaoUser();
                    grupo.UserId = userLoged.Id;

                    grupo = _grupoRepo.Edit(grupo);
                    TempData["MensagemAdicionarSucesso"] = "Editado com sucesso";
                    return RedirectToAction("Index");
                }
              
             }
            catch(System.Exception)
            {
                TempData["MensagemAdicionarSucesso"] = "Grupo não foi Editado";
                return RedirectToAction("Index");
            }

        }
    }
}
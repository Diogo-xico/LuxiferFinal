using Luxifer.Filters;
using Luxifer.Helper;
using Luxifer.Models;
using Luxifer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Luxifer.Controllers
{
    
    [PaginaRestritaAdmin]
    public class UserController : Controller
    {
        private readonly IUserRepo _userRepo;
        private readonly ISessao _sessao;
        private readonly ILuminariaRepo _luminariaRepo;
        public UserController(ILuminariaRepo luminariaRepo, ISessao sessao, IUserRepo userRepo)
        {
            _luminariaRepo = luminariaRepo;
            _sessao = sessao;
            _userRepo = userRepo;
        }
      
        public IActionResult Index()
        {
            List<User> users = _userRepo.ListarUsers();
            return View(users);
        }

        public async Task<IActionResult> Details(int id)
        {
            User user = _userRepo.ListarPorId(id);
            List<Luminaria> luminarias = _luminariaRepo.ListarLuminarias(id);

            teste teste = new teste
            {
                User = user,
                Luminarias = luminarias

            };

            return View(teste);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            User user = _userRepo.ListarPorId(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepo.Create(user);
                    TempData["MensagemAdicionarSucesso"] = "Adicionado com sucesso";
                    return RedirectToAction("Index");
                }
                else
                {
                    _userRepo.Create(user);
                    TempData["MensagemAdicionarSucesso"] = "Adicionado com sucesso";
                    return RedirectToAction("Index");
                }
                
            }
            catch (Exception)
            {
                TempData["MensagemErro"] = "Luminaria não foi guardada";
                return RedirectToAction("Index");
            }

        }

        public IActionResult Delete(int id)
        {
            User user = _userRepo.ListarPorId(id);
            return View(user);
        }

        public IActionResult DeleteFinal(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepo.Delete(id);
                    TempData["MensagemEliminarSucesso"] = "Eliminado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(id);
            }
            catch (System.Exception)
            {
                TempData["MensagemEliminarSucesso"] = "Luminaria não foi guardada";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(UserSemPassword userSemPassword)
        {
            User user = null;
            user = new User()
            {
                Id = userSemPassword.Id,
                Nome = userSemPassword.Nome,
                Login = userSemPassword.Login,
                Email = userSemPassword.Email,
                Perfil = userSemPassword.Perfil
            };
           
            _userRepo.Edit(user);
            return RedirectToAction("Index");
        }
    }
}


using Luxifer.Helper;
using Luxifer.Models;
using Luxifer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Luxifer.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepo _userRepositorio;
        private readonly ISessao _sessao;
        public LoginController(IUserRepo userRepositorio, ISessao sessao) {
            _userRepositorio = userRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
         
            if (_sessao.ProcurarSessaoUser() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.SairSessaoUser();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(Login loginModel)
        {
            try
            {

                User user = _userRepositorio.ProcurarLogin(loginModel.Email);

                if (ModelState.IsValid)
                {
                    if(user != null)
                    {
                        if (user.PasswordValida(loginModel.Password)) {
                            _sessao.CriarSessaoUser(user);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["Erro"] = $"Dados Inválidos";                      
                    }
                    TempData["Erro"] = $"Dados Inválidos";
                }

                return View("Index");
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}

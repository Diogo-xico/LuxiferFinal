using Luxifer.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Luxifer.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public User ProcurarSessaoUser()
        {
            string sessaoUser = _httpContext.HttpContext.Session.GetString("sessaoUserLogado");

            if (string.IsNullOrEmpty(sessaoUser)) return null;

            return JsonConvert.DeserializeObject<User>(sessaoUser);
        }

        public void CriarSessaoUser(User user)
        {
            string valor = JsonConvert.SerializeObject(user);
            _httpContext.HttpContext.Session.SetString("sessaoUserLogado", valor);
        }

        public void SairSessaoUser()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUserLogado");
        }
    }
}

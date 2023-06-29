using Luxifer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace Luxifer.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUser = HttpContext.Session.GetString("sessaoUserLogado");

            if (string.IsNullOrEmpty(sessaoUser)) return null;

            User user = JsonConvert.DeserializeObject<User>(sessaoUser);

            return View(user);
        }
    }
}

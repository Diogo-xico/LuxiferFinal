using Luxifer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Luxifer.Filters
{
    public class PaginaUserLogado : ActionFilterAttribute
    {
        //Antes de ir para os controllers faz as verificações que deve fazer, se está logado ou as roles que ele tem para ter acesso às páginas
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoUser = context.HttpContext.Session.GetString("sessaoUserLogado");

            if(string.IsNullOrEmpty(sessaoUser) )
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }
            else
            {
                User user = JsonConvert.DeserializeObject<User>(sessaoUser);

                if(user == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }
                
            }

            base.OnActionExecuting(context);
        }
    }
}

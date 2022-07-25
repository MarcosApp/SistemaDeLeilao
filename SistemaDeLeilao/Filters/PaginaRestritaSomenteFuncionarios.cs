using SistemaDeLeilao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace SistemaDeLeilao.Filters
{
    public class PaginaRestritaSomenteFuncionarios : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoEmbarcadores = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoEmbarcadores))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }
            else
            {
                UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoEmbarcadores);

                if(usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }

                if( !(usuario.Perfil == Enums.PerfilEnum.Funcionario || usuario.Perfil == Enums.PerfilEnum.Admin) )
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restrito" }, { "action", "Index" } });
                }
            }

            base.OnActionExecuting(context);
        }
    }
}

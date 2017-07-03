using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EstoqueSimples.Filtros
{
    public class AutorizacaoFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Object usuarioLogado =  filterContext.HttpContext.Session["UsuarioLogado"];
            if (usuarioLogado == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { action="Login",controller="Home"}));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
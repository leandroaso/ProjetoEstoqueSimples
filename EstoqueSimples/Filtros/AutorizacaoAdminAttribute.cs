using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EstoqueSimples.Filtros
{
    public class AutorizacaoAdminAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Object Admin = filterContext.HttpContext.Session["UsuarioLogadoAdmin"];
            if (Admin == null)
            {
                if (Admin.Equals(false))
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new { action = "Index", controller = "Home" }));
                }
            }
            
            base.OnActionExecuting(filterContext);
        }
    }
}
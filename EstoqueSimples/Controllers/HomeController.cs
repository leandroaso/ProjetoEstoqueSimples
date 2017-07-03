using EstoqueSimples.DAO;
using EstoqueSimples.Filtros;
using EstoqueSimples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstoqueSimples.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [AutorizacaoFilter]
        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Login");
        }

        public ActionResult AutenticaUsuario(string Login, string Senha)
        {
            UsuarioDao dao = new UsuarioDao();
            Usuario usuario = dao.AutenticaUsuario(Login, Senha);
            if (usuario !=null)
            {
                Session["UsuarioLogadoNome"] = usuario.Nome; 
                Session["UsuarioLogadoId"] = usuario.ID;
                Session["UsuarioLogado"] = usuario;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

    }
}
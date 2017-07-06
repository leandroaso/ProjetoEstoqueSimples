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
    [AutorizacaoFilter, AutorizacaoAdmin]
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            UsuarioDao dao = new UsuarioDao();

            ViewBag.Menu = "usuario";
            ViewBag.Title = "Usuarios";

            ViewBag.Usuarios = dao.List();

            return View();
        }

        public ActionResult Novo (int id = 0)
        {
            Usuario usuario;
            if (id.Equals(null) || id.Equals(0))
            {
                usuario = new Usuario();
            }
            else
            {
                UsuarioDao dao = new UsuarioDao();
                usuario = dao.Find(id);
            }

            ViewBag.Menu = "usuario";
            ViewBag.Title = "Novo Usuario";
            ViewBag.Usuario = usuario;

            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Cadastro(Usuario usuario)
        {
            UsuarioDao dao = new UsuarioDao();
            if (usuario.ID.Equals(0) || usuario.ID.Equals(null) )
            {
                dao.Insert(usuario);
            }
            else
            {
                dao.Update(usuario);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            UsuarioDao dao = new UsuarioDao();
            dao.DeleteById(id);

            return Json(id);
        }
    }
}
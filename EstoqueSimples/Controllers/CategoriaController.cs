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
    [AutorizacaoFilter,AutorizacaoAdmin]
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            ViewBag.Menu = "categoria";
            ViewBag.Title = "Categorias";

            CategoriaDao dao = new CategoriaDao();
            ViewBag.Categorias = dao.List();

            return View();
        }

        public ActionResult Novo(int id =0)
        {

            ViewBag.Menu = "categoria";
            ViewBag.Title = "Nova Categoria";
            Categoria categoria;
            if (id.Equals(null) || id.Equals(0))
            {
                categoria = new Categoria();
            }
            else
            {
                CategoriaDao dao = new CategoriaDao();
                categoria = dao.Find(id);
            }
            ViewBag.Categoria = categoria;

            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Cadastro(Categoria categoria)
        {
            CategoriaDao dao = new CategoriaDao();
            if (categoria.ID.Equals(null) || categoria.ID.Equals(0))
            {
                dao.Insert(categoria);
            }
            else
            {
                dao.Update(categoria);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id )
        {
            CategoriaDao dao = new CategoriaDao();
            dao.DeleteById(id);
            return Json(id);
        }
    }
}
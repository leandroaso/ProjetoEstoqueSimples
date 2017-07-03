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
    [AutorizacaoFilter]
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Menu = "produto";
            ViewBag.Title = "Produtos";

            ProdutoDao produtoDao = new ProdutoDao();
            ViewBag.Produtos = produtoDao.List();
            return View();
        }

        public ActionResult Novo(int id=0)
        {
            Produto produto;

            if (id.Equals(null) || id.Equals(0))
            {
                produto = new Produto();
            }
            else
            {
                ProdutoDao dao = new ProdutoDao();
                produto = dao.Find(id);
            }

            ViewBag.Produto = produto;
            ViewBag.Menu = "produto";
            ViewBag.Title = "Novo Produto";

            CategoriaDao categoriaDao = new CategoriaDao();
            ViewBag.Categorias = categoriaDao.List();

            return View();
        }

        public ActionResult Cadastro(Produto produto)
        {
            ProdutoDao dao = new ProdutoDao();

            if (produto.ID.Equals(null) || produto.ID.Equals(0))
            {
                dao.Insert(produto);
                return RedirectToAction("Index");
            }
            else
            {
                dao.Update(produto);
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult Mais(int id)
        {
            ProdutoDao dao = new ProdutoDao();
            Produto produto = dao.Find(id);
            produto.Quantidade ++;
            dao.Update(produto);

            return Json(produto);
        }

        public ActionResult Menos(int id)
        {
            ProdutoDao dao = new ProdutoDao();
            Produto produto = dao.Find(id);
            produto.Quantidade --;
            dao.Update(produto);

            return Json(produto);
        }

        public ActionResult Remove(int id)
        {
            ProdutoDao dao = new ProdutoDao();
            dao.DeleteById(id);

            return Json(id);
        }
    }
}
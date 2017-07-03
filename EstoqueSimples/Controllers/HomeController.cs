using EstoqueSimples.DAO;
using EstoqueSimples.Filtros;
using EstoqueSimples.Models;
using Microsoft.Data.Entity;
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
            string nome = Request.QueryString["nome"];
            string nomeCategoria = Request.QueryString["nomeCategoria"];
            string qtdMim = Request.QueryString["qtdMim"];
            string qtdMax = Request.QueryString["qtdMax"];

            EstoqueContext contexto = new EstoqueContext();
            var busca = from p in contexto.Produtos.Include(p => p.Categoria) select p ;

            if (!String.IsNullOrEmpty(nome))
            {
                busca = busca.Where(p => p.Nome == nome);
            }
            if (!String.IsNullOrEmpty(nomeCategoria))
            {
                busca = busca.Where(p => p.Categoria.Nome == nomeCategoria);

            }
            if (!String.IsNullOrEmpty(qtdMim))
            {
                busca = busca.Where(p => p.Quantidade >= Convert.ToInt32(qtdMim));
            }
            if (!String.IsNullOrEmpty(qtdMax))
            {
                busca = busca.Where(p => p.Quantidade <= Convert.ToInt32(qtdMax));

            }

            ViewBag.Produtos = busca.ToList();

            CategoriaDao categoriaDao = new CategoriaDao();
            ViewBag.Categorias = categoriaDao.List();
            //string Nome, string categoria, int qtdMin = 0, int qtdMax = 999999
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
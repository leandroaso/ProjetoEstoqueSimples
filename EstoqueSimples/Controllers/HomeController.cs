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

            ProdutoDao produtoDao = new ProdutoDao();

            ViewBag.Produtos = produtoDao.BuscaPorNomeNomeCategoriaQtdMinQtdMax(nome,nomeCategoria,qtdMim,qtdMax);

            CategoriaDao categoriaDao = new CategoriaDao();
            ViewBag.Categorias = categoriaDao.List();
            //string Nome, string categoria, int qtdMin = 0, int qtdMax = 999999
            ViewBag.Title = "Home";
            return View();
        }

        public ActionResult Login(string Login=null,string Senha=null)
        {


            UsuarioDao dao;
            if (!String.IsNullOrEmpty(Login) || !String.IsNullOrEmpty(Senha))
            {
                dao = new UsuarioDao();
                Usuario usuario = dao.AutenticaUsuario(Login, Senha);

                if (usuario != null)
                {
                    Session["UsuarioLogadoNome"] = usuario.Nome;
                    Session["UsuarioLogado"] = usuario;
                    Session["UsuarioLogadoId"] = usuario.ID;
                    Session["UsuarioLogadoAdmin"] = usuario.Admin;


                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Erro = true;
                    return View();
                }
            }
            ViewBag.Erro = false;
            return View();

        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Login");
        }

        [AutorizacaoFilter]
        public ActionResult Editar()
        {
            Object id = Session["UsuarioLogadoId"];
            UsuarioDao dao = new UsuarioDao();
            ViewBag.Usuario = dao.Find(Convert.ToInt32(id));

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditarPerfil(Usuario usuario)
        {
            UsuarioDao dao = new UsuarioDao();
            dao.Update(usuario);
            return Json(usuario);
        }
    }
}
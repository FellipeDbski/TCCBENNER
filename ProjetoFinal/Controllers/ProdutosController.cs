using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoFinal.Models;
using ProjetoFinal.DAO;

namespace ProjetoFinal.Controllers
{
    public class ProdutosController : Controller
    {
      public ActionResult Index()
        {
            ProdutosDAO dao = new ProdutosDAO();
            IList<Produtos> produtos = dao.Lista();
            ViewBag.Produtos = produtos;
            return View();
        }

        public ActionResult Form()
        {
            CategoriaDAO CategoriasDAO = new CategoriaDAO();
            IList<Categoria> categorias = CategoriasDAO.Lista();
            ViewBag.Categorias = categorias;
            return View();
        }

        public ActionResult Remove(int id)
        {
            Usuario usuario = (Usuario)Session["usuarioLogado"];
            if(usuario.TipoUsuario != "Administrador")
            {
                return RedirectToAction("AcessoNegado", "Usuarios");
            }

            else
            { 
            Produtos produto = new ProdutosDAO().BuscaPorId(id);
            ProdutosDAO dao = new ProdutosDAO();
            dao.Remove(produto);
               return Json(new { });
            }
        }

        public ActionResult Adiciona(Produtos produto)
        {
            ProdutosDAO dao = new ProdutosDAO();
            dao.Adiciona(produto);

            return RedirectToAction("Index", "Produtos");
        }

        public ActionResult Modal(int id)
        {
            Produtos produto = new ProdutosDAO().BuscaPorId(id);
            var descricao = produto.Descricao;

            return Json(new {descricao});
        }

        public ActionResult Editar(int id)
        {
            Produtos produtoBusca = new ProdutosDAO().BuscaPorId(id);
            CategoriaDAO CategoriasDAO = new CategoriaDAO();
            IList<Categoria> categorias = CategoriasDAO.Lista();           

            ViewBag.Categorias = categorias;
            ViewBag.Produto = produtoBusca;

            return View(produtoBusca);     
        }


        public ActionResult Atualiza(Produtos produto)
        {
            ProdutosDAO dao = new ProdutosDAO();
            dao.Atualiza(produto);

            
            return RedirectToAction("Index");
        }

    }

}

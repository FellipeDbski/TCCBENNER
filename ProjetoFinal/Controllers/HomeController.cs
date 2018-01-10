using ProjetoFinal.DAO;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoFinal.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            VendasDAO vendaDAO = new VendasDAO();
            IList<Venda> vendas = vendaDAO.Lista();
            
            ViewBag.Vendas = vendas;
            
             
            return View();
        }

        [HttpPost]
        public ActionResult Modal(int id)
        {
            Venda venda = new VendasDAO().BuscaPorId(id);
            ViewBag.Produtos = venda.Produtos;

            var arrayDeNomes = venda.Produtos.Select(p => p.Produto).ToArray();

            return Json(new { nomes = arrayDeNomes });
        }
    }
}
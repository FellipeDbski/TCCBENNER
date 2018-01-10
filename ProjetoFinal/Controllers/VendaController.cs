using ProjetoFinal.DAO;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoFinal.Controllers
{
    public class VendaController : Controller
    {
        public ActionResult Form()
        {
            if(Session["Lista"] == null)
            {
                Session["Lista"] = new List<Produtos>();
            }

            VendedorDAO VendedoresDAO = new VendedorDAO();
            IList<Vendedores> vendedor = VendedoresDAO.Lista();
            ViewBag.Vendedores = vendedor;

            FormaDePagamentoDAO daoPagamento = new FormaDePagamentoDAO();
            IList<FormaDePagamento> opcoes = daoPagamento.Lista();
            ViewBag.FormasPagamento = opcoes;

            return View();
        }


        [HttpPost]
        public ActionResult AddProduto(int id, int qtd)
        {
            List<Produtos> ListaLocal = ((List<Produtos>)Session["Lista"]);

            Produtos produto = new ProdutosDAO().BuscaPorId(id);


            ListaLocal.Add(produto);
            return Json(new { produto.Nome, produto.Valor, produto.Quantidade });
        }

        public ActionResult Remove(int id)
        {
            Venda venda = new VendasDAO().BuscaPorId(id);
            VendasDAO dao = new VendasDAO();
            dao.Remove(venda);

            return Json(new { });
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult NovaVenda(Venda venda)
        {
            List<Produtos> ListaLocal = ((List<Produtos>)Session["Lista"]);
            VendasDAO dao = new VendasDAO();
            dao.Adiciona(venda);

            ProdutoVendaDAO daop = new ProdutoVendaDAO();
            ProdutoVenda vendaProdutos = new ProdutoVenda();

            vendaProdutos.VendaID = venda.ID;

            foreach (var produto in ListaLocal)
            {
                vendaProdutos.ProdutoID = produto.ID;
                vendaProdutos.Quantidade = produto.Quantidade;
                venda.Total += produto.Valor * produto.Quantidade;


                Produtos produtoRemove = new ProdutosDAO().BuscaPorId(produto.ID);
                produtoRemove.Quantidade -= produto.Quantidade;
                ProdutosDAO daoqtd = new ProdutosDAO();
                daoqtd.Atualiza(produtoRemove);

                venda.Quantidade = produto.Quantidade;
                daop.Adiciona(vendaProdutos);
            }

            Vendedores vendedor = new VendedorDAO().BuscaPorId(venda.VendedorID.Value);
            vendedor.TotalVendido += venda.Total;
            VendedorDAO daov = new VendedorDAO();
            daov.Atualiza(vendedor);


            dao.Atualiza(venda);
            Session.Remove("Lista");
            return RedirectToAction("Form"); 
        }
    }
}
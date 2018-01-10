using ProjetoFinal.DAO;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoFinal.Controllers
{
    public class VendedorController : Controller
    {   
        public ActionResult Index()
        {
            VendedorDAO dao = new VendedorDAO();
            IList<Vendedores> vendedores = dao.Lista();
            ViewBag.Vendedores = vendedores;

            return View();
        }

        public ActionResult Form()
        {
            
            return View();
        }

        public ActionResult Adiciona(Vendedores vendedor)
        {
            VendedorDAO dao = new VendedorDAO();
            dao.Adiciona(vendedor);


            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            Usuario usuario = (Usuario)Session["usuarioLogado"];
            if (usuario.TipoUsuario != "Administrador")
            {
                return View("AcessoNegado", "Usuarios");
            }

            else
            {
                Vendedores vendedor = new VendedorDAO().BuscaPorId(id);
                VendedorDAO dao = new VendedorDAO();
                dao.Remove(vendedor);

                return Json(new { });
            }
        }

        public ActionResult Editar(int id)
        {
            Vendedores vendedor = new VendedorDAO().BuscaPorId(id);
            ViewBag.Vendedor = vendedor;

            return View(vendedor);
        } 

        public ActionResult Atualiza(Vendedores vendedor)
        {
            VendedorDAO dao = new VendedorDAO();
            dao.Atualiza(vendedor);

            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoFinal.Models;
using ProjetoFinal.DAO;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Filtros;

namespace ProjetoFinal.Controllers
{
    public class ClientesController : Controller
    {
        public ActionResult Index()
        {
            ClienteDAO dao = new ClienteDAO();
            IList<Cliente> cliente = dao.Lista();
            ViewBag.Clientes = cliente;

            return View();
        }

        public ActionResult Form()
        {

            return View();
        }


        public ActionResult Adiciona(Cliente cliente)
        {
            ClienteDAO dao = new ClienteDAO();
            dao.Adiciona(cliente);

            return RedirectToAction("Index", "Clientes");
        }

        public ActionResult Remove(int id)
        {
            Usuario usuario = (Usuario)Session["usuarioLogado"];
            if (usuario.TipoUsuario != "Administrador")
            {
                return RedirectToAction("AcessoNegado", "Usuarios");
            }

            else
            {
                Cliente cliente = new ClienteDAO().BuscaPorId(id);
                ClienteDAO dao = new ClienteDAO();
                dao.Remove(cliente);


                return Json(new { });
            }
        }

        public ActionResult Editar(int id)
        {
            Usuario usuario = (Usuario)Session["usuarioLogado"];
            if (usuario.TipoUsuario != "Administrador")
            {
                return RedirectToAction("AcessoNegado", "Usuarios");
            }

            else
            {
                Cliente cliente = new ClienteDAO().BuscaPorId(id);
                ViewBag.Cliente = cliente;

                return View(cliente);
            }
        }

        public ActionResult Atualiza(Cliente cliente)
        {
            ClienteDAO dao = new ClienteDAO();
            dao.Atualiza(cliente);

            return RedirectToAction("Index");
        }
    }
}

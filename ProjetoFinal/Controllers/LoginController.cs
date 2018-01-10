using ProjetoFinal.DAO;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoFinal.Controllers
{
    public class LoginController : Controller, INoAuthRequired
    {
     
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentica(String login, String senha)
        {
            UsuarioDAO dao = new UsuarioDAO();
            Usuario usuario = dao.Busca(login, senha);
            if(usuario != null)
            {
                Session["usuarioLogado"] = usuario;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Sair()
        {
            Session.Remove("usuarioLogado");

            return RedirectToAction("Index", "Login");
        }
    }
}
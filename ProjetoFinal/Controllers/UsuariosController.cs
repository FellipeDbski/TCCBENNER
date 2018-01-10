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

namespace ProjetoFinal.Controllers
{
    public class UsuariosController : Controller
    {
        public ActionResult Form()
        {
            return View();
        }

        public ActionResult AcessoNegado()
        {
            return View("AcessoNegado");
        }
    }
}

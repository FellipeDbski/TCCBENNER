using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.DAO
{
    public class ProdutoVendaDAO
    {
        public void Adiciona(ProdutoVenda pVenda)
        {
            using (var context = new ProjetoFinalContext())
            {
                context.ProdutoVenda.Add(pVenda);
                context.SaveChanges();
            }
        }

        public IList<ProdutoVenda> Lista()
        {
            using (var contexto = new ProjetoFinalContext())
            {
                return contexto.ProdutoVenda.ToList();
            }
        }

        public void Atualiza(ProdutoVenda pVenda)
        {
            using (var contexto = new ProjetoFinalContext())
            {
                contexto.Entry(pVenda).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}
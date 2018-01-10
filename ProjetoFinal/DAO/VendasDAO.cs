using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.DAO
{
    public class VendasDAO
    {
        public void Adiciona(Venda venda)
        {
            using (var context = new ProjetoFinalContext())
            {
                context.Venda.Add(venda);
                context.SaveChanges();
            }
        }

        public void Remove (Venda venda)
        {
            using (var contexto = new ProjetoFinalContext())
            {
                contexto.Venda.Remove(venda);
                contexto.SaveChanges();
            }
        }

        public IList<Venda> Lista()
        {
            using (var contexto = new ProjetoFinalContext())
            {
                return contexto
                    .Venda.Include("FormaDePagamento")
                    .Include("Cliente")
                    .Include("Vendedor")
                    .ToList();
            }
        }

        public Venda BuscaPorId(int id)
        {
            using (var contexto = new ProjetoFinalContext())
            {
                return contexto.Venda.Include(v => v.Produtos).ThenInclude(pv => pv.Produto).FirstOrDefault(v => v.ID == id);
            }
        }

        public void Atualiza(Venda venda)
        {
            using (var contexto = new ProjetoFinalContext())
            {
                contexto.Entry(venda).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.DAO
{
    public class VendedorDAO
    {
        public void Adiciona(Vendedores vendedor)
        {
            using (var context = new ProjetoFinalContext())
            {
                context.Vendedores.Add(vendedor);
                context.SaveChanges();
            }
        }

        public void Remove(Vendedores vendedor)
        {
            using (var contexto = new ProjetoFinalContext())
            {
                contexto.Vendedores.Remove(vendedor);
                contexto.SaveChanges();
            }
        }

        public IList<Vendedores> Lista()
        {
            using (var contexto = new ProjetoFinalContext())
            {
                return contexto.Vendedores.ToList();
            }
        }

        public Vendedores BuscaPorId(int id)
        {
            using (var contexto = new ProjetoFinalContext())
            {
                return contexto.Vendedores.Find(id);
            }
        }

        public void Atualiza(Vendedores vendedor)
        {
            using (var contexto = new ProjetoFinalContext())
            {
                contexto.Entry(vendedor).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}
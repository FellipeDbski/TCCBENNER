using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.DAO
{
    public class ProdutosDAO
    {
        public void Adiciona(Produtos produto)
        {
            using (var context = new ProjetoFinalContext())
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
            }
        }

        public void Remove(Produtos produto)
        {
            using (var context = new ProjetoFinalContext())
            {
                context.Produtos.Remove(produto);
                context.SaveChanges();
            }
        }

        public IList<Produtos> Lista()
        {
            using (var contexto = new ProjetoFinalContext())
            {
                return contexto.Produtos.Include("Categoria").ToList();
            }
        }

        public Produtos BuscaPorId(int id)
        {
            using (var contexto = new ProjetoFinalContext())
            {
                return contexto.Produtos.Include("Categoria")
                    .Where(p => p.ID == id)
                    .FirstOrDefault();
            }
        }

        public void Atualiza(Produtos produto)
        {
            using (var contexto = new ProjetoFinalContext())
            {
                contexto.Entry(produto).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}
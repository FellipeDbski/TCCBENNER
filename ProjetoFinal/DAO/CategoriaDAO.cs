using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.DAO
{
    public class CategoriaDAO
    {
        public class ProdutosDAO
        {
            public void Adiciona(Categoria categoria)
            {
                using (var context = new ProjetoFinalContext())
                {
                    context.Categorias.Add(categoria);
                    context.SaveChanges();
                }
            }

            public Categoria BuscaPorId(int id)
            {
                using (var contexto = new ProjetoFinalContext())
                {
                    return contexto.Categorias.Find(id);
                }
            }

            public void Atualiza(Categoria categoria)
            {
                using (var contexto = new ProjetoFinalContext())
                {
                    contexto.Entry(categoria).State = EntityState.Modified;
                    contexto.SaveChanges();
                }
            }
        }

        internal IList<Categoria> Lista()
        {
            using (var contexto = new ProjetoFinalContext())
            {
                return contexto.Categorias.ToList();
            }
        }
    }
}
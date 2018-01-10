using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.DAO
{
    public class ClienteDAO
    {
        public void Adiciona(Cliente cliente)
        {
            using (var context = new ProjetoFinalContext())
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
            }
        }

        public void Remove(Cliente cliente)
        {
            using (var context = new ProjetoFinalContext())
            {
                context.Clientes.Remove(cliente);
                context.SaveChanges();
            }
        }


        public Cliente BuscaPorId(int id)
        {
            using (var contexto = new ProjetoFinalContext())
            {
                return contexto.Clientes.Find(id);
            }
        }

        public IList<Cliente> Lista()
        {
            using (var contexto = new ProjetoFinalContext())
            {
                return contexto.Clientes.ToList();
            }
        }

        public void Atualiza(Cliente cliente)
        {
            using (var contexto = new ProjetoFinalContext())
            {
                contexto.Entry(cliente).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}
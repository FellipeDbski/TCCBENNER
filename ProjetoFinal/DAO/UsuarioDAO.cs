using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.DAO
{
    public class UsuarioDAO
    {
        public void Adiciona(Usuario usuario)
        {
            using (var context = new ProjetoFinalContext())
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }
        }

        public IList<Usuario> Lista()
        {
            using (var contexto = new ProjetoFinalContext())
            {
                return contexto.Usuarios.ToList();
            }
        }

        public Usuario BuscaPorId(int id)
        {
            using (var contexto = new ProjetoFinalContext())
            {
                return contexto.Usuarios.Find(id);
            }
        }

        public void Atualiza(Usuario usuario)
        {
            using (var contexto = new ProjetoFinalContext())
            {
                contexto.Entry(usuario).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public Usuario Busca(string login, string senha)
        {
            using (var contexto = new ProjetoFinalContext())
            {
                return contexto.Usuarios.FirstOrDefault(u => u.Nome == login && u.Senha == senha);
            }
        }
    }
}
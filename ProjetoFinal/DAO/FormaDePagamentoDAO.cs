using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.DAO
{
    public class FormaDePagamentoDAO
    {
        public void Adiciona(FormaDePagamento pagamento)
        {
            using (var context = new ProjetoFinalContext())
            {
                context.FormaDePagamento.Add(pagamento);
                context.SaveChanges();
            }
        }

        public IList<FormaDePagamento> Lista()
        {
            using (var contexto = new ProjetoFinalContext())
            {
                return contexto.FormaDePagamento.ToList();
            }
        }

        public FormaDePagamento BuscaPorId(int id)
        {
            using (var contexto = new ProjetoFinalContext())
            {
                return contexto.FormaDePagamento.Find(id);
            }
        }

        public void Atualiza(FormaDePagamento pagamento)
        {
            using (var contexto = new ProjetoFinalContext())
            {
                contexto.Entry(pagamento).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}
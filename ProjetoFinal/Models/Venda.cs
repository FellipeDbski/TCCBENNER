using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class Venda
    {
        public int ID { get; set; }

        public Cliente Cliente { get; set; }
        
        [Required]
        public int? ClienteID { get; set; }
        
        [Required]
        public IList<ProdutoVenda> Produtos { get; set; }

        public int Quantidade{ get; set; }
        
        public FormaDePagamento FormaDePagamento { get; set; }

        public int? FormaDePagamentoID { get; set; }

        public DateTime Data { get; set; } = DateTime.Now;

        public Vendedores Vendedor { get; set; }

        public int? VendedorID { get; set; }

        public double Total { get; set; }

    }
}
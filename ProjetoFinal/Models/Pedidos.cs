using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class Pedidos
    {
        public int ID { get; set; }

        public Produtos Produto { get; set; }

        public int ProdutosID { get; set; }

        public int Quantidade { get; set; }

        public float Valor { get; set; }

        public int StatusID { get; set; }

        public DateTime DataInicial { get; set; }

        public DateTime DataVencimento { get; set; }
    }
}
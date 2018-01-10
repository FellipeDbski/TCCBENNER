using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class ProdutoVenda
    {
        public Venda Venda { get; set; }

        public int VendaID { get; set; }

        public Produtos Produto { get; set; }

        public int ProdutoID { get; set; }

        public int Quantidade { get; set; }
    }
}
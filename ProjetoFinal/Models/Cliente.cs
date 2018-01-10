using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class Cliente
    {
        public int? ID { get; set; }

        public string CPF { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public string Telefone { get; set; }

        public GeneroEnum Genero { get; set; }

        public string Cidade { get; set; }

        public string Bairro { get; set; }

        public string Rua { get; set; }
    }
}
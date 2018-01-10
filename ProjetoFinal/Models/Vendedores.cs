using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class Vendedores
    {
        public int? ID { get; set; }

        public string Nome { get; set; }

        public GeneroEnum Genero { get; set; }

        public TurnoEnum Turno { get; set; }

        public double TotalVendido {get; set;}
    }
}
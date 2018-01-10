using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class Produtos
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        [Required]
        public string Marca { get; set; }

        public string Tamanho { get; set; }

        public string Descricao { get; set; }

        public Categoria Categoria { get; set; }

        [Required]
        public int? CategoriaID { get; set; }

        [Required]
        public int Quantidade { get; set;}

        [Required]
        public double Valor { get; set; }

    }
}
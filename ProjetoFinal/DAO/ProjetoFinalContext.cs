using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ProjetoFinal.DAO
{
    public class ProjetoFinalContext : DbContext
    { 
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<FormaDePagamento> FormaDePagamento { get; set; }

        public DbSet<Pedidos> Pedidos { get; set; }

        public DbSet<Produtos> Produtos { get; set; }

        public DbSet<ProdutoVenda> ProdutoVenda { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Venda> Venda { get; set; }

        public DbSet<Vendedores> Vendedores { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["ProjetoFinalContext"].ConnectionString;
            optionsBuilder.UseSqlServer(stringConexao);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoVenda>()
                .HasKey(pv => new { pv.VendaID, pv.ProdutoID });
            base.OnModelCreating(modelBuilder);
        }
    }
}

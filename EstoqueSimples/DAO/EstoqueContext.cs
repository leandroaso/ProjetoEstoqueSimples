using EstoqueSimples.Models;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EstoqueSimples.DAO
{
    public class EstoqueContext :DbContext
    {
        
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conexaoString = ConfigurationManager.ConnectionStrings["EstoqueConnectionString"].ConnectionString; ;
            optionsBuilder.UseSqlServer(conexaoString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using EstoqueSimples.DAO;

namespace EstoqueSimples.Migrations
{
    [DbContext(typeof(EstoqueContext))]
    [Migration("20170702154744_criaUsuarioProdutoCategoria")]
    partial class criaUsuarioProdutoCategoria
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }
    }
}

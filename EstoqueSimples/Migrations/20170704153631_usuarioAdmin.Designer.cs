using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using EstoqueSimples.DAO;

namespace EstoqueSimples.Migrations
{
    [DbContext(typeof(EstoqueContext))]
    [Migration("20170704153631_usuarioAdmin")]
    partial class usuarioAdmin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EstoqueSimples.Models.Categoria", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("EstoqueSimples.Models.Produto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoriaId");

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.Property<int>("Quantidade");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("EstoqueSimples.Models.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Admin");

                    b.Property<string>("Login");

                    b.Property<string>("Nome");

                    b.Property<string>("Senha");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("EstoqueSimples.Models.Produto", b =>
                {
                    b.HasOne("EstoqueSimples.Models.Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId");
                });
        }
    }
}

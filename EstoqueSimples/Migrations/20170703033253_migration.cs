using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace EstoqueSimples.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Produto_Categoria_CategoriaId", table: "Produto");
            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "Produto",
                nullable: false);
            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Categoria_CategoriaId",
                table: "Produto",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Produto_Categoria_CategoriaId", table: "Produto");
            migrationBuilder.AlterColumn<string>(
                name: "Quantidade",
                table: "Produto",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Categoria_CategoriaId",
                table: "Produto",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

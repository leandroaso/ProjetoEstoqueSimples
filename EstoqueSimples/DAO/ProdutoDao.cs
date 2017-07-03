using EstoqueSimples.Models;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstoqueSimples.DAO
{
    public class ProdutoDao
    {
        private EstoqueContext ctx;

        public ProdutoDao()
        {
            ctx = new EstoqueContext();
        }

        public void Insert(Produto produto)
        {
            ctx.Produtos.Add(produto);
            ctx.SaveChanges();
        }

        public Produto Find(int id )
        {
            return ctx.Produtos.FirstOrDefault(p => p.ID == id);
        }

        public void Delete(Produto produto)
        {
            ctx.Produtos.Remove(produto);
            ctx.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Produto produto = this.Find(id);
            this.Delete(produto);
        }

        public void Update(Produto produto)
        {
            ctx.Produtos.Update(produto);
            ctx.SaveChanges();
        }

        public IList<Produto> List()
        {
            return ctx.Produtos.Include(u => u.Categoria).ToList();
        }

    }
}
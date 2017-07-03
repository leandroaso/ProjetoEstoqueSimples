using EstoqueSimples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstoqueSimples.DAO
{
    public class CategoriaDao
    {
        private EstoqueContext ctx;
        public CategoriaDao()
        {
            ctx = new EstoqueContext();
        }

        public void Insert(Categoria categoria)
        {
            ctx.Categorias.Add(categoria);
            ctx.SaveChanges();
        }

        public Categoria Find(int id)
        {
            return ctx.Categorias.FirstOrDefault(c => c.ID==id);
        }

        public void Update(Categoria categoria)
        {
            ctx.Categorias.Update(categoria);
            ctx.SaveChanges();
        }

        public IList<Categoria> List()
        {
            return ctx.Categorias.ToList();
        }

        public void Delete(Categoria categoria)
        {
            ctx.Categorias.Remove(categoria);
            ctx.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Categoria categoria = this.Find(id);
            this.Delete(categoria);
        }

    }
}
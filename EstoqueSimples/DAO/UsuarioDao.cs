using EstoqueSimples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstoqueSimples.DAO
{
    public class UsuarioDao
    {
        EstoqueContext ctx;
        public UsuarioDao()
        {
            ctx = new EstoqueContext();
        }

        public void Insert(Usuario usuario)
        {
            ctx.Usuarios.Add(usuario);
            ctx.SaveChanges();
        }
        public void Update(Usuario usuario)
        {
            ctx.Usuarios.Update(usuario);
            ctx.SaveChanges();
        }

        public void Delete(Usuario usuario)
        {
            ctx.Usuarios.Remove(usuario);
            ctx.SaveChanges();
        }

        public Usuario Find(int id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.ID == id);
        }

        public IList<Usuario> List()
        {
            return ctx.Usuarios.ToList();
        }

        public void DeleteById(int id)
        {
            Usuario usuario = this.Find(id);
            this.Delete(usuario);
        }

        public Usuario AutenticaUsuario(string Login, string Senha)
        {
            Usuario usuario = ctx.Usuarios.FirstOrDefault(u => u.Login.Equals(Login) && u.Senha.Equals(Senha));

            if (usuario != null)
            {
                return usuario;
            }
            else
            {
                return null;
            }
        }
    }
}
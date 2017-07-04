using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstoqueSimples.Models
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Admin { get; set; }
    }
}
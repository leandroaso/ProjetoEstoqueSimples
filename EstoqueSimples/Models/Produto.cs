using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstoqueSimples.Models
{
    public class Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }

        public virtual Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}
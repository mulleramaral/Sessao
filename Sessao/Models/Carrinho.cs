using System.Collections.Generic;

namespace Sessao.Models
{
    public class Carrinho
    {
        public List<Produto> Produtos { get; set; }

        public Carrinho()
        {
            this.Produtos = new List<Produto>();
        }
    }
}
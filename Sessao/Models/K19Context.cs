using System.Data.Entity;

namespace Sessao.Models
{
    public class K19Context : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
    }
}
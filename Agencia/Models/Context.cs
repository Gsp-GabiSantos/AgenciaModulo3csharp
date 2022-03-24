using Microsoft.EntityFrameworkCore;

namespace Agencia.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Ajuda> Ajuda { get; set; }
        public DbSet<CadastroDestino> CadastroDestino { get; set; }
        

        public DbSet<Comprar> Comprar { get; set; }
    }
}

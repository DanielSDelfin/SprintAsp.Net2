using Microsoft.EntityFrameworkCore;
using Sprint2.Models;

namespace Sprint2.Persistence
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {

        }

        public DbSet<ComportamentoNegocios> ComportamentoNegocios { get; set; }
        public DbSet<TendenciasGastos> TendenciasGastos { get; set; }
        public DbSet<DesempenhoFinanceiro> DesempenhoFinanceiro { get; set; }
    }
    {
    }
}

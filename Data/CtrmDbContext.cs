using ctrmmvp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ctrmmvp.Data
{
    public class CtrmDbContext : DbContext
    {
        public CtrmDbContext(DbContextOptions<CtrmDbContext> options) : base(options)
        {
        }

        public DbSet<ArcContract> ArcContracts { get; set; }
        public DbSet<ArcContractLine> ArcContractLines { get; set; }
    }
}
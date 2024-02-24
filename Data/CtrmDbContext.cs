using ctrmmvp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ctrmmvp.Data
{
    public class CtrmDbContext : DbContext
    {
        public CtrmDbContext(DbContextOptions<CtrmDbContext> options) : base(options)
        {
        }

        public virtual DbSet<ArcContract> ArcContracts { get; set; }
        public virtual DbSet<ArcContractLine> ArcContractLines { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}

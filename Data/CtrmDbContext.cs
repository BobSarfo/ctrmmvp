using Microsoft.EntityFrameworkCore;

namespace ctrmmvp.Data
{
    public class CtrmDbContext : DbContext
    {
        public CtrmDbContext(DbContextOptions<CtrmDbContext> options) : base(options)
        {
        }
    }
}
using GlossaryServer.Models;
using Microsoft.EntityFrameworkCore;

namespace GlossaryServer.Data
{
    public class GlossaryDbContext : DbContext
    {
        public GlossaryDbContext(DbContextOptions<GlossaryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Term> Terms { get; set; }
    }
}
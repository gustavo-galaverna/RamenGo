
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RamenGo.Domain.Entities;

namespace RamenGo.Data
{
    public class RamenGoDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public RamenGoDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("RamenGoWebApiDatabase"));
        }

        public DbSet<Broth> Broths { get; set; }
        public DbSet<Protein> Proteins {get; set;}
    }
}

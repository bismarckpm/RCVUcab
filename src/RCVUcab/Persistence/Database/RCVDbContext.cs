using Microsoft.EntityFrameworkCore;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.Persistence.Database
{
    public class RCVDbContext : DbContext, IRCVDbContext
    {
        public RCVDbContext()
        {
        }

        public RCVDbContext(DbContextOptions<RCVDbContext> options) : base(options)
        {
        }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        public virtual DbSet<ProviderEntity> Providers
        {
            get; set;
        }

        public virtual DbSet<BrandEntity> Brands        {
            get;
            set;
        }

    }
}
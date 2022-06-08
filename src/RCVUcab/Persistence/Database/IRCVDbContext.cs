using Microsoft.EntityFrameworkCore;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.Persistence.Database
{
    public interface IRCVDbContext
    {
        DbContext DbContext
        {
            get;
        }

        DbSet<ProviderEntity> Providers
        {
            get; set;
        }

        DbSet<BrandEntity> Brands
        {
            get; set;
        }
    }
}

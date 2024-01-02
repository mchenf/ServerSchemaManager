using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ServerSchemaManagerSite.Models
{
    public class SsmDbContext : DbContext
    {
        public SsmDbContext(DbContextOptions<SsmDbContext> opts, ILogger<SsmDbContext> logger) 
            : base(opts) {

            logger.Log(LogLevel.Debug, "The Connection String is: {0}", opts.ToString());
        }

        public DbSet<SsmServer> SsmServers => Set<SsmServer>();
        public DbSet<SsmRegion> SsmRegions => Set<SsmRegion>();
        public DbSet<SsmUsage> SsmUsages => Set<SsmUsage>();

        
    }

    public static class SsmDbContextHelper
    {
        public static void AddSsmDbContext(this WebApplicationBuilder builder, string ConnectionString)
        {
            
            builder.Services.AddDbContext<SsmDbContext>(opts =>
            {
                opts.UseSqlServer(ConnectionString);
            });
        }
    }
}

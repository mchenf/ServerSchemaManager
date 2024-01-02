using Microsoft.EntityFrameworkCore;

namespace ServerSchemaManagerSite.Models
{
    public static class SeedData
    {
        public static void EnsureSeedData(this IApplicationBuilder app)
        {
            SsmDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<SsmDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.SsmRegions.Any())
            {
                context.SsmRegions.AddRange(
                        new SsmRegion { ShortName = "EU", FullName = "Europe"},
                        new SsmRegion { ShortName = "US", FullName = "Americas"},
                        new SsmRegion { ShortName = "AS", FullName = "Asia-Pacific"},
                        new SsmRegion { ShortName = "CN", FullName = "China"},
                        new SsmRegion { ShortName = "BL", FullName = "BuildLab"}
                    );
                context.SsmUsages.AddRange(
                        new SsmUsage { ShortName = "PD", FullName = "Production" },
                        new SsmUsage { ShortName = "TS", FullName = "Testing" },
                        new SsmUsage { ShortName = "SG", FullName = "Staging" },
                        new SsmUsage { ShortName = "DV", FullName = "Development" }
                    );

                context.SaveChanges();

                foreach (SsmRegion r in context.SsmRegions)
                {
                    foreach (SsmUsage u in context.SsmUsages)
                    {
                        for (int i = 1; i < 20; i++)
                        {
                            string serverName = string.Format(
                                "{0}-{1}-{2}-{3}",
                                r.ShortName,
                                "MO",
                                u.ShortName,
                                i.ToString().PadLeft(2, '0')
                                );
                            context.SsmServers.Add(
                                new SsmServer
                                {
                                    HostName = serverName,
                                    RegionId = r.Id,
                                    UsageId = u.Id
                                }
                            );
                        }
                    }
                }

                context.SaveChanges();



            }
        }
    }
}

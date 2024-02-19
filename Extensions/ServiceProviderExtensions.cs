using ctrmmvp.Data;
using Microsoft.EntityFrameworkCore;

namespace ctrmmvp.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static async Task RunMigrations(this IServiceProvider serviceProvider)
        {
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var storageContext = services.GetRequiredService<CtrmDbContext>();
                    var storageContextAuth = services.GetRequiredService<AppDbContext>();

                    //invoke command line commands...

                    //refer to https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
                    //for more on how to enable migrations

                    var count = (await storageContext.Database.GetPendingMigrationsAsync()).Count();
                    if (count > 0)
                    {
                        logger.LogInformation($"found {count} pending migrations to apply. will proceed to apply them");
                        await storageContext.Database.MigrateAsync();
                        logger.LogInformation($"done applying pending migrations");
                    }
                    else
                    {
                        logger.LogInformation($"no pending migrations found! :)");
                    }

                    count = (await storageContextAuth.Database.GetPendingMigrationsAsync()).Count();
                    if (count > 0)
                    {
                        logger.LogInformation($"found {count} pending migrations to apply. will proceed to apply them");
                        await storageContextAuth.Database.MigrateAsync();
                        logger.LogInformation($"done applying pending migrations");
                    }
                    else
                    {
                        logger.LogInformation($"no pending migrations found! :)");
                    }

                    //SeedDb(storageContext)
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while performing migration.");
                    throw;
                }
            }
        }
    }
}
using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AdvBoxCRM.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class AdvBoxCRMDbContextFactory : IDesignTimeDbContextFactory<AdvBoxCRMDbContext>
{
    public AdvBoxCRMDbContext CreateDbContext(string[] args)
    {
        AdvBoxCRMEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<AdvBoxCRMDbContext>()
            .UseNpgsql(configuration.GetConnectionString("Default"));

        return new AdvBoxCRMDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../AdvBoxCRM.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}

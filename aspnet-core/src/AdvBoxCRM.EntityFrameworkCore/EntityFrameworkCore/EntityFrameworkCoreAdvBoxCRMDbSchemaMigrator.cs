using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AdvBoxCRM.Data;
using Volo.Abp.DependencyInjection;

namespace AdvBoxCRM.EntityFrameworkCore;

public class EntityFrameworkCoreAdvBoxCRMDbSchemaMigrator
    : IAdvBoxCRMDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAdvBoxCRMDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the AdvBoxCRMDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AdvBoxCRMDbContext>()
            .Database
            .MigrateAsync();
    }
}

using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AdvBoxCRM.Data;

/* This is used if database provider does't define
 * IAdvBoxCRMDbSchemaMigrator implementation.
 */
public class NullAdvBoxCRMDbSchemaMigrator : IAdvBoxCRMDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

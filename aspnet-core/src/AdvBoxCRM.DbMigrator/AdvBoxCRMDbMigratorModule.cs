using AdvBoxCRM.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AdvBoxCRM.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AdvBoxCRMEntityFrameworkCoreModule),
    typeof(AdvBoxCRMApplicationContractsModule)
    )]
public class AdvBoxCRMDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}

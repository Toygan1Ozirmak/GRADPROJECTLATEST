using Volo.Abp.Modularity;

namespace AdvBoxCRM;

[DependsOn(
    typeof(AdvBoxCRMApplicationModule),
    typeof(AdvBoxCRMDomainTestModule)
    )]
public class AdvBoxCRMApplicationTestModule : AbpModule
{

}

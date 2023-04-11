using AdvBoxCRM.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AdvBoxCRM;

[DependsOn(
    typeof(AdvBoxCRMEntityFrameworkCoreTestModule)
    )]
public class AdvBoxCRMDomainTestModule : AbpModule
{

}

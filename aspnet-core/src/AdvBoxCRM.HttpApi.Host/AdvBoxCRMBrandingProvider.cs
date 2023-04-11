using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AdvBoxCRM;

[Dependency(ReplaceServices = true)]
public class AdvBoxCRMBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AdvBoxCRM";
}

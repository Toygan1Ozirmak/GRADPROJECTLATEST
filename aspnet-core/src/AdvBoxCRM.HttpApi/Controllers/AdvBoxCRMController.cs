using AdvBoxCRM.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AdvBoxCRM.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AdvBoxCRMController : AbpControllerBase
{
    protected AdvBoxCRMController()
    {
        LocalizationResource = typeof(AdvBoxCRMResource);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using AdvBoxCRM.Localization;
using Volo.Abp.Application.Services;

namespace AdvBoxCRM;

/* Inherit your application services from this class.
 */
public abstract class AdvBoxCRMAppService : ApplicationService
{
    protected AdvBoxCRMAppService()
    {
        LocalizationResource = typeof(AdvBoxCRMResource);
    }
}

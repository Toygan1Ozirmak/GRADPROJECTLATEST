using Volo.Abp.Settings;

namespace AdvBoxCRM.Settings;

public class AdvBoxCRMSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AdvBoxCRMSettings.MySetting1));
    }
}

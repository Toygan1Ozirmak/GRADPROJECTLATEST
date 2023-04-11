using AdvBoxCRM.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AdvBoxCRM.Permissions;

public class AdvBoxCRMPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AdvBoxCRMPermissions.GroupName);

        var boxesPermission = myGroup.AddPermission(
    AdvBoxCRMPermissions.Boxes.Default, L("Permission:Authors"));

        boxesPermission.AddChild(
            AdvBoxCRMPermissions.Boxes.Create, L("Permission:Authors.Create"));

        boxesPermission.AddChild(
            AdvBoxCRMPermissions.Boxes.Edit, L("Permission:Authors.Edit"));

        boxesPermission.AddChild(
            AdvBoxCRMPermissions.Boxes.Delete, L("Permission:Authors.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AdvBoxCRMPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AdvBoxCRMResource>(name);
    }
}

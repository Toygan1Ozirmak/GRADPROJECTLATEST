namespace AdvBoxCRM.Permissions;

public static class AdvBoxCRMPermissions
{
    public const string GroupName = "AdvBoxCRM";

    public static class Boxes
    {
        public const string Default = GroupName + ".Boxes";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
}

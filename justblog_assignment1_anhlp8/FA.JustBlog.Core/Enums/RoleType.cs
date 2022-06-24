namespace FA.JustBlog.Core.Base.Enums
{
    public enum RoleType
    {
        Adminstrator,
        User,
        Contributor,
    }

    public static class Role
    {
        public const string ADMIN = "Adminstrator";
        public const string USER = "User";
        public const string CONTRIBUTOR = "Contributor";
        public const string ADMIN_CONTRIBUTOR = ADMIN + "," + CONTRIBUTOR;
    }
}
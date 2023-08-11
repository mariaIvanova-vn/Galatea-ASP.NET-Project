namespace Galatea.Common
{
    public static class GeneralConstants
    {
        public const int IssueYear = 2023;

        public const int DefaultPage = 1;
        public const int DefaultPublicationPerPage = 5;

        public const string AdminAreaName = "Admin";
        public const string AdminRoleName = "Administrator";
        public const string DevelopmentAdminEmail = "admin@admin.com";
       
        public const string OnlineUsersCookieName = "IsOnline";
        public const int LastActivityBeforeOfflineMinutes = 10;

        public const string UsersCacheKey = "UsersCache";
        public const string RentsCacheKey = "RentsCache";
        public const int UsersCacheDurationMinutes = 5;
        public const int RentsCacheDurationMinutes = 10;
    }
}
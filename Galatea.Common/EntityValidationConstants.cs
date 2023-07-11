namespace Galatea.Common;

public static class EntityValidationConstants
{
    public static class Category
    {
        public const int NameMinLength = 1;
        public const int NameMaxLength = 50;
    }
    public static class Publication
    {
        public const int TitleMinLength = 1;
        public const int TitleMaxLength = 50;

        public const int ContentMinLength = 1;
        public const int ContentMaxLength = 500;

        public const int ImageUrlMinLength = 20;
        public const int ImageUrlMaxLength = 2048;

        public const int RatingMinLength = 1;
        public const int RatingMaxLength = 10;
    }
    public static class AppUser
    {
        public const int FirstNameMinLength = 2;
        public const int FirstNameMaxLength = 20;

        public const int LastNameMinLength = 2;
        public const int LastNameMaxLength = 20;

        public const int PasswordMinLength = 9;
        public const int PasswordMaxLength = 127;       
    }
    public static class Comment
    {
        public const int TextMinLength = 2;
        public const int TextMaxLength = 200;
    }
    public static class Response
    {
        public const int TextMinLength = 2;
        public const int TextMaxLength = 200;
        public const int RatingMinLength = 0;
        public const int RatingMaxLength = 5;
    }
}

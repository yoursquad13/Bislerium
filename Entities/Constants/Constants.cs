namespace Entities.Constants
{
    public class Constants
    {
        public class Roles
        {
            public const string Admin = "Admin";
            public const string Blogger = "Blogger";
        }

        public class Passwords
        {
            public const string AdminPassword = "Password@123";
            public const string BloggerPassword = "Password@123";
        }

        public class FilePath
        {
            public static string UsersImagesFilePath => @"user-images\";

            public static string BlogsImagesFilePath => @"blog-images\";
        }
    }
}

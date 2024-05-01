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
            public const string AdminPassword = "radi0V!oleta";
            public const string BloggerPassword = "radi0V!oleta";
        }

        public class FilePath
        {
            public static string UsersImagesFilePath => @"user-images\";

            public static string BlogsImagesFilePath => @"blog-images\";
        }
    }
}

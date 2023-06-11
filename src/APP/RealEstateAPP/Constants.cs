using System;
namespace RealEstateAPP
{
    public static class Constants
    {
        public static string LocalhostUrl = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
        public static string Scheme = "http"; // or https
        public static string Port = "8000"; // when using docker on local system
        public static string RestUrl = $"{Scheme}://{LocalhostUrl}:{Port}/{{0}}";

        public static string CurrentToken = "AccessToken";
        public static string CurrentUserId = "UserId";
        public static string CurrentUserName = "UserName";



    }
}


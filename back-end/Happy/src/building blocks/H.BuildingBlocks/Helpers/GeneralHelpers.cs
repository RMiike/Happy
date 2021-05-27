using System;
using System.IO;

namespace H.BuildingBlocks.Helpers
{
    public static class GeneralHelpers
    {
        public static long ToUnixEpochDate(this DateTime date)
        => (long) Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        public static string CreateIfNotExistsImagePathAndReturn()
        {

            string basePath = System.Reflection.Assembly.GetCallingAssembly().Location;
            string apiPath = basePath.Substring(0, basePath.LastIndexOf("bin"));

            string pth = apiPath + "Images\\";
            if (!Directory.Exists(pth))
            {
                Directory.CreateDirectory(pth);
            }
            return pth;
        }
    }
}

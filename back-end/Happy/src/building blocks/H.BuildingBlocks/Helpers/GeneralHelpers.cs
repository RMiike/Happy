using System.IO;

namespace H.BuildingBlocks.Helpers
{
    public class GeneralHelpers
    {



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

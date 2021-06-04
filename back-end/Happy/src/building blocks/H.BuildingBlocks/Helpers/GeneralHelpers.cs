using System;
using System.IO;

namespace H.BuildingBlocks.Helpers
{
  public static class GeneralHelpers
  {
    public static long ToUnixEpochDate(this DateTime date)
    => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

    public static string CreateIfNotExistsImagePathAndReturn()
    {
      string basePath = ObterPathBase();
      Console.WriteLine(basePath);
      Console.WriteLine(basePath.LastIndexOf("bin"));
      string apiPath;
      if (basePath.LastIndexOf("bin") > 0)
      {
        apiPath = basePath.Substring(0, basePath.LastIndexOf("bin"));
      }
      else
      {
        apiPath = "/app/";
      }
      string pth = apiPath + "Images";
      if (!Directory.Exists(pth))
      {
        Directory.CreateDirectory(pth);
      }
      return pth;
    }
    public static string ObterPathBase()
    {
      return System.Reflection.Assembly.GetCallingAssembly().Location;
    }
  }
}

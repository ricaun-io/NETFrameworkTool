using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Versioning;

namespace NETFrameworkTool.Utils
{
    /// <summary>
    /// NetFrameworkUtils
    /// </summary>
    public static class NetFrameworkUtils
    {
        /// <summary>
        /// NETFramework
        /// </summary>
        public const string NETFramework = ".NETFramework";

        /// <summary>
        /// GetReferenceAssembliesNugetUrl
        /// </summary>
        /// <param name="netVersion"></param>
        /// <param name="nugetVersion"></param>
        /// <returns></returns>
        public static string GetReferenceAssembliesNugetUrl(string netVersion = "net45", string nugetVersion = null)
        {
            string nugetUrl = @$"https://www.nuget.org/api/v2/package/Microsoft.NETFramework.ReferenceAssemblies.{netVersion}/{nugetVersion}";
            return nugetUrl;
        }

        /// <summary>
        /// DownloadTempNugetFrameworkName
        /// </summary>
        /// <param name="frameworkName"></param>
        /// <param name="downloadNugetPath"></param>
        public static void DownloadTempNugetFrameworkName(FrameworkName frameworkName, Action<string> downloadNugetPath)
        {
            var nugetVersion = string.Empty;
            var netVersion = $"net{frameworkName.Version.ToString().Replace(".", "")}";

            var tempFolder = Path.GetTempPath() + Guid.NewGuid().ToString();
            var tempFileName = Path.Combine(tempFolder, $"{netVersion}_{nugetVersion}.zip");
            var tempExtractFolder = Path.Combine(tempFolder, $"{netVersion}_{nugetVersion}");

            try
            {
                var url = GetReferenceAssembliesNugetUrl(netVersion, nugetVersion);
                Console.WriteLine($"Download: {url}");
                HttpTasks.HttpDownloadFile(url, tempFileName);

                ZipFile.ExtractToDirectory(tempFileName, tempExtractFolder);
                File.Delete(tempFileName);

                // Find build folder
                //var buildFolder = Directory.GetDirectories(tempExtractFolder, "build", SearchOption.AllDirectories)
                var buildFolder = Directory.GetDirectories(tempExtractFolder, NETFramework, SearchOption.AllDirectories)
                    .FirstOrDefault();

                downloadNugetPath?.Invoke(buildFolder);
            }
            finally
            {
                Directory.Delete(tempFolder, true);
            }
        }

        /// <summary>
        /// GetProgramFilesReferenceAssemblyRoot
        /// </summary>
        /// <returns></returns>
        public static string GetProgramFilesReferenceAssemblyRoot()
        {
            return ToolLocationHelper.GetProgramFilesReferenceAssemblyRoot();
        }

        /// <summary>
        /// GetProgramFilesReferenceAssemblyNETFramework
        /// </summary>
        /// <returns></returns>
        public static string GetProgramFilesReferenceAssemblyNETFramework()
        {
            return Path.Combine(GetProgramFilesReferenceAssemblyRoot(), NETFramework);
        }

        /// <summary>
        /// GetSupportedTargetNetFrameworks
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<FrameworkName> GetSupportedTargetNetFrameworks()
        {
            return ToolLocationHelper.GetSupportedTargetFrameworks().Select(e => new FrameworkName(e))
                .Where(e => e.Identifier == NETFramework)
                .ToList();
        }
    }
}
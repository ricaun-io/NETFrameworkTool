using Microsoft.Build.Utilities;
using System.Linq;
using System.Runtime.Versioning;

namespace NETFrameworkTool.Utils
{
    /// <summary>
    /// FrameworkNameExtension
    /// </summary>
    public static class FrameworkNameExtension
    {
        /// <summary>
        /// Installed
        /// </summary>
        /// <param name="frameworkName"></param>
        /// <returns></returns>
        public static bool IsInstalled(this FrameworkName frameworkName)
        {
            return ToolLocationHelper.GetPathToReferenceAssemblies(frameworkName).Any();
        }

        /// <summary>
        /// AsString
        /// </summary>
        /// <param name="frameworkName"></param>
        /// <returns></returns>
        public static string AsString(this FrameworkName frameworkName)
        {
            return $"{frameworkName.Identifier} {frameworkName.Version}";
        }
    }
}
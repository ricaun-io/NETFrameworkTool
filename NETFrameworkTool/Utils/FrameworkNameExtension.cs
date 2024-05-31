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
        /// IsInstalled
        /// </summary>
        /// <param name="frameworkName"></param>
        /// <returns></returns>
        public static bool IsInstalled(this FrameworkName frameworkName)
        {
            return NetFrameworkUtils.FrameworkNameInstalled(frameworkName);
        }

        /// <summary>
        /// Exists
        /// </summary>
        /// <param name="frameworkName"></param>
        /// <returns></returns>
        public static bool Exists(this FrameworkName frameworkName)
        {
            return NetFrameworkUtils.FrameworkNameExists(frameworkName);
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
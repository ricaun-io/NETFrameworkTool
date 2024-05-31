using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace NETFrameworkTool.Utils
{
    /// <summary>
    /// HttpTasks
    /// </summary>
    /// <remarks>Based: https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/IO/HttpTasks.cs</remarks>
    public static class HttpTasks
    {
        /// <summary>
        /// HttpDownloadFile
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="path"></param>
        /// <param name="mode"></param>
        public static void HttpDownloadFile(string uri, string path, FileMode mode = FileMode.Create)
        {
            HttpDownloadFileAsync(uri, path, mode).GetAwaiter().GetResult();
        }
        /// <summary>
        /// HttpDownloadFileAsync
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="path"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static async Task HttpDownloadFileAsync(string uri, string path, FileMode mode = FileMode.Create)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            await using var fileStream = File.Open(path, mode);
            await response.Content.CopyToAsync(fileStream);
        }
    }
}
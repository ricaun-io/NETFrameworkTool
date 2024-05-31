using CommandLine;
using System;
using System.IO;
using System.Runtime.Versioning;

namespace NETFrameworkTool
{
    internal class Program
    {
        static void Show()
        {
            Console.WriteLine("NETFrameworkTool available:");
            foreach (var frameworkName in NetFrameworkUtils.GetSupportedTargetNetFrameworks())
            {
                Console.WriteLine($"  {frameworkName.Identifier}\t{frameworkName.Version}\t{(frameworkName.Installed() ? "Installed" : "")}");
            }
        }
        static void Main(string[] args)
        {
            Options.Parser.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    if (o.Show)
                    { 
                        Show();
                    }

                    var netVersion = o.NetVersion;
                    if (netVersion is not null)
                    {
                        var frameworkName = new FrameworkName(NetFrameworkUtils.NETFramework, netVersion);
                        if (frameworkName.Installed())
                        {
                            Console.WriteLine($"The version {netVersion} is already installed.");
                            if (o.Force == false) return;
                        }

                        try
                        {
                            NetFrameworkUtils.DownloadTempNugetFrameworkName(frameworkName, (path) =>
                            {
                                var copyToFrameworkDirectory = NetFrameworkUtils.GetProgramFilesReferenceAssemblyNETFramework();
                                Console.WriteLine($"CopyDirectory to {copyToFrameworkDirectory}");
                                try
                                {
                                    PathTasks.CopyDirectory(Path.Combine(path), copyToFrameworkDirectory);
                                }
                                catch (UnauthorizedAccessException)
                                {
                                    Console.WriteLine("Error unauthorized access to copy files, administrator is needed.");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                }
                            });

                            Console.WriteLine($".NET Framework version {netVersion} installed.");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Not able to download the version .NET Framework version {netVersion}.");
                        }
                    }
                }).WithNotParsed((errors) =>
                {
                    Show();
                    if (errors.IsHelp()) return;
                    if (errors.IsVersion()) return;
                });
        }
    }
}
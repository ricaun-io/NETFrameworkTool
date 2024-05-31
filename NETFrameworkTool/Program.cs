using CommandLine;
using NETFrameworkTool.Utils;
using System;
using System.IO;
using System.Runtime.Versioning;

namespace NETFrameworkTool
{
    internal class Program
    {
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
                        if (frameworkName.IsInstalled())
                        {
                            Console.WriteLine($"{frameworkName.AsString()} is already installed.");
                            if (o.Force == false) return;
                        }

                        Install(frameworkName);
                    }
                }).WithNotParsed((errors) =>
                {
                    Show();
                    if (errors.IsHelp()) return;
                    if (errors.IsVersion()) return;
                });
        }

        static void Install(FrameworkName frameworkName)
        {
            Console.WriteLine($"{frameworkName.AsString()} installing.");
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

                Console.WriteLine($"{frameworkName.AsString()} installed.");
            }
            catch (Exception)
            {
                Console.WriteLine($"Not able to download {frameworkName.AsString()}.");
            }
        }

        static void Show()
        {
            Console.WriteLine("NETFrameworkTool available:");
            foreach (var frameworkName in NetFrameworkUtils.GetSupportedTargetNetFrameworks())
            {
                Console.WriteLine($"  {frameworkName.AsString()}\t{(frameworkName.IsInstalled() ? "Installed" : "")}");
            }
        }
    }
}
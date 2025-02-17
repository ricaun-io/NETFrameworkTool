using CommandLine;
using NETFrameworkTool.Utils;
using System;
using System.Runtime.Versioning;

namespace NETFrameworkTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var parser = Options.Parser.ParseArguments<Options>(args);
            parser.WithParsed<Options>(o =>
            {
                var netVersion = o.NetVersion;
                if (o.Show)
                    Show();
                else if (netVersion is null)
                    Console.WriteLine(DisplayHelp(parser));

                if (netVersion is not null)
                {
                    var frameworkName = new FrameworkName(NetFrameworkUtils.NETFramework, netVersion);
                    if (frameworkName.Exists() == false)
                    {
                        Console.WriteLine($"{frameworkName.AsString()} does not exist.");
                        return;
                    }
                    if (frameworkName.IsInstalled())
                    {
                        if (o.Uninstall)
                        {
                            Uninstall(frameworkName);
                            return;
                        }
                        if (o.ForceInstall == false)
                        {
                            Console.WriteLine($"{frameworkName.AsString()} is already installed.");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{frameworkName.AsString()} is not installed.");
                    }
                    if (o.Install)
                    {
                        Install(frameworkName);
                    }
                }
            }).WithNotParsed((errors) =>
            {
                if (errors.IsHelp()) return;
                if (errors.IsVersion()) return;
            });
        }

        static string DisplayHelp<T>(ParserResult<T> result)
        {
            var helpText = CommandLine.Text.HelpText.AutoBuild(result, h => h, e => e);
            return helpText.ToString();
        }

        static void Install(FrameworkName frameworkName)
        {
            Console.WriteLine($"{frameworkName.AsString()} installing.");
            try
            {
                NetFrameworkUtils.Install(frameworkName);
                Console.WriteLine($"{frameworkName.AsString()} installed.");
            }
            catch (Exception)
            {
                Console.WriteLine($"Not able to install {frameworkName.AsString()}.");
            }
        }

        static void Uninstall(FrameworkName frameworkName)
        {
            Console.WriteLine($"{frameworkName.AsString()} uninstalling.");
            try
            {
                NetFrameworkUtils.Unnstall(frameworkName);
                Console.WriteLine($"{frameworkName.AsString()} uninstalled.");
            }
            catch (Exception)
            {
                Console.WriteLine($"Not able to uninstall {frameworkName.AsString()}.");
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
using CommandLine;
using System;

namespace NETFrameworkTool
{
    internal class Options
    {
        #region Parser
        public static Parser Parser { get; } = CreateParser();
        private static Parser CreateParser()
        {
            var parser = new Parser(with =>
            {
                with.HelpWriter = System.Console.Error;
                with.IgnoreUnknownArguments = true;
            });
            return parser;
        }
        #endregion

        [Option('n', "net", Required = false, HelpText = ".NET Framework version")]
        public Version NetVersion { get; set; }
        [Option('i', "install", Required = false, HelpText = "Install .NET Framework.")]
        public bool Install { get; set; }
        [Option('u', "uninstall", Required = false, HelpText = "Uninstall .NET Framework.")]
        public bool Uninstall { get; set; }
        [Option('f', "force", Required = false, HelpText = "Force to install .NET Framework.")]
        public bool ForceInstall { get; set; }
        [Option('l', "list", Required = false, HelpText = "Show list of available .NET Framework.")]
        public bool Show { get; set; }
    }
}

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

        [Option('n', "net", Required = true, HelpText = ".NET Framework version")]
        public Version NetVersion { get; set; }
        [Option('f', "force", Required = false, HelpText = "Force to install .NET Framework in Microsoft folder.")]
        public bool Force { get; set; }
        [Option('l', "list", Required = false, Hidden = true, HelpText = "Show list of available .NET Framework.")]
        public bool Show { get; set; }
    }
}

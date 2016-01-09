using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GroceryCo.Kiosk.Acceptance.Tests.Infrastructure
{
    public static class CommandLineApp
    {
        private static readonly string _applicationPath;

        static CommandLineApp()
        {
            _applicationPath = @"GroceryCo.Kiosk.Console.exe";
        }

        /// <summary>
        /// Time application has to complete execution
        /// </summary>
        private const int WaitTimeInMs = 15000;

        public static IEnumerable<string> Run(string cartFile, string pricesAndPromotionsFile)
        {
            var arguments = $"\"#{cartFile}\" \"#{pricesAndPromotionsFile}\"";
            var processStartInfo = new ProcessStartInfo(_applicationPath, arguments)
            {
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };

            var process = Process.Start(processStartInfo);
            process.WaitForExit(WaitTimeInMs);

            var output = process.StandardOutput.ReadToEnd();

            var lines = output.Split(new[] { "\r\n" }, StringSplitOptions.None);
            return lines;
        }
    }
}
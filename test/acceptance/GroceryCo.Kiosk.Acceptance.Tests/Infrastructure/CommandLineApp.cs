﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GroceryCo.Kiosk.Acceptance.Tests.Infrastructure
{
    public static class CommandLineApp
    {
        private static readonly string _applicationPath;

        static CommandLineApp()
        {
            //MAKE THIS RELATIVE INSTEAD OF HARD CODED
               _applicationPath = @"C:\Projects\GroceryCoKiosk\test\acceptance\GroceryCo.Kiosk.Acceptance.Tests\bin\Debug\GroceryCo.Kiosk.Console.exe";
        }

        /// <summary>
        /// Time application has to complete execution
        /// </summary>
        private const int WaitTimeInMs = 15000;

        public static CommandLineResults Run(string cartFile, string productCatalogFile)
        {
            var arguments = $"\"{cartFile}\" \"{productCatalogFile}\"";
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
            var results = new CommandLineResults();
            results.AddRange(lines);
            return results;
        }
    }
}
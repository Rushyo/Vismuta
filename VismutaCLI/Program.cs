using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using CommandLine;
using CommandLine.Text;
using VismutaCLI.Properties;
using VismutaLib;
// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace VismutaCLI
{
    class Program
    {
        class Options
        {
            [Option('p', "payload", DefaultValue = null, HelpText = "Path to payload file", Required=true)]
            public String PayloadPath { get; set; }

            [Option('o', "out", DefaultValue=null, HelpText = "File path to output to (if not specified, uses stdout)")]
            public String OutputPath { get; set; }

            [Option('a', "args", DefaultValue = null, HelpText = "Arguments to run against payload once deployed")]
            public String PayloadArgs { get; set; }

            [Option('r', "run", DefaultValue=false, HelpText = "Run after deploy")]
            public Boolean RunAfterDeploy { get; set; }

            [Option('s', "psexec", DefaultValue = false, HelpText = "Run as SYSTEM (implies -r)")]
            public Boolean PsExec { get; set; }

            [Option('i', "inject", DefaultValue = false, HelpText = "Use memory injection (precludes use of -r and -s)")]
            public Boolean Inject { get; set; }

            [Option('x', "obfuscate", DefaultValue = false, HelpText="Obfuscate payload filename")]
            public Boolean Obfuscate { get; set; }

            [Option('l', "about", DefaultValue = false, HelpText = "Provides info about the application and licenses")]
            public Boolean ShowAbout { get; set; }

            [HelpOption]
            public String GetUsage()
            {
                return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
            }
        }


        static void Main(string[] args)
        {
            var options = new Options();
            if (Parser.Default.ParseArguments(args, options))
            {

                if (options.ShowAbout)
                { 
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                    Console.WriteLine(fvi.ProductName + @" v" + fvi.ProductVersion
                            + Environment.NewLine + fvi.LegalCopyright
                            + Environment.NewLine + VismutaLib.Properties.Resources.AboutLicense
                            + Environment.NewLine +
                            Resources.Program_Main_IconLicense + @" (http://deviantdark.deviantart.com/)");
                    return;
                }

                if (!String.IsNullOrEmpty(options.PayloadPath))
                {
                    DeployMethodFlags flags = DeployMethodFlags.None;
                    if(options.RunAfterDeploy)
                        flags |= DeployMethodFlags.RunAfterDeploy;
                    if(options.PsExec)
                        flags |= DeployMethodFlags.PsExec | DeployMethodFlags.RunAfterDeploy;
                    if(options.Inject)
                        flags |= DeployMethodFlags.Inject;
                    if(options.Obfuscate)
                        flags |= DeployMethodFlags.ObfuscateName;

                    if(!Vismuta.IsValidDeployMethod(flags))
                    { 
                        Console.WriteLine(Resources.Program_Main_InvalidOptions);
                        Console.WriteLine(options.GetUsage());
                        return;
                    }

                    Byte[] srcBinary = File.ReadAllBytes(options.PayloadPath);
                    String payloadName = Path.GetFileNameWithoutExtension(options.PayloadPath);
                    String payloadExt = Path.GetExtension(options.PayloadPath);
                    String dstShell = Vismuta.Muta(flags, srcBinary, payloadName, payloadExt, options.PayloadArgs);
                    if (String.IsNullOrWhiteSpace(options.OutputPath))
                    {
                        Console.WriteLine(dstShell);
                    }
                    else
                    {
                        File.WriteAllText(options.OutputPath, dstShell);
                        Console.WriteLine(Resources.Program_Main_OperationCompleted);
                    }

                }
                else
                {
                    Console.WriteLine(Resources.Program_Main_PayloadPathRequired);
                    Console.WriteLine(options.GetUsage());
                    return;
                }
            }
            Console.ReadKey();
        }


    }
}

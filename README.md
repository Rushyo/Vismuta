# Vismuta

## What?

Vismuta is a cross-platform* C# tool (both CLI and GUI) that allows you move (and execute files), from your local system, on a remote system simply by copying and pasting, if the remote system runs PowerShell.

*In theory. The author is too lazy to have tried it yet.

## Who?

Vismuta is targeted towards penetration testers and sysadmins working with systems virtually/remotely on a regular basis.

## Why?

Virtual machines (VMWare, Hyper-V) and remote access tools (RDP, VNC, Citrix) often have access controls or limitations that prevent common techniques of copying files on to remote systems, such as drag-and-drop or file sharing. In addition, Intrusion Prevention Systems, firewalls, and other security systems can frustrate your ability to download files from networks when working with a remote machine.

Vismuta bypasses all these limitations, requiring only the ability to copy and paste in to the shell or copy a text file from a site such as Dropbox or Pastebin. For penetration testers it can also deploy PSExec and will, where possible, run your payload with "NT AUTHORITY\SYSTEM" permissions. If you have a payload you want to inject in-memory (to avoid AV) you can do that too (experimental)! You can also move large quantities of files, which will be zipped and deflated on the target (presently GUI only).

## How?

Vismuta, at its most basic, simply encodes your files in Base64 on your local system then de-encodes them, using the generated PowerShell script, on the remote system.

It can also zip multiple files and automatically unzip them (presently GUI only), run a single file as SYSTEM automatically using a built-in copy of PSExec, or inject your code directly in to the memory of the PowerShell process to avoid touching disk (NOTE: experimental and VERY dangerous). You can even encrypt a payload, to avoid the payload being detected by a particular aggressive IDS.

### Examples

To write out a PowerShell script to deploy incognito.exe on the remote system:

`./VismutaCLI -p incognito.exe > copyandpasteme.txt`

To write out a PowerShell script to deploy and run incognito.exe as SYSTEM user, with obfuscated variables and filenames:

`./VismutaCLI -p incognito.exe -s -x > copyandpasteme.txt`

### Usage Notes

Memory injection is experimental and liable to break things; badly. If you use memory injection on the wrong architecture (or wrong version of PowerShell) you're going to have a bad day.

## Where?

Vismuta is designed to work on any local system that supports .NET 4.5, including Mono, via both GUI and CLI. Future versions may reduce this framework requirement. The remote system just needs PowerShell! Vismuta has been functionally tested on Windows 7 local and remote systems. Please let me know how you get on with other platforms (both local and remote).

## Contributing

Contributions are welcome. If I don't think your code meets my quirky coding standards I'll clean it up and let you know what I did, rather than rejecting it. If you want to add a feature sound me out first with a feature request, or fork it off. I can't guarantee it's necessarily something I'll want to add otherwise; I avert feature creep pathologically.

Vismuta is internationalised. If you want to localise it for your language, you'll be doing me and, I hope, many other people a great service.

### Compilation

Vismuta has been built with Visual Studio 2015 Community Edition. It ought to build in other C# environments, in particular MonoDevelop. If it doesn't, file a bug and I'll fix it. Better yet, send me a pull request with a fix.

### Dependencies

Vismuta relies on two NuGet packages: CommandLineParser (for the CLI) and SharpZipLib (for the GUI). It also has the latest stable version of PSExec (from 2014) embedded as a resource.

## License

* Vismuta (comprising VismutaCLI, VismutaGUI, and VismutaLib) is licensed under the LGPL 3.0; see the LICENSE file.
* Its icon was created by Deviant Dark (http://deviantdark.deviantart.com/), also licensed under LGPL 3.0.
* SharpZipLib is licensed under the MIT license (*https://github.com/icsharpcode/SharpZipLib/blob/master/LICENSE.txt).
* CommandLineParser is licensed under the MIT license (https://github.com/gsscoder/commandline/blob/master/License.md).
* PSExec is licensed under the Sysinternals Software License Terms (https://technet.microsoft.com/en-us/sysinternals/bb469936.aspx).

## Author

Vismuta was written by Danny Rushyo Moules (@Rushyo) after they got tired of copy/pasting the same PowerShell scripts during time-constrained red teaming and lost their voice shouting at VMWare. Relative to you, they are now vis-à-vis a mute.

## Using it?

Star it! This lets me know whether I should continue to work on it beyond my own needs. Also follow me on Twitter: @Rushyo.

## Roadmap

I need to bring the CLI version in to parity with the GUI version, and clean up the zip UX path. The encryption deploy method ought to have a less secure but more UX friendly non-interactive mode. I also need to add unit tests (!)

## Disclaimer

Vismuta is provided as is. If your use of it somehow sets fire to the family dog or shuts down a stock exchange, that's very much your own fault. If you do anything criminal with it, you're an idiot.

## Flag Descriptions

### Payloads Arguments (-a <args>)

Arguments to run against the payload, as though you were running it on the command line.

### Run After Deploy (-r)

After deploying the file to the target system, this runs the file via PowerShell.

### Execute As SYSTEM (-s)

Implies Run After Deploy. Deploys PSExec to the target directory alongside the payload and attempts to run the file in command prompt under "NT AUTHORITY\SYSTEM" permissions. If encryption is enabled, PSExec will also be encrypted.

### Memory Injection (-i)

Injects the payload directly in to the PowerShell instances memory. This is experimental, and will only work with shellcode that matches the target architecture of the PowerShell instance (x86 or x64). Precludes most other options, as there is no file to run.

### Obfuscate Name (-x)

Obfuscates the name of the file, turning incognito.exe in to something like fHtfiPdhE.exe, to frustrate automatic AV/IDS detection.

### Obfuscate Variables (-x)

Obfuscates PowerShell variable names to frustrate automatic AV/IDS detection.

### Encrypt (Interactive) (-k <key>)

Encrypts the payload (and PSExec, if relevant) using AEAD AES-256. Potentially useful for AV/IDS evasion, or just keeping your payload secret from a nosey DFIR team. Requires the user to run a script to enter a keyphrase before running the main script (see -h). More security is offered by typing the keyphrase rather than copying it, as copying it to the target system's clipboard provides an easy opportunity for the keyphrase to be stolen. Incompatible with non-interactive encryption.

### Encrypt (Non-Interactive) (-e)

Encrypts the payload (and PSExec, if relevant) using AEAD AES-256, however includes the key in plaintext within the script! Potentially useful for AV/IDS evasion, but offers little protection against a blue team. Incompatible with interactive encryption. Does not require any special interactions from the user (hence, y'know, being non-interactive).
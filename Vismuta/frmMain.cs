using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using VismutaGUI.Properties;
using VismutaLib;

namespace VismutaGUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private String[] _selectedFiles;

        private void cmdChooseSrc_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = true;
                dialog.InitialDirectory = "F:\\sec";
                dialog.Filter = @"Executable Files|*.exe|All Files|*.*";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                if (dialog.CheckFileExists == false)
                    return;

                if (dialog.FileNames.Length > 1)
                {
                    txtSrcPath.Text = Resources.frmMain_MultipleSourcesSelected;
                    _selectedFiles = dialog.FileNames.ToArray();
                }
                else
                {
                    txtSrcPath.Text = dialog.FileName;
                    _selectedFiles = null;
                }
                ValidateCurrentOptions();
            }
        }

        private void txtSrcPath_TextChanged(object sender, EventArgs e)
        {
            _selectedFiles = null;
            ValidateCurrentOptions();
            
        }

        private void cmdMuta_Click(object sender, EventArgs e)
        {
            cmdMuta.Enabled = false;
            txtArgs.Enabled = false;

            try
            {
                DeployMethodFlags deployFlags = GetCurrentFlags();

                Byte[] srcBinary;
                String payloadName;
                String payloadExt;
                String payloadArgs;
                if (_selectedFiles == null)
                {
                    if (!File.Exists(txtSrcPath.Text))
                        MessageBox.Show(Resources.frmMain_SourceFileNotFound, Application.ProductName);
                    try
                    {
                        srcBinary = File.ReadAllBytes(txtSrcPath.Text);
                    }
                    catch
                    {
                        MessageBox.Show(Resources.frmMain_ExceptionWhenReadingSourceFile, Application.ProductName);
                        throw;
                    }
                    if (deployFlags.HasFlag(DeployMethodFlags.ObfuscateName))
                        payloadName = Vismuta.GetRandomString(Vismuta.RandomFilenameLength, false);
                    else
                        payloadName = Path.GetFileNameWithoutExtension(txtSrcPath.Text);

                    payloadExt = Path.GetExtension(txtSrcPath.Text);
                    payloadArgs = txtArgs.Text;
                }
                else
                {
                    if (_selectedFiles.Any(f => !File.Exists(f)))
                        MessageBox.Show(Resources.frmMain_AnySourceFileNotFound, Application.ProductName);
                    try
                    {
                        srcBinary = ZipFiles(_selectedFiles);
                    }
                    catch
                    {
                        MessageBox.Show(Resources.frmMain_ExceptionWhenZippingSourcesFiles, Application.ProductName);
                        throw;
                    }
                    payloadName = Vismuta.GetRandomString(Vismuta.RandomFilenameLength, false);
                    payloadExt = @"." + Vismuta.GetRandomString(3, true);
                    payloadArgs = @"";
                }

                String dstShell = Vismuta.Muta(deployFlags, srcBinary, payloadName, payloadExt, payloadArgs);
                txtDstShell.Text = dstShell;
            }
            finally
            {
                cmdCopyDstShell.Enabled = false; //TODO: Get clipboard working
                cmdMuta.Enabled = AreCurrentOptionsValid();
                txtArgs.Enabled = GetCurrentFlags().HasFlag(DeployMethodFlags.RunAfterDeploy);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        private static Byte[] ZipFiles(String[] filePaths)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (ZipOutputStream zipStream = new ZipOutputStream(memoryStream))
                {
                    zipStream.SetLevel(Vismuta.ZipStrength); //0-9
                    foreach (String filePath in filePaths)
                    {
                        String entryName = ZipEntry.CleanName(Path.GetFileName(filePath));
                        ZipEntry newEntry = new ZipEntry(entryName);
                        newEntry.Size = new FileInfo(filePath).Length;

                        zipStream.PutNextEntry(newEntry);
                        using (FileStream streamReader = File.OpenRead(filePath))
                            StreamUtils.Copy(streamReader, zipStream, new Byte[4096]);
                        zipStream.CloseEntry();
                    }
                    zipStream.IsStreamOwner = false;
                }
                memoryStream.Seek(0, SeekOrigin.Begin);
                Byte[] zipPayload = new Byte[memoryStream.Length];
                memoryStream.Read(zipPayload, 0, (Int32)memoryStream.Length);
                return zipPayload;
            }
        }



        private void cmdCopyDstShell_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtDstShell.Text);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ValidateCurrentOptions();
        }

        private void cmdAbout_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            MessageBox.Show( Application.ProductName + @" v" + Application.ProductVersion
                            + Environment.NewLine + fvi.LegalCopyright
                            + Environment.NewLine + VismutaLib.Properties.Resources.AboutLicense
                            + Environment.NewLine + Resources.frmMain_IconLicense +  @" (http://deviantdark.deviantart.com/)"
            , Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ValidateCurrentOptions()
        {
            cmdMuta.Enabled = AreCurrentOptionsValid();

            DeployMethodFlags deployFlags = GetCurrentFlags();
            if (deployFlags.HasFlag(DeployMethodFlags.PsExec))
            {
                lblUsage.Text = Resources.frmMain_AdminUsage;
                lblUsage.ForeColor = Color.Red;
            }
            else
            {
                lblUsage.Text = Resources.frmMain_StandardUsage;
                lblUsage.ForeColor = Color.Black;
            }
            txtArgs.Enabled = deployFlags.HasFlag(DeployMethodFlags.RunAfterDeploy) && AreCurrentOptionsValid();
        }

        private Boolean AreCurrentOptionsValid()
        {
            if (_selectedFiles == null && txtSrcPath.Text == String.Empty)
                return false;
            return Vismuta.IsValidDeployMethod(GetCurrentFlags());
        }

        private DeployMethodFlags GetCurrentFlags()
        {
            DeployMethodFlags flags = DeployMethodFlags.None;
            if(chkRunAfterDeploy.Checked)
                flags |= DeployMethodFlags.RunAfterDeploy;
            if (chkExecAsSystem.Checked)
                flags |= DeployMethodFlags.PsExec | DeployMethodFlags.RunAfterDeploy;
            if(chkInject.Checked)
                flags |= DeployMethodFlags.Inject;
            if(chkObfuscateName.Checked)
                flags |= DeployMethodFlags.ObfuscateName;
            if(_selectedFiles != null)
                flags |= DeployMethodFlags.Deflate;

            return flags;
        }

        private void chkRunAfterDeploy_CheckedChanged(object sender, EventArgs e)
        {
            ValidateCurrentOptions();
        }

        private void chkExecAsSystem_CheckedChanged(object sender, EventArgs e)
        {
            ValidateCurrentOptions();
        }

        private void chkInject_CheckedChanged(object sender, EventArgs e)
        {
            ValidateCurrentOptions();
        }

        private void chkObfuscateName_CheckedChanged(object sender, EventArgs e)
        {
            ValidateCurrentOptions();
        }
    }
}

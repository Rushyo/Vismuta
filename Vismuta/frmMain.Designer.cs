using System.Net.Mime;
using System.Windows.Forms;
using VismutaGUI.Properties;

namespace VismutaGUI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cmdMuta = new System.Windows.Forms.Button();
            this.txtSrcPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdCopyDstShell = new System.Windows.Forms.Button();
            this.cmdChooseSrc = new System.Windows.Forms.Button();
            this.txtDstShell = new System.Windows.Forms.RichTextBox();
            this.lblUsage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtArgs = new System.Windows.Forms.TextBox();
            this.cmdAbout = new System.Windows.Forms.Button();
            this.chkRunAfterDeploy = new System.Windows.Forms.CheckBox();
            this.chkExecAsSystem = new System.Windows.Forms.CheckBox();
            this.chkInject = new System.Windows.Forms.CheckBox();
            this.chkObfuscateName = new System.Windows.Forms.CheckBox();
            this.chkEncryptInteractive = new System.Windows.Forms.CheckBox();
            this.txtKeyphrase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRunFirst = new System.Windows.Forms.TextBox();
            this.lblRunFirst = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkObfuscateVariables = new System.Windows.Forms.CheckBox();
            this.chkEncryptNonInteractive = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdMuta
            // 
            resources.ApplyResources(this.cmdMuta, "cmdMuta");
            this.cmdMuta.Name = "cmdMuta";
            this.cmdMuta.Text = global::VismutaGUI.Properties.Resources.frmMain_GeneratePowerShell;
            this.cmdMuta.UseVisualStyleBackColor = true;
            this.cmdMuta.Click += new System.EventHandler(this.cmdMuta_Click);
            // 
            // txtSrcPath
            // 
            resources.ApplyResources(this.txtSrcPath, "txtSrcPath");
            this.txtSrcPath.Name = "txtSrcPath";
            this.txtSrcPath.TextChanged += new System.EventHandler(this.txtSrcPath_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cmdCopyDstShell
            // 
            resources.ApplyResources(this.cmdCopyDstShell, "cmdCopyDstShell");
            this.cmdCopyDstShell.Name = "cmdCopyDstShell";
            this.cmdCopyDstShell.Text = global::VismutaGUI.Properties.Resources.frmMain_CopyToClipboard;
            this.cmdCopyDstShell.UseVisualStyleBackColor = true;
            this.cmdCopyDstShell.Click += new System.EventHandler(this.cmdCopyDstShell_Click);
            // 
            // cmdChooseSrc
            // 
            resources.ApplyResources(this.cmdChooseSrc, "cmdChooseSrc");
            this.cmdChooseSrc.Name = "cmdChooseSrc";
            this.cmdChooseSrc.UseVisualStyleBackColor = true;
            this.cmdChooseSrc.Click += new System.EventHandler(this.cmdChooseSrc_Click);
            // 
            // txtDstShell
            // 
            this.txtDstShell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(36)))), ((int)(((byte)(86)))));
            this.txtDstShell.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtDstShell, "txtDstShell");
            this.txtDstShell.ForeColor = System.Drawing.Color.White;
            this.txtDstShell.Name = "txtDstShell";
            // 
            // lblUsage
            // 
            resources.ApplyResources(this.lblUsage, "lblUsage");
            this.lblUsage.Name = "lblUsage";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtArgs
            // 
            resources.ApplyResources(this.txtArgs, "txtArgs");
            this.txtArgs.Name = "txtArgs";
            // 
            // cmdAbout
            // 
            resources.ApplyResources(this.cmdAbout, "cmdAbout");
            this.cmdAbout.Name = "cmdAbout";
            this.cmdAbout.Text = global::VismutaGUI.Properties.Resources.frmMain_About;
            this.cmdAbout.UseVisualStyleBackColor = true;
            this.cmdAbout.Click += new System.EventHandler(this.cmdAbout_Click);
            // 
            // chkRunAfterDeploy
            // 
            resources.ApplyResources(this.chkRunAfterDeploy, "chkRunAfterDeploy");
            this.chkRunAfterDeploy.Name = "chkRunAfterDeploy";
            this.chkRunAfterDeploy.Text = global::VismutaGUI.Properties.Resources.frmMain_RunAfterDeploy;
            this.chkRunAfterDeploy.UseVisualStyleBackColor = true;
            this.chkRunAfterDeploy.CheckedChanged += new System.EventHandler(this.chkRunAfterDeploy_CheckedChanged);
            // 
            // chkExecAsSystem
            // 
            resources.ApplyResources(this.chkExecAsSystem, "chkExecAsSystem");
            this.chkExecAsSystem.Name = "chkExecAsSystem";
            this.chkExecAsSystem.Text = global::VismutaGUI.Properties.Resources.frmMain_ExecuteAsSystem;
            this.chkExecAsSystem.UseVisualStyleBackColor = true;
            this.chkExecAsSystem.CheckedChanged += new System.EventHandler(this.chkExecAsSystem_CheckedChanged);
            // 
            // chkInject
            // 
            resources.ApplyResources(this.chkInject, "chkInject");
            this.chkInject.Name = "chkInject";
            this.chkInject.Text = global::VismutaGUI.Properties.Resources.frmMain_UseInjection;
            this.chkInject.UseVisualStyleBackColor = true;
            this.chkInject.CheckedChanged += new System.EventHandler(this.chkInject_CheckedChanged);
            // 
            // chkObfuscateName
            // 
            resources.ApplyResources(this.chkObfuscateName, "chkObfuscateName");
            this.chkObfuscateName.Name = "chkObfuscateName";
            this.chkObfuscateName.Text = global::VismutaGUI.Properties.Resources.frmMain_ObfuscatePayloadName;
            this.chkObfuscateName.UseVisualStyleBackColor = true;
            this.chkObfuscateName.CheckedChanged += new System.EventHandler(this.chkObfuscateName_CheckedChanged);
            // 
            // chkEncryptInteractive
            // 
            resources.ApplyResources(this.chkEncryptInteractive, "chkEncryptInteractive");
            this.chkEncryptInteractive.Name = "chkEncryptInteractive";
            this.chkEncryptInteractive.UseVisualStyleBackColor = true;
            this.chkEncryptInteractive.CheckedChanged += new System.EventHandler(this.chkEncryptInteractive_CheckedChanged);
            // 
            // txtKeyphrase
            // 
            resources.ApplyResources(this.txtKeyphrase, "txtKeyphrase");
            this.txtKeyphrase.Name = "txtKeyphrase";
            this.txtKeyphrase.TextChanged += new System.EventHandler(this.txtKeyphrase_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtRunFirst
            // 
            this.txtRunFirst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(36)))), ((int)(((byte)(86)))));
            this.txtRunFirst.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtRunFirst, "txtRunFirst");
            this.txtRunFirst.ForeColor = System.Drawing.Color.White;
            this.txtRunFirst.Name = "txtRunFirst";
            // 
            // lblRunFirst
            // 
            resources.ApplyResources(this.lblRunFirst, "lblRunFirst");
            this.lblRunFirst.Name = "lblRunFirst";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VismutaGUI.Properties.Resources.vismutaicon;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // chkObfuscateVariables
            // 
            resources.ApplyResources(this.chkObfuscateVariables, "chkObfuscateVariables");
            this.chkObfuscateVariables.Name = "chkObfuscateVariables";
            this.chkObfuscateVariables.Text = global::VismutaGUI.Properties.Resources.frmMain_ObfuscateVariables;
            this.chkObfuscateVariables.UseVisualStyleBackColor = true;
            this.chkObfuscateVariables.CheckedChanged += new System.EventHandler(this.chkObfuscateVariables_CheckedChanged);
            // 
            // chkEncryptNonInteractive
            // 
            resources.ApplyResources(this.chkEncryptNonInteractive, "chkEncryptNonInteractive");
            this.chkEncryptNonInteractive.Name = "chkEncryptNonInteractive";
            this.chkEncryptNonInteractive.UseVisualStyleBackColor = true;
            this.chkEncryptNonInteractive.CheckedChanged += new System.EventHandler(this.chkEncryptNonInteractive_CheckedChanged);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.chkEncryptNonInteractive);
            this.Controls.Add(this.chkObfuscateVariables);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblRunFirst);
            this.Controls.Add(this.txtRunFirst);
            this.Controls.Add(this.txtKeyphrase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkEncryptInteractive);
            this.Controls.Add(this.chkObfuscateName);
            this.Controls.Add(this.chkInject);
            this.Controls.Add(this.chkExecAsSystem);
            this.Controls.Add(this.chkRunAfterDeploy);
            this.Controls.Add(this.cmdAbout);
            this.Controls.Add(this.txtArgs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblUsage);
            this.Controls.Add(this.txtDstShell);
            this.Controls.Add(this.cmdChooseSrc);
            this.Controls.Add(this.cmdCopyDstShell);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSrcPath);
            this.Controls.Add(this.cmdMuta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdMuta;
        private System.Windows.Forms.TextBox txtSrcPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdCopyDstShell;
        private System.Windows.Forms.Button cmdChooseSrc;
        private System.Windows.Forms.RichTextBox txtDstShell;
        private System.Windows.Forms.Label lblUsage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtArgs;
        private System.Windows.Forms.Button cmdAbout;
        private System.Windows.Forms.CheckBox chkRunAfterDeploy;
        private System.Windows.Forms.CheckBox chkExecAsSystem;
        private System.Windows.Forms.CheckBox chkInject;
        private CheckBox chkObfuscateName;
        private CheckBox chkEncryptInteractive;
        private TextBox txtKeyphrase;
        private Label label2;
        private TextBox txtRunFirst;
        private Label lblRunFirst;
        private PictureBox pictureBox1;
        private CheckBox chkObfuscateVariables;
        private CheckBox chkEncryptNonInteractive;
    }
}


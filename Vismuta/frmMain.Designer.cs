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
            this.SuspendLayout();
            // 
            // cmdMuta
            // 
            this.cmdMuta.Enabled = false;
            this.cmdMuta.Location = new System.Drawing.Point(12, 64);
            this.cmdMuta.Name = "cmdMuta";
            this.cmdMuta.Size = new System.Drawing.Size(363, 23);
            this.cmdMuta.TabIndex = 0;
            this.cmdMuta.Text = global::VismutaGUI.Properties.Resources.frmMain_GeneratePowerShell;
            this.cmdMuta.UseVisualStyleBackColor = true;
            this.cmdMuta.Click += new System.EventHandler(this.cmdMuta_Click);
            // 
            // txtSrcPath
            // 
            this.txtSrcPath.Location = new System.Drawing.Point(116, 12);
            this.txtSrcPath.Name = "txtSrcPath";
            this.txtSrcPath.Size = new System.Drawing.Size(227, 20);
            this.txtSrcPath.TabIndex = 1;
            this.txtSrcPath.TextChanged += new System.EventHandler(this.txtSrcPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Payload file(s)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Output";
            // 
            // cmdCopyDstShell
            // 
            this.cmdCopyDstShell.Enabled = false;
            this.cmdCopyDstShell.Location = new System.Drawing.Point(12, 244);
            this.cmdCopyDstShell.Name = "cmdCopyDstShell";
            this.cmdCopyDstShell.Size = new System.Drawing.Size(596, 23);
            this.cmdCopyDstShell.TabIndex = 8;
            this.cmdCopyDstShell.Text = global::VismutaGUI.Properties.Resources.frmMain_CopyToClipboard;
            this.cmdCopyDstShell.UseVisualStyleBackColor = true;
            this.cmdCopyDstShell.Click += new System.EventHandler(this.cmdCopyDstShell_Click);
            // 
            // cmdChooseSrc
            // 
            this.cmdChooseSrc.Location = new System.Drawing.Point(349, 9);
            this.cmdChooseSrc.Name = "cmdChooseSrc";
            this.cmdChooseSrc.Size = new System.Drawing.Size(26, 23);
            this.cmdChooseSrc.TabIndex = 9;
            this.cmdChooseSrc.Text = "...";
            this.cmdChooseSrc.UseVisualStyleBackColor = true;
            this.cmdChooseSrc.Click += new System.EventHandler(this.cmdChooseSrc_Click);
            // 
            // txtDstShell
            // 
            this.txtDstShell.BackColor = System.Drawing.Color.Teal;
            this.txtDstShell.ForeColor = System.Drawing.Color.White;
            this.txtDstShell.Location = new System.Drawing.Point(12, 128);
            this.txtDstShell.Name = "txtDstShell";
            this.txtDstShell.Size = new System.Drawing.Size(596, 110);
            this.txtDstShell.TabIndex = 10;
            this.txtDstShell.Text = "";
            // 
            // lblUsage
            // 
            this.lblUsage.AutoSize = true;
            this.lblUsage.Location = new System.Drawing.Point(12, 90);
            this.lblUsage.Name = "lblUsage";
            this.lblUsage.Size = new System.Drawing.Size(16, 13);
            this.lblUsage.TabIndex = 14;
            this.lblUsage.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Payload arguments";
            // 
            // txtArgs
            // 
            this.txtArgs.Location = new System.Drawing.Point(116, 38);
            this.txtArgs.Name = "txtArgs";
            this.txtArgs.Size = new System.Drawing.Size(258, 20);
            this.txtArgs.TabIndex = 17;
            // 
            // cmdAbout
            // 
            this.cmdAbout.Location = new System.Drawing.Point(614, 244);
            this.cmdAbout.Name = "cmdAbout";
            this.cmdAbout.Size = new System.Drawing.Size(75, 23);
            this.cmdAbout.TabIndex = 18;
            this.cmdAbout.Text = global::VismutaGUI.Properties.Resources.frmMain_About;
            this.cmdAbout.UseVisualStyleBackColor = true;
            this.cmdAbout.Click += new System.EventHandler(this.cmdAbout_Click);
            // 
            // chkRunAfterDeploy
            // 
            this.chkRunAfterDeploy.AutoSize = true;
            this.chkRunAfterDeploy.Location = new System.Drawing.Point(381, 13);
            this.chkRunAfterDeploy.Name = "chkRunAfterDeploy";
            this.chkRunAfterDeploy.Size = new System.Drawing.Size(104, 17);
            this.chkRunAfterDeploy.TabIndex = 19;
            this.chkRunAfterDeploy.Text = "Run after deploy";
            this.chkRunAfterDeploy.UseVisualStyleBackColor = true;
            this.chkRunAfterDeploy.CheckedChanged += new System.EventHandler(this.chkRunAfterDeploy_CheckedChanged);
            // 
            // chkExecAsSystem
            // 
            this.chkExecAsSystem.AutoSize = true;
            this.chkExecAsSystem.Location = new System.Drawing.Point(381, 40);
            this.chkExecAsSystem.Name = "chkExecAsSystem";
            this.chkExecAsSystem.Size = new System.Drawing.Size(242, 17);
            this.chkExecAsSystem.TabIndex = 20;
            this.chkExecAsSystem.Text = "Execute as SYSTEM (implies run after deploy)";
            this.chkExecAsSystem.UseVisualStyleBackColor = true;
            this.chkExecAsSystem.CheckedChanged += new System.EventHandler(this.chkExecAsSystem_CheckedChanged);
            // 
            // chkInject
            // 
            this.chkInject.AutoSize = true;
            this.chkInject.Location = new System.Drawing.Point(381, 64);
            this.chkInject.Name = "chkInject";
            this.chkInject.Size = new System.Drawing.Size(271, 17);
            this.chkInject.TabIndex = 21;
            this.chkInject.Text = global::VismutaGUI.Properties.Resources.frmMain_UseInjection;
            this.chkInject.UseVisualStyleBackColor = true;
            this.chkInject.CheckedChanged += new System.EventHandler(this.chkInject_CheckedChanged);
            // 
            // chkObfuscateName
            // 
            this.chkObfuscateName.AutoSize = true;
            this.chkObfuscateName.Location = new System.Drawing.Point(381, 88);
            this.chkObfuscateName.Name = "chkObfuscateName";
            this.chkObfuscateName.Size = new System.Drawing.Size(144, 17);
            this.chkObfuscateName.TabIndex = 22;
            this.chkObfuscateName.Text = "Obfuscate payload name";
            this.chkObfuscateName.UseVisualStyleBackColor = true;
            this.chkObfuscateName.CheckedChanged += new System.EventHandler(this.chkObfuscateName_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 276);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Microsoft® Visual Studio® 2015";
            this.Load += new System.EventHandler(this.frmMain_Load);
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
    }
}


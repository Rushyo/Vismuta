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
            this.chkEncryptPayload = new System.Windows.Forms.CheckBox();
            this.txtKeyphrase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRunFirst = new System.Windows.Forms.TextBox();
            this.lblRunFirst = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdMuta
            // 
            this.cmdMuta.Enabled = false;
            this.cmdMuta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdMuta.Location = new System.Drawing.Point(12, 105);
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
            this.label3.Location = new System.Drawing.Point(12, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Output";
            // 
            // cmdCopyDstShell
            // 
            this.cmdCopyDstShell.Enabled = false;
            this.cmdCopyDstShell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCopyDstShell.Location = new System.Drawing.Point(12, 334);
            this.cmdCopyDstShell.Name = "cmdCopyDstShell";
            this.cmdCopyDstShell.Size = new System.Drawing.Size(500, 23);
            this.cmdCopyDstShell.TabIndex = 8;
            this.cmdCopyDstShell.Text = global::VismutaGUI.Properties.Resources.frmMain_CopyToClipboard;
            this.cmdCopyDstShell.UseVisualStyleBackColor = true;
            this.cmdCopyDstShell.Click += new System.EventHandler(this.cmdCopyDstShell_Click);
            // 
            // cmdChooseSrc
            // 
            this.cmdChooseSrc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.txtDstShell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(36)))), ((int)(((byte)(86)))));
            this.txtDstShell.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDstShell.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDstShell.ForeColor = System.Drawing.Color.White;
            this.txtDstShell.Location = new System.Drawing.Point(12, 225);
            this.txtDstShell.Name = "txtDstShell";
            this.txtDstShell.Size = new System.Drawing.Size(500, 103);
            this.txtDstShell.TabIndex = 10;
            this.txtDstShell.Text = "";
            // 
            // lblUsage
            // 
            this.lblUsage.AutoSize = true;
            this.lblUsage.Location = new System.Drawing.Point(12, 146);
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
            this.cmdAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAbout.Location = new System.Drawing.Point(518, 334);
            this.cmdAbout.Name = "cmdAbout";
            this.cmdAbout.Size = new System.Drawing.Size(171, 23);
            this.cmdAbout.TabIndex = 18;
            this.cmdAbout.Text = global::VismutaGUI.Properties.Resources.frmMain_About;
            this.cmdAbout.UseVisualStyleBackColor = true;
            this.cmdAbout.Click += new System.EventHandler(this.cmdAbout_Click);
            // 
            // chkRunAfterDeploy
            // 
            this.chkRunAfterDeploy.AutoSize = true;
            this.chkRunAfterDeploy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkRunAfterDeploy.Location = new System.Drawing.Point(381, 13);
            this.chkRunAfterDeploy.Name = "chkRunAfterDeploy";
            this.chkRunAfterDeploy.Size = new System.Drawing.Size(102, 17);
            this.chkRunAfterDeploy.TabIndex = 19;
            this.chkRunAfterDeploy.Text = global::VismutaGUI.Properties.Resources.frmMain_RunAfterDeploy;
            this.chkRunAfterDeploy.UseVisualStyleBackColor = true;
            this.chkRunAfterDeploy.CheckedChanged += new System.EventHandler(this.chkRunAfterDeploy_CheckedChanged);
            // 
            // chkExecAsSystem
            // 
            this.chkExecAsSystem.AutoSize = true;
            this.chkExecAsSystem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkExecAsSystem.Location = new System.Drawing.Point(381, 40);
            this.chkExecAsSystem.Name = "chkExecAsSystem";
            this.chkExecAsSystem.Size = new System.Drawing.Size(240, 17);
            this.chkExecAsSystem.TabIndex = 20;
            this.chkExecAsSystem.Text = global::VismutaGUI.Properties.Resources.frmMain_ExecuteAsSystem;
            this.chkExecAsSystem.UseVisualStyleBackColor = true;
            this.chkExecAsSystem.CheckedChanged += new System.EventHandler(this.chkExecAsSystem_CheckedChanged);
            // 
            // chkInject
            // 
            this.chkInject.AutoSize = true;
            this.chkInject.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkInject.Location = new System.Drawing.Point(381, 64);
            this.chkInject.Name = "chkInject";
            this.chkInject.Size = new System.Drawing.Size(268, 17);
            this.chkInject.TabIndex = 21;
            this.chkInject.Text = global::VismutaGUI.Properties.Resources.frmMain_UseInjection;
            this.chkInject.UseVisualStyleBackColor = true;
            this.chkInject.CheckedChanged += new System.EventHandler(this.chkInject_CheckedChanged);
            // 
            // chkObfuscateName
            // 
            this.chkObfuscateName.AutoSize = true;
            this.chkObfuscateName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkObfuscateName.Location = new System.Drawing.Point(381, 88);
            this.chkObfuscateName.Name = "chkObfuscateName";
            this.chkObfuscateName.Size = new System.Drawing.Size(142, 17);
            this.chkObfuscateName.TabIndex = 22;
            this.chkObfuscateName.Text = global::VismutaGUI.Properties.Resources.frmMain_ObfuscatePayloadName;
            this.chkObfuscateName.UseVisualStyleBackColor = true;
            this.chkObfuscateName.CheckedChanged += new System.EventHandler(this.chkObfuscateName_CheckedChanged);
            // 
            // chkEncryptPayload
            // 
            this.chkEncryptPayload.AutoSize = true;
            this.chkEncryptPayload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkEncryptPayload.Location = new System.Drawing.Point(381, 111);
            this.chkEncryptPayload.Name = "chkEncryptPayload";
            this.chkEncryptPayload.Size = new System.Drawing.Size(159, 17);
            this.chkEncryptPayload.TabIndex = 23;
            this.chkEncryptPayload.Text = global::VismutaGUI.Properties.Resources.frmMain_EncryptPayloadInteractive;
            this.chkEncryptPayload.UseVisualStyleBackColor = true;
            this.chkEncryptPayload.CheckedChanged += new System.EventHandler(this.chkEncryptPayload_CheckedChanged);
            // 
            // txtKeyphrase
            // 
            this.txtKeyphrase.Enabled = false;
            this.txtKeyphrase.Location = new System.Drawing.Point(116, 65);
            this.txtKeyphrase.Name = "txtKeyphrase";
            this.txtKeyphrase.Size = new System.Drawing.Size(258, 20);
            this.txtKeyphrase.TabIndex = 25;
            this.txtKeyphrase.TextChanged += new System.EventHandler(this.txtKeyphrase_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Keyphrase";
            // 
            // txtRunFirst
            // 
            this.txtRunFirst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(36)))), ((int)(((byte)(86)))));
            this.txtRunFirst.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRunFirst.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRunFirst.ForeColor = System.Drawing.Color.White;
            this.txtRunFirst.Location = new System.Drawing.Point(12, 186);
            this.txtRunFirst.Name = "txtRunFirst";
            this.txtRunFirst.Size = new System.Drawing.Size(500, 15);
            this.txtRunFirst.TabIndex = 26;
            this.txtRunFirst.Visible = false;
            // 
            // lblRunFirst
            // 
            this.lblRunFirst.AutoSize = true;
            this.lblRunFirst.Location = new System.Drawing.Point(12, 170);
            this.lblRunFirst.Name = "lblRunFirst";
            this.lblRunFirst.Size = new System.Drawing.Size(425, 13);
            this.lblRunFirst.TabIndex = 27;
            this.lblRunFirst.Text = "Copy and run this FIRST, then either copy or type the keyphrase (Typing is more s" +
    "ecure!)";
            this.lblRunFirst.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VismutaGUI.Properties.Resources.vismutaicon;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(518, 225);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(695, 364);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblRunFirst);
            this.Controls.Add(this.txtRunFirst);
            this.Controls.Add(this.txtKeyphrase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkEncryptPayload);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Vismuta";
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
        private CheckBox chkEncryptPayload;
        private TextBox txtKeyphrase;
        private Label label2;
        private TextBox txtRunFirst;
        private Label lblRunFirst;
        private PictureBox pictureBox1;
    }
}


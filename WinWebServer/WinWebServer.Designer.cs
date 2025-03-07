namespace WinWebServer
{
    partial class WinWebServer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinWebServer));
            lblStatus = new Label();
            btnStart = new Button();
            btnStop = new Button();
            txtPort = new TextBox();
            chkPublic = new CheckBox();
            btnBrowseCert = new Button();
            txtCertPassword = new TextBox();
            txtCertPath = new TextBox();
            chkUseHttps = new CheckBox();
            btnOpenWwwroot = new Button();
            lblTitle = new Label();
            panel1 = new Panel();
            labelPanelDesc1 = new Label();
            lblInfoPort = new Label();
            panel2 = new Panel();
            lblPanelDesc2 = new Label();
            lblInfoCertPW = new Label();
            lblInfoCertPath = new Label();
            panel3 = new Panel();
            btnExportLog = new Button();
            lstLogs = new ListBox();
            lblPanelDesc3 = new Label();
            cleanupTimer = new System.Windows.Forms.Timer(components);
            panel5 = new Panel();
            lblInfoPanelDescWL = new Label();
            btnRemoveIP = new Button();
            chkEnableWhitelist = new CheckBox();
            btnAddIP = new Button();
            txtWhitelistIP = new TextBox();
            lstWhitelist = new ListBox();
            saveFileDialog1 = new SaveFileDialog();
            lstBlacklist = new ListBox();
            txtBlacklistIP = new TextBox();
            btnAddBlacklistIP = new Button();
            chkEnableBlacklist = new CheckBox();
            btnRemoveBlacklistIP = new Button();
            lblPanelBL = new Label();
            panel6 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(0, 27);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(165, 21);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Server Status: Stopped";
            // 
            // btnStart
            // 
            btnStart.Image = (Image)resources.GetObject("btnStart.Image");
            btnStart.ImageAlign = ContentAlignment.MiddleLeft;
            btnStart.Location = new Point(3, 55);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(90, 23);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start Server";
            btnStart.TextAlign = ContentAlignment.MiddleRight;
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.Image = (Image)resources.GetObject("btnStop.Image");
            btnStop.ImageAlign = ContentAlignment.MiddleLeft;
            btnStop.Location = new Point(99, 55);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(90, 23);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop Server";
            btnStop.TextAlign = ContentAlignment.MiddleRight;
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(59, 84);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(130, 23);
            txtPort.TabIndex = 3;
            txtPort.Text = "8080";
            // 
            // chkPublic
            // 
            chkPublic.AutoSize = true;
            chkPublic.Location = new Point(3, 26);
            chkPublic.Name = "chkPublic";
            chkPublic.Size = new Size(129, 19);
            chkPublic.TabIndex = 4;
            chkPublic.Text = "Allow public access";
            chkPublic.UseVisualStyleBackColor = true;
            // 
            // btnBrowseCert
            // 
            btnBrowseCert.Location = new Point(259, 71);
            btnBrowseCert.Name = "btnBrowseCert";
            btnBrowseCert.Size = new Size(75, 24);
            btnBrowseCert.TabIndex = 6;
            btnBrowseCert.Text = "Browse";
            btnBrowseCert.UseVisualStyleBackColor = true;
            btnBrowseCert.Click += btnBrowseCert_Click;
            // 
            // txtCertPassword
            // 
            txtCertPassword.Location = new Point(3, 120);
            txtCertPassword.Name = "txtCertPassword";
            txtCertPassword.Size = new Size(100, 23);
            txtCertPassword.TabIndex = 7;
            // 
            // txtCertPath
            // 
            txtCertPath.Location = new Point(3, 72);
            txtCertPath.Name = "txtCertPath";
            txtCertPath.ReadOnly = true;
            txtCertPath.Size = new Size(256, 23);
            txtCertPath.TabIndex = 8;
            // 
            // chkUseHttps
            // 
            chkUseHttps.AutoSize = true;
            chkUseHttps.Location = new Point(138, 26);
            chkUseHttps.Name = "chkUseHttps";
            chkUseHttps.Size = new Size(98, 19);
            chkUseHttps.TabIndex = 9;
            chkUseHttps.Text = "Enable HTTPS";
            chkUseHttps.UseVisualStyleBackColor = true;
            // 
            // btnOpenWwwroot
            // 
            btnOpenWwwroot.Image = (Image)resources.GetObject("btnOpenWwwroot.Image");
            btnOpenWwwroot.ImageAlign = ContentAlignment.TopCenter;
            btnOpenWwwroot.Location = new Point(0, 110);
            btnOpenWwwroot.Name = "btnOpenWwwroot";
            btnOpenWwwroot.Size = new Size(189, 47);
            btnOpenWwwroot.TabIndex = 10;
            btnOpenWwwroot.Text = "Open root folder";
            btnOpenWwwroot.TextAlign = ContentAlignment.BottomCenter;
            btnOpenWwwroot.UseVisualStyleBackColor = true;
            btnOpenWwwroot.Click += btnOpenWwwroot_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(248, 47);
            lblTitle.TabIndex = 11;
            lblTitle.Text = "WinWebServer";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(labelPanelDesc1);
            panel1.Controls.Add(lblInfoPort);
            panel1.Controls.Add(lblStatus);
            panel1.Controls.Add(btnOpenWwwroot);
            panel1.Controls.Add(btnStart);
            panel1.Controls.Add(btnStop);
            panel1.Controls.Add(txtPort);
            panel1.Location = new Point(17, 59);
            panel1.Name = "panel1";
            panel1.Size = new Size(337, 160);
            panel1.TabIndex = 12;
            // 
            // labelPanelDesc1
            // 
            labelPanelDesc1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPanelDesc1.Location = new Point(0, 0);
            labelPanelDesc1.Name = "labelPanelDesc1";
            labelPanelDesc1.Size = new Size(108, 23);
            labelPanelDesc1.TabIndex = 11;
            labelPanelDesc1.Text = "Server Settings";
            labelPanelDesc1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblInfoPort
            // 
            lblInfoPort.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfoPort.Location = new Point(0, 84);
            lblInfoPort.Name = "lblInfoPort";
            lblInfoPort.Size = new Size(50, 23);
            lblInfoPort.TabIndex = 4;
            lblInfoPort.Text = "Port:";
            lblInfoPort.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLightLight;
            panel2.Controls.Add(lblPanelDesc2);
            panel2.Controls.Add(lblInfoCertPW);
            panel2.Controls.Add(lblInfoCertPath);
            panel2.Controls.Add(chkUseHttps);
            panel2.Controls.Add(chkPublic);
            panel2.Controls.Add(txtCertPassword);
            panel2.Controls.Add(txtCertPath);
            panel2.Controls.Add(btnBrowseCert);
            panel2.Location = new Point(17, 225);
            panel2.Name = "panel2";
            panel2.Size = new Size(337, 168);
            panel2.TabIndex = 13;
            // 
            // lblPanelDesc2
            // 
            lblPanelDesc2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPanelDesc2.Location = new Point(0, 0);
            lblPanelDesc2.Name = "lblPanelDesc2";
            lblPanelDesc2.Size = new Size(203, 23);
            lblPanelDesc2.TabIndex = 12;
            lblPanelDesc2.Text = "HTTP / Certification Settings";
            lblPanelDesc2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblInfoCertPW
            // 
            lblInfoCertPW.AutoSize = true;
            lblInfoCertPW.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfoCertPW.Location = new Point(0, 97);
            lblInfoCertPW.Name = "lblInfoCertPW";
            lblInfoCertPW.Size = new Size(145, 20);
            lblInfoCertPW.TabIndex = 11;
            lblInfoCertPW.Text = "Certificate Password:";
            // 
            // lblInfoCertPath
            // 
            lblInfoCertPath.AutoSize = true;
            lblInfoCertPath.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfoCertPath.Location = new Point(0, 49);
            lblInfoCertPath.Name = "lblInfoCertPath";
            lblInfoCertPath.Size = new Size(128, 20);
            lblInfoCertPath.TabIndex = 10;
            lblInfoCertPath.Text = "Path to certificate:";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLightLight;
            panel3.Controls.Add(btnExportLog);
            panel3.Controls.Add(lstLogs);
            panel3.Controls.Add(lblPanelDesc3);
            panel3.Location = new Point(372, 59);
            panel3.Name = "panel3";
            panel3.Size = new Size(389, 334);
            panel3.TabIndex = 14;
            // 
            // btnExportLog
            // 
            btnExportLog.Location = new Point(311, 3);
            btnExportLog.Name = "btnExportLog";
            btnExportLog.Size = new Size(75, 23);
            btnExportLog.TabIndex = 14;
            btnExportLog.Text = "Export";
            btnExportLog.UseVisualStyleBackColor = true;
            btnExportLog.Click += btnExportLog_Click;
            // 
            // lstLogs
            // 
            lstLogs.FormattingEnabled = true;
            lstLogs.HorizontalScrollbar = true;
            lstLogs.Location = new Point(1, 30);
            lstLogs.Name = "lstLogs";
            lstLogs.Size = new Size(387, 304);
            lstLogs.TabIndex = 13;
            // 
            // lblPanelDesc3
            // 
            lblPanelDesc3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPanelDesc3.Location = new Point(0, 0);
            lblPanelDesc3.Name = "lblPanelDesc3";
            lblPanelDesc3.Size = new Size(42, 23);
            lblPanelDesc3.TabIndex = 12;
            lblPanelDesc3.Text = "Logs";
            lblPanelDesc3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cleanupTimer
            // 
            cleanupTimer.Interval = 60000;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ControlLightLight;
            panel5.Controls.Add(lblInfoPanelDescWL);
            panel5.Controls.Add(btnRemoveIP);
            panel5.Controls.Add(chkEnableWhitelist);
            panel5.Controls.Add(btnAddIP);
            panel5.Controls.Add(txtWhitelistIP);
            panel5.Controls.Add(lstWhitelist);
            panel5.Location = new Point(373, 399);
            panel5.Name = "panel5";
            panel5.Size = new Size(388, 173);
            panel5.TabIndex = 16;
            // 
            // lblInfoPanelDescWL
            // 
            lblInfoPanelDescWL.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfoPanelDescWL.Location = new Point(1, 0);
            lblInfoPanelDescWL.Name = "lblInfoPanelDescWL";
            lblInfoPanelDescWL.Size = new Size(67, 23);
            lblInfoPanelDescWL.TabIndex = 15;
            lblInfoPanelDescWL.Text = "Whitelist";
            lblInfoPanelDescWL.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnRemoveIP
            // 
            btnRemoveIP.Location = new Point(224, 149);
            btnRemoveIP.Name = "btnRemoveIP";
            btnRemoveIP.Size = new Size(75, 23);
            btnRemoveIP.TabIndex = 4;
            btnRemoveIP.Text = "Remove IP";
            btnRemoveIP.UseVisualStyleBackColor = true;
            btnRemoveIP.Click += btnRemoveIP_Click;
            // 
            // chkEnableWhitelist
            // 
            chkEnableWhitelist.AutoSize = true;
            chkEnableWhitelist.Location = new Point(279, 126);
            chkEnableWhitelist.Name = "chkEnableWhitelist";
            chkEnableWhitelist.Size = new Size(110, 19);
            chkEnableWhitelist.TabIndex = 3;
            chkEnableWhitelist.Text = "Enable Whitelist";
            chkEnableWhitelist.UseVisualStyleBackColor = true;
            chkEnableWhitelist.CheckedChanged += chkEnableWhitelist_CheckedChanged;
            // 
            // btnAddIP
            // 
            btnAddIP.Location = new Point(305, 149);
            btnAddIP.Name = "btnAddIP";
            btnAddIP.Size = new Size(80, 23);
            btnAddIP.TabIndex = 2;
            btnAddIP.Text = "Add IP";
            btnAddIP.UseVisualStyleBackColor = true;
            btnAddIP.Click += btnAddIP_Click;
            // 
            // txtWhitelistIP
            // 
            txtWhitelistIP.Location = new Point(1, 147);
            txtWhitelistIP.Name = "txtWhitelistIP";
            txtWhitelistIP.Size = new Size(217, 23);
            txtWhitelistIP.TabIndex = 1;
            // 
            // lstWhitelist
            // 
            lstWhitelist.FormattingEnabled = true;
            lstWhitelist.Location = new Point(1, 26);
            lstWhitelist.Name = "lstWhitelist";
            lstWhitelist.Size = new Size(387, 94);
            lstWhitelist.TabIndex = 0;
            // 
            // lstBlacklist
            // 
            lstBlacklist.FormattingEnabled = true;
            lstBlacklist.Location = new Point(1, 26);
            lstBlacklist.Name = "lstBlacklist";
            lstBlacklist.Size = new Size(333, 94);
            lstBlacklist.TabIndex = 0;
            // 
            // txtBlacklistIP
            // 
            txtBlacklistIP.Location = new Point(1, 147);
            txtBlacklistIP.Name = "txtBlacklistIP";
            txtBlacklistIP.Size = new Size(166, 23);
            txtBlacklistIP.TabIndex = 1;
            // 
            // btnAddBlacklistIP
            // 
            btnAddBlacklistIP.Location = new Point(254, 147);
            btnAddBlacklistIP.Name = "btnAddBlacklistIP";
            btnAddBlacklistIP.Size = new Size(80, 23);
            btnAddBlacklistIP.TabIndex = 2;
            btnAddBlacklistIP.Text = "Add IP";
            btnAddBlacklistIP.UseVisualStyleBackColor = true;
            btnAddBlacklistIP.Click += btnAddBlacklistIP_Click;
            // 
            // chkEnableBlacklist
            // 
            chkEnableBlacklist.AutoSize = true;
            chkEnableBlacklist.Location = new Point(230, 126);
            chkEnableBlacklist.Name = "chkEnableBlacklist";
            chkEnableBlacklist.Size = new Size(107, 19);
            chkEnableBlacklist.TabIndex = 3;
            chkEnableBlacklist.Text = "Enable Blacklist";
            chkEnableBlacklist.UseVisualStyleBackColor = true;
            chkEnableBlacklist.CheckedChanged += chkEnableBlacklist_CheckedChanged;
            // 
            // btnRemoveBlacklistIP
            // 
            btnRemoveBlacklistIP.Location = new Point(173, 147);
            btnRemoveBlacklistIP.Name = "btnRemoveBlacklistIP";
            btnRemoveBlacklistIP.Size = new Size(75, 23);
            btnRemoveBlacklistIP.TabIndex = 4;
            btnRemoveBlacklistIP.Text = "Remove IP";
            btnRemoveBlacklistIP.UseVisualStyleBackColor = true;
            btnRemoveBlacklistIP.Click += btnRemoveBlacklistIP_Click;
            // 
            // lblPanelBL
            // 
            lblPanelBL.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPanelBL.Location = new Point(0, 0);
            lblPanelBL.Name = "lblPanelBL";
            lblPanelBL.Size = new Size(63, 23);
            lblPanelBL.TabIndex = 14;
            lblPanelBL.Text = "Blacklist";
            lblPanelBL.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.ControlLightLight;
            panel6.Controls.Add(lblPanelBL);
            panel6.Controls.Add(btnRemoveBlacklistIP);
            panel6.Controls.Add(chkEnableBlacklist);
            panel6.Controls.Add(btnAddBlacklistIP);
            panel6.Controls.Add(txtBlacklistIP);
            panel6.Controls.Add(lstBlacklist);
            panel6.Location = new Point(17, 399);
            panel6.Name = "panel6";
            panel6.Size = new Size(337, 173);
            panel6.TabIndex = 17;
            // 
            // WinWebServer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 583);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lblTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "WinWebServer";
            Text = "WinWebServer";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStatus;
        private Button btnStart;
        private Button btnStop;
        private TextBox txtPort;
        private CheckBox chkPublic;
        private Button btnBrowseCert;
        private TextBox txtCertPassword;
        private TextBox txtCertPath;
        private CheckBox chkUseHttps;
        private Button btnOpenWwwroot;
        private Label lblTitle;
        private Panel panel1;
        private Label lblInfoPort;
        private Panel panel2;
        private Label lblInfoCertPW;
        private Label lblInfoCertPath;
        private Panel panel3;
        private Label labelPanelDesc1;
        private Label lblPanelDesc2;
        private Label lblPanelDesc3;
        private ListBox lstLogs;
        private System.Windows.Forms.Timer cleanupTimer;
        private Panel panel5;
        private TextBox txtWhitelistIP;
        private ListBox lstWhitelist;
        private CheckBox chkEnableWhitelist;
        private Button btnAddIP;
        private Button btnRemoveIP;
        private Label lblInfoPanelDescWL;
        private Button btnExportLog;
        private SaveFileDialog saveFileDialog1;
        private ListBox lstBlacklist;
        private TextBox txtBlacklistIP;
        private Button btnAddBlacklistIP;
        private CheckBox chkEnableBlacklist;
        private Button btnRemoveBlacklistIP;
        private Label lblPanelBL;
        private Panel panel6;
    }
}

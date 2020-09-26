namespace VysorProAuto
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mSM = new MetroFramework.Components.MetroStyleManager(this.components);
            this.progressProg = new MetroFramework.Controls.MetroProgressBar();
            this.labelInfo = new MetroFramework.Controls.MetroLabel();
            this.checkboxClose = new MetroFramework.Controls.MetroCheckBox();
            this.checkboxOldversion = new MetroFramework.Controls.MetroCheckBox();
            this.checkboxInstalled = new MetroFramework.Controls.MetroCheckBox();
            this.checkboxCrack = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.radioWindows = new MetroFramework.Controls.MetroRadioButton();
            this.radioChrome = new MetroFramework.Controls.MetroRadioButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.panelUpdateDownloading = new MetroFramework.Controls.MetroPanel();
            this.labelUpdate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelDownloading = new MetroFramework.Controls.MetroPanel();
            this.labelKB = new System.Windows.Forms.Label();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.FirewallcheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.firewallToggle = new MetroFramework.Controls.MetroToggle();
            this.comboVersion = new MetroFramework.Controls.MetroComboBox();
            this.buttonDownloadPackage = new MetroFramework.Controls.MetroButton();
            this.buttonCheckUpdates = new MetroFramework.Controls.MetroButton();
            this.buttonExit = new MetroFramework.Controls.MetroButton();
            this.buttonInstaller = new MetroFramework.Controls.MetroButton();
            this.buttonDeinstal = new MetroFramework.Controls.MetroButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mSM)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.panelUpdateDownloading.SuspendLayout();
            this.panelDownloading.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mSM
            // 
            this.mSM.Owner = this;
            this.mSM.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // progressProg
            // 
            resources.ApplyResources(this.progressProg, "progressProg");
            this.progressProg.Name = "progressProg";
            // 
            // labelInfo
            // 
            resources.ApplyResources(this.labelInfo, "labelInfo");
            this.labelInfo.Name = "labelInfo";
            // 
            // checkboxClose
            // 
            resources.ApplyResources(this.checkboxClose, "checkboxClose");
            this.checkboxClose.Name = "checkboxClose";
            this.checkboxClose.UseSelectable = true;
            // 
            // checkboxOldversion
            // 
            resources.ApplyResources(this.checkboxOldversion, "checkboxOldversion");
            this.checkboxOldversion.Name = "checkboxOldversion";
            this.checkboxOldversion.UseSelectable = true;
            // 
            // checkboxInstalled
            // 
            resources.ApplyResources(this.checkboxInstalled, "checkboxInstalled");
            this.checkboxInstalled.Name = "checkboxInstalled";
            this.checkboxInstalled.UseSelectable = true;
            // 
            // checkboxCrack
            // 
            resources.ApplyResources(this.checkboxCrack, "checkboxCrack");
            this.checkboxCrack.Name = "checkboxCrack";
            this.checkboxCrack.UseSelectable = true;
            // 
            // metroLabel3
            // 
            resources.ApplyResources(this.metroLabel3, "metroLabel3");
            this.metroLabel3.Name = "metroLabel3";
            // 
            // radioWindows
            // 
            resources.ApplyResources(this.radioWindows, "radioWindows");
            this.radioWindows.Checked = true;
            this.radioWindows.Name = "radioWindows";
            this.radioWindows.TabStop = true;
            this.radioWindows.UseSelectable = true;
            this.radioWindows.CheckedChanged += new System.EventHandler(this.radioWindows_CheckedChanged);
            // 
            // radioChrome
            // 
            resources.ApplyResources(this.radioChrome, "radioChrome");
            this.radioChrome.Name = "radioChrome";
            this.radioChrome.UseSelectable = true;
            this.radioChrome.CheckedChanged += new System.EventHandler(this.radioChrome_CheckedChanged);
            // 
            // metroPanel1
            // 
            resources.ApplyResources(this.metroPanel1, "metroPanel1");
            this.metroPanel1.Controls.Add(this.panelUpdateDownloading);
            this.metroPanel1.Controls.Add(this.panelDownloading);
            this.metroPanel1.Controls.Add(this.metroButton2);
            this.metroPanel1.Controls.Add(this.metroPanel3);
            this.metroPanel1.Controls.Add(this.metroPanel2);
            this.metroPanel1.Controls.Add(this.buttonDownloadPackage);
            this.metroPanel1.Controls.Add(this.buttonCheckUpdates);
            this.metroPanel1.Controls.Add(this.buttonExit);
            this.metroPanel1.Controls.Add(this.buttonInstaller);
            this.metroPanel1.Controls.Add(this.buttonDeinstal);
            this.metroPanel1.Controls.Add(this.labelInfo);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // panelUpdateDownloading
            // 
            this.panelUpdateDownloading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUpdateDownloading.Controls.Add(this.labelUpdate);
            this.panelUpdateDownloading.Controls.Add(this.label3);
            this.panelUpdateDownloading.HorizontalScrollbarBarColor = true;
            this.panelUpdateDownloading.HorizontalScrollbarHighlightOnWheel = false;
            this.panelUpdateDownloading.HorizontalScrollbarSize = 10;
            resources.ApplyResources(this.panelUpdateDownloading, "panelUpdateDownloading");
            this.panelUpdateDownloading.Name = "panelUpdateDownloading";
            this.panelUpdateDownloading.VerticalScrollbarBarColor = true;
            this.panelUpdateDownloading.VerticalScrollbarHighlightOnWheel = false;
            this.panelUpdateDownloading.VerticalScrollbarSize = 10;
            // 
            // labelUpdate
            // 
            resources.ApplyResources(this.labelUpdate, "labelUpdate");
            this.labelUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(19)))));
            this.labelUpdate.ForeColor = System.Drawing.Color.White;
            this.labelUpdate.Name = "labelUpdate";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(19)))));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // panelDownloading
            // 
            this.panelDownloading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDownloading.Controls.Add(this.labelKB);
            this.panelDownloading.Controls.Add(this.metroButton1);
            this.panelDownloading.Controls.Add(this.label1);
            this.panelDownloading.HorizontalScrollbarBarColor = true;
            this.panelDownloading.HorizontalScrollbarHighlightOnWheel = false;
            this.panelDownloading.HorizontalScrollbarSize = 10;
            resources.ApplyResources(this.panelDownloading, "panelDownloading");
            this.panelDownloading.Name = "panelDownloading";
            this.panelDownloading.VerticalScrollbarBarColor = true;
            this.panelDownloading.VerticalScrollbarHighlightOnWheel = false;
            this.panelDownloading.VerticalScrollbarSize = 10;
            // 
            // labelKB
            // 
            resources.ApplyResources(this.labelKB, "labelKB");
            this.labelKB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(19)))));
            this.labelKB.ForeColor = System.Drawing.Color.White;
            this.labelKB.Name = "labelKB";
            // 
            // metroButton1
            // 
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            resources.ApplyResources(this.metroButton1, "metroButton1");
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click_2);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(19)))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // metroButton2
            // 
            resources.ApplyResources(this.metroButton2, "metroButton2");
            this.metroButton2.DisplayFocus = true;
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click_1);
            this.metroButton2.MouseHover += new System.EventHandler(this.metroButton2_MouseHover);
            // 
            // metroPanel3
            // 
            resources.ApplyResources(this.metroPanel3, "metroPanel3");
            this.metroPanel3.Controls.Add(this.FirewallcheckBox);
            this.metroPanel3.Controls.Add(this.checkboxClose);
            this.metroPanel3.Controls.Add(this.checkboxInstalled);
            this.metroPanel3.Controls.Add(this.checkboxCrack);
            this.metroPanel3.Controls.Add(this.checkboxOldversion);
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            this.metroPanel3.MouseHover += new System.EventHandler(this.metroPanel3_MouseHover);
            // 
            // FirewallcheckBox
            // 
            resources.ApplyResources(this.FirewallcheckBox, "FirewallcheckBox");
            this.FirewallcheckBox.Name = "FirewallcheckBox";
            this.FirewallcheckBox.UseSelectable = true;
            // 
            // metroPanel2
            // 
            resources.ApplyResources(this.metroPanel2, "metroPanel2");
            this.metroPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel2.Controls.Add(this.metroLabel2);
            this.metroPanel2.Controls.Add(this.metroLabel1);
            this.metroPanel2.Controls.Add(this.firewallToggle);
            this.metroPanel2.Controls.Add(this.comboVersion);
            this.metroPanel2.Controls.Add(this.radioWindows);
            this.metroPanel2.Controls.Add(this.metroLabel3);
            this.metroPanel2.Controls.Add(this.radioChrome);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroLabel2
            // 
            resources.ApplyResources(this.metroLabel2, "metroLabel2");
            this.metroLabel2.Name = "metroLabel2";
            // 
            // metroLabel1
            // 
            resources.ApplyResources(this.metroLabel1, "metroLabel1");
            this.metroLabel1.Name = "metroLabel1";
            // 
            // firewallToggle
            // 
            this.firewallToggle.Checked = true;
            this.firewallToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.firewallToggle.DisplayStatus = false;
            resources.ApplyResources(this.firewallToggle, "firewallToggle");
            this.firewallToggle.Name = "firewallToggle";
            this.firewallToggle.UseSelectable = true;
            // 
            // comboVersion
            // 
            resources.ApplyResources(this.comboVersion, "comboVersion");
            this.comboVersion.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.comboVersion.FormattingEnabled = true;
            this.comboVersion.Items.AddRange(new object[] {
            resources.GetString("comboVersion.Items"),
            resources.GetString("comboVersion.Items1"),
            resources.GetString("comboVersion.Items2")});
            this.comboVersion.Name = "comboVersion";
            this.comboVersion.UseSelectable = true;
            // 
            // buttonDownloadPackage
            // 
            resources.ApplyResources(this.buttonDownloadPackage, "buttonDownloadPackage");
            this.buttonDownloadPackage.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.buttonDownloadPackage.Name = "buttonDownloadPackage";
            this.buttonDownloadPackage.UseSelectable = true;
            this.buttonDownloadPackage.Click += new System.EventHandler(this.buttonDownloadPackage_Click);
            this.buttonDownloadPackage.MouseHover += new System.EventHandler(this.buttonDownloadPackage_MouseHover);
            // 
            // buttonCheckUpdates
            // 
            resources.ApplyResources(this.buttonCheckUpdates, "buttonCheckUpdates");
            this.buttonCheckUpdates.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.buttonCheckUpdates.Name = "buttonCheckUpdates";
            this.buttonCheckUpdates.UseSelectable = true;
            this.buttonCheckUpdates.Click += new System.EventHandler(this.buttonCheckUpdates_Click);
            this.buttonCheckUpdates.MouseHover += new System.EventHandler(this.buttonCheckUpdates_MouseHover);
            // 
            // buttonExit
            // 
            resources.ApplyResources(this.buttonExit, "buttonExit");
            this.buttonExit.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.UseSelectable = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonInstaller
            // 
            resources.ApplyResources(this.buttonInstaller, "buttonInstaller");
            this.buttonInstaller.Name = "buttonInstaller";
            this.buttonInstaller.UseSelectable = true;
            this.buttonInstaller.Click += new System.EventHandler(this.buttonInstaller_Click);
            // 
            // buttonDeinstal
            // 
            resources.ApplyResources(this.buttonDeinstal, "buttonDeinstal");
            this.buttonDeinstal.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.buttonDeinstal.Name = "buttonDeinstal";
            this.buttonDeinstal.UseSelectable = true;
            this.buttonDeinstal.Click += new System.EventHandler(this.buttonDeinstaller);
            this.buttonDeinstal.MouseHover += new System.EventHandler(this.buttonDeinstal_MouseHover);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.No;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.progressProg);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mSM)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.panelUpdateDownloading.ResumeLayout(false);
            this.panelUpdateDownloading.PerformLayout();
            this.panelDownloading.ResumeLayout(false);
            this.panelDownloading.PerformLayout();
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel3.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager mSM;
        private MetroFramework.Controls.MetroLabel labelInfo;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroButton buttonInstaller;
        public MetroFramework.Controls.MetroProgressBar progressProg;
        private MetroFramework.Controls.MetroButton buttonDeinstal;
        private MetroFramework.Controls.MetroButton buttonExit;
        private MetroFramework.Controls.MetroButton buttonCheckUpdates;
        private MetroFramework.Controls.MetroButton buttonDownloadPackage;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private MetroFramework.Controls.MetroPanel panelDownloading;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.Label labelKB;
        private MetroFramework.Controls.MetroPanel panelUpdateDownloading;
        private System.Windows.Forms.Label labelUpdate;
        private System.Windows.Forms.Label label3;
        public MetroFramework.Controls.MetroCheckBox checkboxCrack;
        public MetroFramework.Controls.MetroCheckBox checkboxInstalled;
        public MetroFramework.Controls.MetroCheckBox checkboxOldversion;
        public MetroFramework.Controls.MetroCheckBox checkboxClose;
        public MetroFramework.Controls.MetroRadioButton radioChrome;
        public MetroFramework.Controls.MetroRadioButton radioWindows;
        public MetroFramework.Controls.MetroComboBox comboVersion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        public MetroFramework.Controls.MetroCheckBox FirewallcheckBox;
        public MetroFramework.Controls.MetroToggle firewallToggle;
    }
}


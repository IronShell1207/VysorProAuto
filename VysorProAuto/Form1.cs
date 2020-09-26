using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using MetroFramework;
using System.Net;
using EasyVysorPro;
using EzShell;
namespace VysorProAuto
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        CheckUpdates CheckUpdate;
        Installer installer;
        PackageDownloader packageDownloader;
        public Form1 form1;
        SwMsgDwnldUpt MsgDwnldUpt;
        ShowMessageDownloader ds;
        ShowMessaged messaged;
        ToolTip toolTip = new ToolTip()
        {
            UseFading = true,
            UseAnimation = true,
            
        };
        public Form1()
        {
            InitializeComponent();
            form1 = this;
            this.StyleManager = mSM;
            ds = messageBoxCaller; 
            mSM.Style = MetroFramework.MetroColorStyle.Purple;
            mSM.Theme = MetroFramework.MetroThemeStyle.Dark;
            comboVersion.SelectedIndex = 0;
            MsgDwnldUpt = messageBoxCaller;
            messaged = messageBoxCaller;
            installer = new Installer(ref form1, messaged, progressProg);
            CheckUpdate = new CheckUpdates("EasyVysorPro", Application.ProductVersion,Constants.vysorServerDownload,
                MsgDwnldUpt, progressProg, notifyIcon1, panelUpdateDownloading, labelUpdate);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(420, 384);
            this.Focus();
            
            var proc1 = new Thread(() =>
            {
                string Ver = CheckUpdate.MsgUpdateAvailable();
                if (Ver != null)
                    notifyIcon1.ShowBalloonTip(3000, "Update available " + Ver,
                        "Click on this notification to see more", ToolTipIcon.Info);
            })
            {
                IsBackground = true
            };
            proc1.Start();
            panelDownloading.Location = new Point(0, 182); //195; 57
            panelUpdateDownloading.Location = new Point(0, 182);
            this.Text = this.Text + " - " + Application.ProductVersion;
        }
        public void NotifyMessageCaller(string Message, string Header)
        {
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(3000, Message, Header, ToolTipIcon.Info);
        }
        public void EnablerDisablerViaInstall(bool states)
        {
            List<Control> allEras = new List<Control> { radioWindows, radioChrome, comboVersion, buttonDeinstal,
                buttonInstaller, buttonExit, metroButton2, buttonDownloadPackage, buttonCheckUpdates };
            foreach (Control control in allEras)
            {
                if (control.InvokeRequired) control.Invoke(new Action(() => control.Enabled = states));
                else control.Enabled = states;
            }
        }
        public DialogResult messageBoxCaller(string message, string header, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            Thread.Sleep(100);
            DialogResult r = DialogResult.Cancel;
            form1.Invoke(new Action(() =>
                r = MetroMessageBox.Show(form1, message, header, buttons, icon, 300))); 
            return r;
        }
        public void ProgressBarInvoker(int sc)//, ProgressBarStyle progressBarStyle)
        {
            progressProg.Invoke(new Action(() => progressProg.Value = sc));
        }
        public void CheckBoxInvoker(Control checkbox, bool status)
        {
            checkbox.Invoke(new Action(() => { 
                var obj1 = (CheckBox)checkbox;
                obj1.Checked = status; }));
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void metroButton3_Click(object sender, EventArgs e)
        {
            Process.Start(Constants.wifiADBHelperLinq);
        }
        void ClearSelection()
        {
            List<CheckBox> chs = new List<CheckBox> { checkboxClose, checkboxCrack, checkboxInstalled, checkboxOldversion };
            foreach (CheckBox check in chs)
                check.Invoke(new Action(() =>  check.Checked = false));
        }
        private void radioWindows_CheckedChanged(object sender, EventArgs e)
        {
            if (radioWindows.Checked)
            {
                comboVersion.SelectedIndex = 1;
                comboVersion.Enabled = true;
            }
        }
        private void radioChrome_CheckedChanged(object sender, EventArgs e)
        {
            if (radioChrome.Checked)
            {
                comboVersion.SelectedIndex = 1;
                comboVersion.Enabled = false;
            }
        }
        public void ProgressBarUser(int value)
        {
            progressProg.Invoke(new Action(() => progressProg.ProgressBarStyle = ProgressBarStyle.Marquee));
        }
        private void buttonInstaller_Click(object sender, EventArgs e)
        {      
            var proc = new Thread(() =>
            {
                ElementsZeroider();
                EnablerDisablerViaInstall(false);
                installer.InstallerProc();
                EnablerDisablerViaInstall(true);
            });
            proc.SetApartmentState(ApartmentState.STA);
            proc.Start();
        }
        public void ElementsZeroider()
        {
            ProgressBarInvoker(0);
            ClearSelection();
        }
        
        private void buttonDeinstaller(object sender, EventArgs e)
        {
            EnablerDisablerViaInstall(false);
            ElementsZeroider();
            var proc = new Thread(() => installer.VysorRemover());
            proc.Start();
            EnablerDisablerViaInstall(true);
        }
        public void CheckBoxChecker(int id, bool State)
        {
            List<CheckBox> checkBoxes = new List<CheckBox> { checkboxClose, checkboxOldversion, checkboxInstalled, checkboxCrack };
            checkBoxes[id].Invoke(new Action(() => checkBoxes[id].Checked = State));
            ProgressBarInvoker(25 * (id + 1));
        }
        private void buttonDownloadPackage_Click(object sender, EventArgs e)
        {
            PackageDownloader();
        }
        public void PackageDownloader()
        {
            packageDownloader = new PackageDownloader(ref form1, ds, progressProg, panelDownloading, labelKB, "Vysor-222inst.exe",
                 Constants.vysorPackageLinq);
            ElementsZeroider();
            new Thread(() => packageDownloader.VysorPackageDownloader()).Start();
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void buttonCheckUpdates_Click(object sender, EventArgs e)
        {
            CheckUpdate.UpdaterProg(MsgDwnldUpt);
        }
        private void metroButton1_Click_2(object sender, EventArgs e)
        {
            packageDownloader.client.CancelAsync();
            panelDownloading.Invoke(new Action(() => panelDownloading.Visible = false));
            EnablerDisablerViaInstall(true);
        }
        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            buttonCheckUpdates_Click(sender, e);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Visible = false;
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                messageBoxCaller("WHAT DID YOU DO?\nWHAT DID YOU DO?\nWHAT DID YOU DO?\nWHAT DID YOU DO?\nWHAT DID YOU DO?\nWHAT DID YOU DO?\nWHAT DID YOU DO?\nWHAT DID YOU DO?\nWHAT DID YOU DO?\nWHAT DID YOU DO?\nWHAT DID YOU DO?\n", "WHAT DID YOU DO? WHAT DID YOU DO?WHAT DID YOU DO?\nWHAT DID YOU DO?\nWHAT DID YOU DO?", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void buttonDownloadPackage_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(buttonDownloadPackage, "Click to download the Vysor installer package from official website.");
        }

        private void buttonCheckUpdates_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(buttonCheckUpdates, "Click for check updates for the patcher");
        }

        private void buttonDeinstal_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(buttonDeinstal, "Completely removes your Vysor from AppData folders. It will not removing your chrome's app");
        }

        private void metroPanel3_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(metroPanel3, "These are just patch installation phases.");
        }

        private void metroButton2_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(metroButton2, "Check out the dark theme for the Vysor! Click on the button");
        }

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=nbr1fY8f46Q");
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            FireWaller fw = new FireWaller();
            fw.firewalldown();
        }


    }
}

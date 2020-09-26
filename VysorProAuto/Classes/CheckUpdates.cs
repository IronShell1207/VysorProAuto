using MetroFramework;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using VysorProAuto;

namespace EzShell
{
    public delegate DialogResult ShowMessageDownloade(string message, string header, MessageBoxButtons buttons, MessageBoxIcon icon);
    public delegate DialogResult SwMsgDwnldUpt(string message, string header, MessageBoxButtons buttons, MessageBoxIcon icon);
    public class CheckUpdates
    {
        private static string GetRemoteVerLinq = Constants.link + @"/Files/version.xml";
        private static string GetReleaseNotesLinq = Constants.link + @"/Files/news.xml";
        public static string AppName { get; set; }
        private static string RemoteVersion { get { return RemoteVer(); } }
        private static string ThisVersion { get; set; }
        private static double RemoteVerDouble { get { return Convert.ToDouble(RemoteVer().Replace(".", "")); } }
        private static double ThisVerDouble { get { return Convert.ToDouble(ThisVersion.Replace(".", "")); } }
        private static SwMsgDwnldUpt swMsg { get; set; }
        public static MetroFramework.Controls.MetroProgressBar progressBar;
        public static Panel panelProgress;
        public static Label labelProgress;
        private static NotifyIcon notifyIcon;
        public static string UrlLinq { get; set; }
        public CheckUpdates(string _AppName, string _ThisVers, string _UrlLinq, SwMsgDwnldUpt _sw, MetroFramework.Controls.MetroProgressBar _progressBar, NotifyIcon notify, Panel panel, Label labelU)
        {
            progressBar = _progressBar;
            AppName = _AppName;
            ThisVersion = _ThisVers;
            UrlLinq = _UrlLinq;
            swMsg = _sw;
            notifyIcon = notify;
            panelProgress = panel;
            labelProgress = labelU;
        }

        // tag
       
        public void UpdaterProg(SwMsgDwnldUpt swMs)
        {
            try
            {
                if (ThisVerDouble < RemoteVerDouble)
                {
                    if (DialogResult.Yes == swMs("New version detected (" + RemoteVersion + ")\nThe application will be automatically updated and restarted\nWhat new:\n" +
                        WhatNewVer(swMs), AppName + " v" + ThisVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        panelProgress.Invoke(new Action(()=> panelProgress.Visible = true));
                        var ClientDownloader = new WebClient();
                        ClientDownloader.DownloadProgressChanged += new DownloadProgressChangedEventHandler(download_ProgressChanged);
                        ClientDownloader.DownloadFileCompleted += new AsyncCompletedEventHandler(download_Completed);
                        ClientDownloader.DownloadFileAsync(new Uri(@UrlLinq), AppName + ".zip");
                    }
                }
                else if (ThisVerDouble == RemoteVerDouble || ThisVerDouble > RemoteVerDouble)
                    swMs("You using the lastest version!\nCurrent version:  " + ThisVersion, "No updates available!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                swMs(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static string WhatNewVer(SwMsgDwnldUpt swMsgDwnld)
        {
            try
            {
                XmlDocument docUpdates = new XmlDocument();
                docUpdates.Load(GetReleaseNotesLinq);
                return docUpdates.GetElementsByTagName(AppName)[0].InnerText;
            }
            catch (Exception ex)
            {
                //swMsgDwnld(ex.Message, "Can't get release notes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "\nError.\nCan't load update notes";
            }
        }
        private static string RemoteVer()
        {
            XmlDocument docVersion = new XmlDocument();
            try
            {
                docVersion.Load(GetRemoteVerLinq);
                var RemoteVers = docVersion.GetElementsByTagName(AppName)[0].InnerText;
                return RemoteVers;
            }
            catch (Exception)
            {
                return "0";
            }
        }
        public string MsgUpdateAvailable()
        {
            Thread.Sleep(1500);
            if (ThisVerDouble < RemoteVerDouble)
            {
                return RemoteVersion;
            }
            return null;
        }
        private void Notify_BalloonTipClicked(object sender, EventArgs e)
        {
            UpdaterProg(swMsg);
        }
        private static void download_ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Invoke(new Action(() =>  progressBar.Value = e.ProgressPercentage));
            labelProgress.Invoke(new Action(() =>labelProgress.Text = Installer.SizeSuffix(e.BytesReceived) + " / " + Installer.SizeSuffix(e.TotalBytesToReceive)));
        }
        private static void download_Completed(object sender, AsyncCompletedEventArgs e)
        {
            panelProgress.Invoke(new Action(() => panelProgress.Visible = false));
            try
            {
                if (File.Exists("updater.exe"))
                {
                    Process.Start("updater.exe", AppName);
                    Thread.Sleep(500);
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    if (DialogResult.Yes== swMsg("Updater.exe not founded! Download the updater?","Attention",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation))
                    {
                        var ClientDownloader = new WebClient();
                        ClientDownloader.DownloadProgressChanged += new DownloadProgressChangedEventHandler(download_ProgressChanged);
                        ClientDownloader.DownloadFileCompleted += new AsyncCompletedEventHandler(download_Completed);
                        ClientDownloader.DownloadFileAsync(new Uri(Constants.updaterexelink),"updater.exe");
                    }
                }
              
            }
            catch (Win32Exception ex)
            {
                swMsg("Updater.exe not founded! " +
                    "Please download the lastest version of this patcher from my website\n"+ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

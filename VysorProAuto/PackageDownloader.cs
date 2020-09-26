using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;
using VysorProAuto;
using EasyVysorPro;

namespace EzShell
{
   // public delegate void ProgressDownload(int sc);
    public delegate DialogResult ShowMessageDownloader(string message, string header, MessageBoxButtons buttons, MessageBoxIcon icon);

    public class PackageDownloader
    {
        private string FileNameDownload;
        private string LinqFileDownload;
        private Form1 form1;
        private ShowMessageDownloader swDownl;
        private Panel panelD;
        private MetroFramework.Controls.MetroProgressBar progressBar;
        private Label labelIndicator;
        public WebClient client;
        public PackageDownloader(ref Form1 Method, ShowMessageDownloader mesD,
            MetroFramework.Controls.MetroProgressBar pb,Panel pan, Label labelInd, string FileName,string LinqFile)
        {
            FileNameDownload = FileName;
            LinqFileDownload = LinqFile;
            form1 = Method;
            swDownl = mesD;
            progressBar = pb;
            labelIndicator = labelInd;
            panelD = pan;
        }
        
        public void VysorPackageDownloader()
        {    
            if (DialogResult.OK == swDownl(MainStringsRes.VysorPacDown, MainStringsRes.DownVysor, MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                if (File.Exists(FileNameDownload)) File.Delete(FileNameDownload);
                panelD.Invoke(new Action(()=> panelD.Visible = true));
                form1.EnablerDisablerViaInstall(false);
                client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(download_ProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(download_Completed);
                client.DownloadFileAsync(new Uri(LinqFileDownload), FileNameDownload);
            }
            return;
        }
        private void download_Completed(object sender, AsyncCompletedEventArgs e)
        {
            form1.EnablerDisablerViaInstall(true);
            panelD.Invoke(new Action(() => panelD.Visible = false));
            string message = MainStringsRes.DownVysorComplete;
            MessageBoxIcon ic = MessageBoxIcon.Information;
            if (e.Error != null){ message =  e.Error.Message; ic = MessageBoxIcon.Error; }
            if (e.Cancelled) { message = "Download canceled by user"; ic = MessageBoxIcon.Exclamation; }
            
            swDownl(message, "Downloader the Vysor Package", MessageBoxButtons.OK, ic);// MainStringsRes.DownVysorComplete
        }
        private void download_ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try { labelIndicator.Invoke(new Action(() => labelIndicator.Text = Installer.SizeSuffix(e.BytesReceived) + " / " + Installer.SizeSuffix(e.TotalBytesToReceive)));
                  progressBar.Invoke(new Action(() => progressBar.Value = e.ProgressPercentage)); }
            catch (Exception d) {
                  swDownl(d.Message, MainStringsRes.Error, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
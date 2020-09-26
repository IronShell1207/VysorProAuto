using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyVysorPro;
using VysorProAuto;
using MetroFramework;
using EzShell;

namespace VysorProAuto
{
    public delegate DialogResult ShowMessaged(string message, string header, MessageBoxButtons buttons, MessageBoxIcon icon);

    public class Installer
    {
        private Form1 _form1;
        private MetroFramework.Controls.MetroProgressBar progressBar;
        public ShowMessaged messaged;
        public Installer(ref Form1 form,ShowMessaged showMsg,MetroFramework.Controls.MetroProgressBar pb)
        {
            _form1 = form;
            progressBar = pb;
            messaged = showMsg;
        }
        public bool InvolkerRadio(RadioButton ctrls)
        {
            bool checkInfo = false;
            ctrls.Invoke(new Action(() => checkInfo = ctrls.Checked));
            return checkInfo;
        }
        public int InvolkerCombo(ComboBox ctrls)
        {
            int index = 0;
            ctrls.Invoke(new Action(() => index = ctrls.SelectedIndex));
            return index;
        }
        public void ProgressBarInvoker(int sc)//, ProgressBarStyle progressBarStyle)
        {
            progressBar.Invoke(new Action(() => progressBar.Value = sc));
        }
        public void InstallerProc()
        {
            if (InvolkerRadio(_form1.radioWindows))
                switch (InvolkerCombo(_form1.comboVersion))
                {
                    case 0:
                        if (DialogResult.OK == messaged(MainStringsRes.Win212VysorQ, "Vysor Pro installer", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                            VysorWinFullInstaller(Constants.vysorFile222v);
                        break;
                    case 1:
                        if (DialogResult.OK == messaged(MainStringsRes.Win217VysorQ, "Vysor Pro patcher", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                            VysorWinPatcher(Constants.vysorFile229v);
                        break;
                    case 2:
                        if (DialogResult.OK == messaged(MainStringsRes.WinOtherVysorQ, "Vysor patcher", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                            VysorWinOtherInstaller();
                        break;
                }
            else if (InvolkerRadio(_form1.radioChrome))
                if (DialogResult.OK == messaged(MainStringsRes.ChromeVysorInstaller, MainStringsRes.ChromPatcher, MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                    VysorChromeInitializator();
            ProgressBarInvoker(100);

        }
        public void CheckBoxInvoker(Control checkbox, bool status)
        {
            checkbox.Invoke(new Action(() => {
                var obj1 = (CheckBox)checkbox;
                obj1.Checked = status;}));
        }
        public void CheckBoxChecker(int id, bool State)
        {
            List<CheckBox> checkBoxes = new List<CheckBox> { _form1.checkboxClose, _form1.checkboxOldversion, _form1.checkboxInstalled, _form1.checkboxCrack, _form1.FirewallcheckBox };
            checkBoxes[id].Invoke(new Action(() => checkBoxes[id].Checked = State));
            ProgressBarInvoker(20 * (id + 1));
        }
        public void VysorChromeInitializator()
        {
            ProcessStopper("chrome");
            ProcessStopper("vysor"); CheckBoxChecker(0, true);
            if (FileJSPatcher(Constants.chromeVsrUglify, 1))
            {
                CheckBoxChecker(3, true);
                if (DialogResult.Yes == messaged(MainStringsRes.ChromeVysorInstalled, MainStringsRes.Success, MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    Process.Start(Constants.chromeDefaultLinq, Constants.chromeStartVysorParams);
            }
        }
        public void VysorWinOtherInstaller()
        {
            string selectedFile = OpenFileSelector(Constants.uglifyFilter, Constants.dirVysorRoam);
            if (selectedFile != null && selectedFile.EndsWith(Constants.uglifyName))
            {
                Thread.Sleep(500);
                VysorWinPatcher(selectedFile);
            }
            else messaged(MainStringsRes.YouneedUglify, MainStringsRes.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void VysorRemover()
        {
            if (DialogResult.OK == messaged(MainStringsRes.VysorRemove, "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                ProcessStopper("Vysor");
                ProcessStopper("adb"); CheckBoxChecker(0, true);
                Thread.Sleep(500);
                DeleterVysor(); CheckBoxChecker(1, true);
                ProgressBarInvoker(100);
                messaged(MainStringsRes.VysorRemoveSuc, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void VysorWinPatcher(string uglifyPath)
        {
            ProcessStopper("Vysor");
            ProcessStopper("adb"); CheckBoxChecker(0, true);
            if (FileJSPatcher(uglifyPath,  0))
            {
                CheckBoxChecker(3, true);
                if (_form1.firewallToggle.Checked == true)
                {
                    FireWaller fw = new FireWaller();
                    fw.firewalldown();
                    CheckBoxChecker(4, true);
                }
                if (DialogResult.OK == messaged(MainStringsRes.WinVysorComplete, MainStringsRes.Success, MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                          VysorExeExecutor(false, Constants.dirVysor + "Vysor.exe");
            }
        }
        public void VysorWinFullInstaller(string ugliPath)
        {
            if (File.Exists(Constants.fileExeInstaller))
            {
                ProcessStopper("Vysor");
                ProcessStopper("adb"); CheckBoxChecker(0, true);
                Thread.Sleep(500);
                if (DeleterVysor())
                {
                    CheckBoxChecker(1, true);
                    if (VysorExeExecutor(true, Constants.fileExeInstaller))
                    {   
                        CheckBoxChecker(2, true);
                        VysorWinPatcher(ugliPath);  
                    }
                }
            }
            else _form1.PackageDownloader();
        }
        public void ProcessStopper(string procName)
        {
            string statusName = Process.GetProcessesByName(procName).Any() ? "Yes" : "No";
            if (statusName == "Yes")
            {
                var proc = Process.GetProcessesByName(procName);
                foreach (var pc in proc)
                    pc.Kill();
                return;
            }
        }
        public bool DeleterVysor()
        {
            var localDirVysor = new DirectoryInfo(Constants.dirVysor);
            var roamDirVysor = new DirectoryInfo(Constants.dirVysorRoam);
            List<DirectoryInfo> dirs = new List<DirectoryInfo> { localDirVysor, roamDirVysor };
            try
            {
                foreach (var dir in dirs)
                {
                    if (dir.Exists)
                    {
                        foreach (var file in dir.GetFiles())
                            file.Delete();
                        foreach (var diir in dir.GetDirectories())
                            diir.Delete(true);
                        dir.Delete();
                    }
                }
                return true;
            }

            catch (Exception ex)
            {
                messaged(ex.Message, "Error. Please, try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool VysorExeExecutor(bool stopOrNot, string fileEXE)
        {
            //
            if (File.Exists(fileEXE))
            {
                try
                {
                    Process.Start(fileEXE);
                }
                catch (Exception ex)
                {
                    messaged(ex.Message + "\nPlease redownload Vysor package file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (stopOrNot)         
                    while (true)
                    {
                        
                        string statusVysor = Process.GetProcessesByName("Vysor").Any() ? "Yes" : "No";
                        if (statusVysor != "Yes")
                        {
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            
                            Thread.Sleep(2000);
                            ProcessStopper("Vysor");
                            Thread.Sleep(2000);
                            return true;
                        }
                    }
            }
           // progressBar.Invoke(new Action(() => { progressBar.ProgressBarStyle = ProgressBarStyle.Continuous; }));
            return false;
        }
        public string OpenFileSelector(string filter, string dir)
        {
            DirectoryInfo ds = new DirectoryInfo(dir);
            OpenFileDialog oFD1 = new OpenFileDialog();
            if (ds.Exists) oFD1.InitialDirectory = dir;
            else oFD1.InitialDirectory = Constants.defaultPath;
            oFD1.Filter = filter;
            if (oFD1.ShowDialog() != DialogResult.Cancel)
                return oFD1.FileName;
            return null;
        }
        private string FindTheWayChrome()
        {
            foreach (DirectoryInfo dir in new DirectoryInfo(Constants.chromeVysorDir).GetDirectories())
            {
                string dirFile = dir.FullName + @"\" + Constants.uglifyName;
                if (File.Exists(dirFile)) return dirFile;
            }
            return null;
        }
        public string FindTheWay()
        {
            List<DirectoryInfo[]> directoryInfos = new List<DirectoryInfo[]> { };
            if (Directory.Exists(Constants.vysorDirRoam)) directoryInfos.Add(new DirectoryInfo(Constants.vysorDirRoam).GetDirectories());
            if (Directory.Exists(Constants.dirVysor)) directoryInfos.Add(new DirectoryInfo(Constants.dirVysor).GetDirectories());
            //var dirInfoLocal = new DirectoryInfo(Constants.dirVysor).GetDirectories();
            foreach (DirectoryInfo[] dirs in directoryInfos)
                foreach (DirectoryInfo dir in dirs)
                {
                    string currentDir = File.Exists(dir.FullName + @"\" + Constants.uglifyName) ? dir.FullName + @"\" + Constants.uglifyName : dir.FullName + Constants.vLocalAdditionUgli;
                    if (File.Exists(currentDir) && DialogResult.Yes == messaged("Is the path to the folder with Vysor correct?\n" + dir.FullName, 
                        "Other Vysor version founded", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        return currentDir;
                }
            if (DialogResult.Yes == messaged("'Uglify.js' not selected. Select file manualy?" + "\nSelect file in another folder?",
                           "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                string drF = OpenFileSelector(Constants.uglifyFilter, Constants.chromeVysorDir);
                if (drF != null) return drF;
            }
            return null;
        }
        private bool FilePatcher(string FilePath)
        {
            string allLines = File.ReadAllText(FilePath);
            if (allLines.Contains(Constants.PathFind[0]))
            {
                allLines = allLines.Replace(Constants.PathFind[0], Constants.PathReplace[0]).Replace(Constants.PathFind[1], Constants.PathReplace[1]);
                File.Delete(FilePath);
                File.WriteAllText(FilePath, allLines);
                return true;
            }
            messaged("An error occurred. File don't needed to be patched or file not founded!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        public bool FileJSPatcher(string FilePath, int switcher)
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    if(FilePatcher(FilePath))
                    return true;
                }
                else if (switcher == 0)
                {
                    string FindPath = FindTheWay();
                    if (FindPath != null)
                    {
                       if( FilePatcher(FindPath))
                        return true;
                    }
                }
                else
                {
                    string driL = FindTheWayChrome();
                    if (driL != null)
                    {
                        if(FilePatcher(driL))
                        return true;
                    }
                }
                return false;
            }
            catch (IOException ex)
            {
                messaged(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        public static string SizeSuffix(Int64 value)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }
            int i = 0;
            decimal dValue = (decimal)value;
            while (Math.Round(dValue / 1024) >= 1)
            {
                dValue /= 1024;
                i++;
            }
            return string.Format("{0:n1} {1}", dValue, Constants.SizeSuffixes[i]);
        }
        public void ChromeVysorStarter()
        {
            var process = new Process();
            process.StartInfo.Arguments = Constants.chromeStartVysorParams;
            if (File.Exists(Constants.chromeDefaultLinq))
                process.StartInfo.FileName = Constants.chromeDefaultLinq;
            else
                process.StartInfo.FileName = OpenFileSelector(Constants.chromeDirFilter, Constants.chromeInitialDir);
            process.Start();
        }
    }

}

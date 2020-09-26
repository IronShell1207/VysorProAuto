using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VysorProAuto
{
    public class Constants
    {
        public static readonly string dirVysor =         Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Vysor\";
        public static readonly string dirVysorRoam =     Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Vysor\";
        public static readonly string defaultPath =      Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        public static readonly string chromeVysorDir =   Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Google\Chrome\User Data\Default\Extensions\gidgenkbbabolejbgbpnhbimgjbffefm\";
        public static readonly string vLocalAdditionUgli =           @"\resources\app\unpacked-crx\uglify.js";
        public static readonly string vysorDirRoam  = dirVysorRoam + @"crx\gidgenkbbabolejbgbpnhbimgjbffefm\";
        public static readonly string vysorFile217v = vysorDirRoam + @"app-2.1.7.crx-unpacked\uglify.js";
        public static readonly string vysorFile225v = vysorDirRoam + @"app-2.2.5.crx-unpacked\uglify.js";
        public static readonly string vysorFile226v = vysorDirRoam + @"app-2.2.6.crx-unpacked\uglify.js";
        public static readonly string vysorFile229v = vysorDirRoam + @"app-2.2.9.crx-unpacked\uglify.js";
        public static readonly string vysorFile222v = dirVysor +     @"app-2.2.2\resources\app\unpacked-crx\uglify.js";
        public static readonly string vysorFile212v = dirVysor +     @"app-2.1.2\resources\app\unpacked-crx\uglify.js";
        public static readonly string chromeDefaultLinq =            @"C:\Program Files (x86)\Google\Chrome\Application\chrome_proxy.exe";
        public static readonly string chromeInitialDir =             @"C:\Program Files (x86)\Google\Chrome\Application";
        public static readonly string uglifyName =                   "uglify.js";
        public static readonly string uglifyFilter =                 "uglify.js(*.js)|*.js";
        public static readonly string fileExeInstaller =             "Vysor-222inst.exe";
        public static readonly string chromeDirFilter =              "chrome_proxy.exe(*.exe)|*.exe";
        public static readonly string chromeVsrUglify = chromeVysorDir + @"2.1.7_1\uglify.js";
        public static readonly string chromeStartVysorParams =       "--profile-directory=Default --app-id=gidgenkbbabolejbgbpnhbimgjbffefm";
        public static readonly string[] PathFind =          new string[] { "Googl=p,g=!1,b=!1,k=", "var t=!1;return e.subscriptions" };
        public static readonly string[] PathReplace =       new string[] { "Googl=p,g=!0,b=!0,k=", "var t=!0;return e.subscriptions" };

        public static readonly string vysorPackageLinq  = link + @"/Files/Vysor-222inst.exe";
        public static readonly string wifiADBHelperLinq = link + "/wifi-adb-helper/";
        public static readonly string vysorServerDownload = link + @"/Files/EasyVysorPro.zip";
        public static readonly string updaterexelink = link + @"/Files/updater.exe";
        public static readonly string[] SizeSuffixes =      { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        public static string link { get => LinkGenerator(); }

        public static string LinkGenerator()
        {
            string linkmaincheck = @"https://fordroid.3dn.ru/pictures/domaincheck.txt";
            string finaldomain = @"";
            string filename = "linkdomain.txt";
            // Объект запроса
            HttpWebRequest rew = (HttpWebRequest)WebRequest.Create(linkmaincheck);
            // Отправить запрос и получить ответ
            HttpWebResponse resp = (HttpWebResponse)rew.GetResponse();
            // Получить поток
            Stream str = resp.GetResponseStream();
            // Выводим в TextBox
            int ch;
            for (int i = 1; ; i++)
            {
                ch = str.ReadByte();
                if (ch == -1) break;
                finaldomain += (char)ch;
            }
            // Закрыть поток
            str.Close();
            return finaldomain;
        }
    }
}

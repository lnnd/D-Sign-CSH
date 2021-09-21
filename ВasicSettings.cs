using EUSignCP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D_Sign
{
    class ВasicSettings
    {
        private static string mainFolderPath;
        private static string dllFolderPath;
        private static string certFolderPath;
       
        public static void checkMainFolder(string mainFolder)
        {
            DirectoryInfo directoryInfo;
            string path = mainFolder;
            if (!path.EndsWith("\\"))
                path = path + "\\";

            // Основная папка
            string pathMain = path;
            directoryInfo = new DirectoryInfo(pathMain);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            // lib
            string pathLib = path + "lib\\";
            directoryInfo = new DirectoryInfo(pathLib);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            // lib
            string pathCert = path + "cert\\";
            directoryInfo = new DirectoryInfo(pathCert);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            mainFolderPath = pathMain;
            dllFolderPath = pathLib;
            certFolderPath = pathCert;

        }

        public static int SetSetting(bool offlineMode)
        {
            int err = 0;

            IEUSignCP.Initialize();
            
            IEUSignCP.SetUIMode(false);

            err = IEUSignCP.SetModeSettings(offlineMode);








            return err;

        }
    }
}

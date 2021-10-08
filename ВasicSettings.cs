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

        public static string SetSetting(bool offlineMode)
        {            
            string description = default;

            IEUSignCP.SetUIMode(true);

            int err = IEUSignCP.Initialize();
            description = IEUSignCP.GetErrorDesc(err);
            if (err != 0)
                return description;

            IEUSignCP.SetModeSettings(offlineMode);

            // Proxy
            bool    useProxy        = false;
            bool    anonymous       = false;
            string  address         = "";
            string  port            = "";
            string  user            = "";
            string  password        = "";
            bool    savePassword   = false;
            IEUSignCP.SetProxySettings(useProxy, anonymous, address, port, user, password, savePassword);

            // File store
            bool checkCRLs = true;          // Признак необхідності використання СВС при визначенні статусу сертифіката
            bool autoRefresh = true;        // Признак необхідності автоматичного виявлення змін у файловому сховищі при записі, модифікації чи видаленні сертифікатів та 
            bool ownCRLsOnly = false;       // Признак необхідності використання СВС тільки власного ЦСК користувача
            bool fullAndDeltaCRLs = false;  // Признак необхідності перевірки наявності двох діючих СВС – повного та часткового
            bool autoDownloadCRLs = true;   // Признак необхідності автоматичного завантаження СВС
            bool saveLoadedCerts = true;    // Признак необхідності автоматичного збереження сертифікатів отриманих з LDAP-сервера чи за протоколом OCSP у файлове сховище
            int expireTime = 0;             // Час зберігання стану перевіреного сертифіката
            IEUSignCP.SetFileStoreSettings(certFolderPath, checkCRLs, autoRefresh, ownCRLsOnly, fullAndDeltaCRLs, autoDownloadCRLs, saveLoadedCerts, expireTime);

            // CMP
            bool useCMP = true;
            string addressCMP = "http://acsk.privatbank.ua/services/cmp/";
            string portCMP = "80";
            string commonName = "";
            IEUSignCP.SetCMPSettings(useCMP, addressCMP, portCMP, commonName);

            // TCP
            bool getStamps = true;
            string addressTCP = "http://acsk.privatbank.ua/services/tsp/";
            string portTCP = "80";
            IEUSignCP.SetTSPSettings(getStamps, addressTCP, portTCP);

            // OCSP
            bool useOCSP = true;
            bool beforeStore = false; // Признак черговості перевірки статусу 
            string addressOCSP = "http://acsk.privatbank.ua/services/ocsp/";
            string portOCSP = "80";
            IEUSignCP.SetOCSPSettings(useOCSP, beforeStore, addressOCSP, portOCSP);

            // LDAP
            bool useLDAP = false;
            string addressLDAP = "";
            string portLDAP = "";
            bool anonymousLDAP = true;
            string userLDAP = "";
            string passwordLDAP = "";
            IEUSignCP.SetLDAPSettings(useLDAP, addressLDAP, portLDAP, anonymousLDAP, userLDAP, passwordLDAP);

            IEUSignCP.SetSettings();

            


            

            return description;

        }
    }
}

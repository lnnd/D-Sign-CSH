using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EUSignCP;

namespace D_Sign
{
    public class InitClass
    {

        //public static void Main(string[] args)
        //{

        //}

        public string Init(String mainFolderPath, bool offline)
        {
            string desc = default;

            ВasicSettings.checkMainFolder(mainFolderPath);
            desc = ВasicSettings.SetSetting(offline);

            
             

            return desc;
        }

        

    }
}

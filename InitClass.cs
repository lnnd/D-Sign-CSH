using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EUSignCP;

namespace D_Sign
{
    public class InitClass
    {
        public int Init(String mainFolderPath, bool offline)
        {

            ВasicSettings.checkMainFolder(mainFolderPath);
            ВasicSettings.SetSetting(offline);

            
             

            return 0;
        }

        

    }
}

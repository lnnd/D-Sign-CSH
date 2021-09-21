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
            int error = ВasicSettings.SetSetting(offline);

            
             

            return error;
        }

        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPC_ProjetX_Launcher.BPC.Arma3Mods.tool
{
    public class File
    {
        Manifest mani;
        String path;
        public File(Manifest mani, String path)
        {
            this.mani = mani;
            this.path = path;
        }

        public String getPath()
        {
            return this.path;
        }

        public String CRC()
        {
            return "";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPC_ProjetX_Launcher.BPC.Arma3Mods.tool
{
    public class Dir
    {
        string path;
        List<Dir> Dirs;
        List<File> Files;
        Manifest mani;

        public Dir(Manifest mani, String path)
        {
            this.mani = mani;
            this.path = path;
        }

        public String getPath()
        {
            return this.path;
        }

        public void parse()
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(this.path);
            foreach (System.IO.FileInfo f in dir.GetFiles("*.*"))
            {
                Console.WriteLine(f.FullName);
            }

            foreach (var item in this.Dirs)
            {
                item.parse();
            }
        }
    }
}

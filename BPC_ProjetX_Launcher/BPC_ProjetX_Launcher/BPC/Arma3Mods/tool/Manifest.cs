using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPC_ProjetX_Launcher.BPC.Arma3Mods.tool
{
    public class JsonManifest
    {
        List<String> Dirs { get; set; }
        List<String> Files { get; set; }
        List<String> FilesCRC { get; set; }
    }

    public class Manifest
    {
        Dir localDir;
        Dictionary<String,Dir> Dirs;
        Dictionary<String, File> Files;

        public Manifest(string repoDir)
        {
            this.localDir = new Dir(this, repoDir+"/mods/");
            this.parse();
        }

        public void addDir(Dir dir)
        {
            this.Dirs.Add(dir.getPath(), dir);
        }

        public void addFile(File file)
        {
            this.Files.Add(file.getPath(), file);
        }

        public void parse()
        {
            this.localDir.parse();
        }

    }
}

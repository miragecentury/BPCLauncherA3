using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DamienG.Security.Cryptography;
using System.IO;
using System.Net;

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

        string repoDir;
        string repoModsDir;
        string[] files;
        string[] dirs;
        List<string> lfiles;
        List<string> ldirs;
        List<string> lserverdirs;
        List<string> lserverfiles;
        List<string> lserverfilesCrc;
        String ftpUrl = "ftp://ip.nordri.fr";
        String basedir = "/ftp/mods/projetxrepo/";
        String ftpUser = "projetxmods";
        String ftpPassword = "degrasse03";
        List<string> dirssimilar = new List<string>();
        List<string> dirscreate = new List<string>();
        List<string> dirsdelete = new List<string>();
        List<string> filesdelete = new List<string>();
        List<string> filescreate = new List<string>();
        List<string> filessimilar = new List<string>();
        List<string> filesmodify = new List<string>();

        public Manifest(string repoDir,string ftpUrl, string basedir, string ftpUser, string ftpPassword)
        {
            this.ftpUrl = ftpUrl;
            this.basedir = basedir;
            this.ftpUser = ftpUser;
            this.ftpPassword = ftpPassword;
            if (!Directory.Exists(repoDir))
            {
                Directory.CreateDirectory(repoDir);
            }
            if (!Directory.Exists(repoDir+"\\mods\\"))
            {
                Directory.CreateDirectory(repoDir + "\\mods\\");
            }
            this.repoDir = repoDir;
            this.repoModsDir = repoDir + "\\mods\\";
            this.lfiles = new List<string>();
            this.ldirs = new List<string>();
            this.lserverdirs = new List<string>();
            this.lserverfiles = new List<string>();
            this.lserverfilesCrc = new List<string>();
        }

        public List<string> getDirsToCreate()
        {
            return this.dirscreate;
        }

        public List<string> getDirsToDelete()
        {
            return this.dirsdelete;
        }

        public List<string> getFilesToDownload()
        {
            return this.filescreate;
        }

        public List<string> getFilesToUpdate()
        {
            return this.filesmodify;
        }

        public List<string> getFilesToDelete()
        {
            return this.filesdelete;
        }

        public void parse()
        {
            string[] files = Directory.GetFiles(this.repoModsDir, "*.*", SearchOption.AllDirectories);
            string[] dirs = Directory.GetDirectories(this.repoModsDir, "*.*", SearchOption.AllDirectories);

            foreach (var item in dirs)
            {
                string path = (string)item;
                path = path.Replace(this.repoModsDir, "");
                this.ldirs.Add(path);
            }
            foreach (var item in files)
            {
                string path = (string)item;
                path = path.Replace(this.repoModsDir, "");
                this.lfiles.Add(path);
            }

            this.files = files;
            this.dirs = dirs;
        }

        public void setManifestServer(dynamic manifestserver)
        {
            foreach (var item in manifestserver["Dirs"])
            {
                this.lserverdirs.Add(item);
            }

            foreach (var item in manifestserver["Files"])
            {
                this.lserverfiles.Add(item);
            }

            foreach (var item in manifestserver["FilesCRC"])
            {
                this.lserverfilesCrc.Add(item);
            }
        }

        public Boolean check(Boolean action)
        {

            List<string> filessimilartemp = new List<string>();

            Console.WriteLine("#################### CHECK DIR SIMILAR ###########################");
            foreach(var item in  this.ldirs.Intersect((IEnumerable<string>)this.lserverdirs))
            {
                this.dirssimilar.Add(item);
            }
            Console.WriteLine("#################### CHECK DIR TO CREATE ###########################");
            foreach (var item in this.lserverdirs.Except(this.dirssimilar))
            {
                this.dirscreate.Add(item);
            }
            Console.WriteLine("#################### CHECK DIR TO REMOVE ###########################");
            foreach (var item in this.ldirs.Except(this.dirssimilar))
            {
                this.dirsdelete.Add(item);
            }
            Console.WriteLine("#################### CHECK File SIMILAR ###########################");
            foreach (var item in this.lfiles.Intersect((IEnumerable<string>)this.lserverfiles))
            {
                this.filessimilar.Add(item);
            }
            Console.WriteLine("#################### CHECK DIR TO CREATE ###########################");
            foreach (var item in this.lserverfiles.Except(this.filessimilar))
            {
                this.filescreate.Add(item);
            }
            Console.WriteLine("#################### CHECK DIR TO REMOVE ###########################");
            foreach (var item in this.lfiles.Except(this.filessimilar))
            {
                this.filesdelete.Add(item);
            }
            Console.WriteLine("#################### CHECK Files TO Modify ###########################");
            foreach (var item in filessimilar)
            {
                int index = this.lserverfiles.IndexOf(item);
                string CRC = this.lserverfilesCrc.ElementAt(index);

                Crc32 crc32 = new Crc32();
                String hash = String.Empty;

                using (FileStream fs = File.Open(this.repoModsDir+item, FileMode.Open))
                {
                    foreach (byte b in crc32.ComputeHash(fs)) hash += b.ToString("x2").ToLower();
                }
                hash = hash.ToUpper();
                //Console.WriteLine("CRC-32 is {0}", hash);
                if (hash == CRC)
                {
                    //Ok
                }
                else
                {
                    this.filesmodify.Add(item);
                    filessimilartemp.Add(item);
                }
            }

            foreach (var item in filessimilartemp)
            {
                this.filessimilar.Remove(item);
            }

            if (action)
            {
                Console.WriteLine("#################### Action #######################################");
                foreach (var item in this.dirscreate)
                {
                    Directory.CreateDirectory(this.repoModsDir + item);
                }
                foreach (var item in this.filesdelete)
                {
                    Console.WriteLine("# FILE : DELETE : " + item);
                    File.Delete(this.repoModsDir + item);
                }
                this.dirsdelete.Sort();
                this.dirsdelete.Reverse();
                foreach (var item in dirsdelete)
                {
                    Console.WriteLine("# DIR : DELETE : " + item);
                    Directory.Delete(this.repoModsDir + item);
                }

                foreach (var item in this.filescreate)
                {
                    // Get the object used to communicate with the server.
                    WebClient request = new WebClient();
                    // This example assumes the FTP site uses anonymous logon.
                    request.Credentials = new NetworkCredential(this.ftpUser, this.ftpPassword);
                    byte[] newFileData = request.DownloadData(this.ftpUrl + this.basedir + "mods/"+item);
                    FileStream newfile = new FileStream(this.repoModsDir+item, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                    newfile.Write(newFileData, 0, newFileData.Length);
                    newfile.Close();
                }

                foreach (var item in this.filesmodify)
                {
                    File.Delete(this.repoModsDir + item);
                    //Download
                    // Get the object used to communicate with the server.
                    using(WebClient request = new WebClient()){
                        // This example assumes the FTP site uses anonymous logon.
                        request.Credentials = new NetworkCredential(this.ftpUser, this.ftpPassword);
                        byte[] newFileData = request.DownloadData(this.ftpUrl + this.basedir + "mods/" + item);
                        FileStream newfile = new FileStream(this.repoModsDir + item, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                        newfile.Write(newFileData, 0, newFileData.Length);
                        newfile.Close();
                    }
                }
                
            }

            if ((dirsdelete.Count + dirscreate.Count + filescreate.Count + filesdelete.Count + filesmodify.Count) > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}

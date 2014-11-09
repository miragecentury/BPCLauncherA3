using BPC.Common;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using BPC_ProjetX_Launcher.BPC.Arma3Mods.tool;
using Microsoft.Win32;

namespace BPC_ProjetX_Launcher.BPC.Arma3Mods
{
    public class Manager
    {

        String  ftpUrl = "ftp://ip.nordri.fr";
        String basedir = "/ftp/mods/projetxrepo/";
        String  ftpUser = "projetxmods";
        String  ftpPassword = "degrasse03";

        String relativePathRepo = "@ProjetX_Mods";

        Manifest mani;

        DateTime lastCheck;
        DateTime lastUpdate;

        const String metaDataUrl = "http://projetx.nordri.fr/api/v1/launcher/getStatus";
        const String metaDataPass = "";

        dynamic dataInfosServeur;

        dynamic manifestServer;

        public Manager()
        {
            this.GetInfoAtServeur();
        }

        private void GetInfoAtServeur()
        {
            using (WebClient client = new WebClient())
            {

                //byte[] response =
                //client.UploadValues(Manager.metaDataUrl, new NameValueCollection()
                //{
                //    { "tokenAuth", "" },
                //    { "pass", Manager.metaDataPass }
                //});

                //string result = System.Text.Encoding.UTF8.GetString(response);
                //var serializer = new JavaScriptSerializer();
                //serializer.RegisterConverters(new[] { new DynamicJsonConverter() });
                //this.dataInfosServeur = serializer.Deserialize(result, typeof(object));
            }
        }



        public void getManifestServer()
        {
            // Get the object used to communicate with the server.
            WebClient request = new WebClient();

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(this.ftpUser, this.ftpPassword);
            try
            {
                byte[] newFileData = request.DownloadData(this.ftpUrl+this.basedir + "manifest.json");
                string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
                var serializer = new JavaScriptSerializer();
                serializer.RegisterConverters(new[] { new DynamicJsonConverter() });
                this.manifestServer = serializer.Deserialize(fileString, typeof(object));
            }
            catch (WebException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Check()
        {
            RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\bohemia interactive\arma 3");
            String test = (String)rk.GetValue("main");

            this.mani = new Manifest(test + "\\"+this.relativePathRepo, this.ftpUrl, this.basedir, this.ftpUser, this.ftpPassword);
            this.mani.parse();
            this.mani.setManifestServer(manifestServer);
            this.mani.check(true);

        }
    }
}

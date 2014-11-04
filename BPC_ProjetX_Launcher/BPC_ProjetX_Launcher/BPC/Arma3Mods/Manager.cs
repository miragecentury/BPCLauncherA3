using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BPC_ProjetX_Launcher.BPC.Arma3Mods
{
    class Manager
    {

        String  ftpUrl = "ftp.nordri.fr";
        String  ftpUser = "launcher";
        String  ftpPassword = "degrasse";

        DateTime lastCheck;
        DateTime lastUpdate;

        const String metaDataUrl = "http://projetx.nordri.fr/api/v1/launcher/getStatus";
        const String metaDataPass = "";

        public Manager()
        {

        }

        private void GetInfoAtServeur()
        {
            using (WebClient client = new WebClient())
            {

                byte[] response =
                client.UploadValues(Manager.metaDataUrl, new NameValueCollection()
                {
                    { "tokenAuth", "" },
                    { "pass", Manager.metaDataPass }
                });

                string result = System.Text.Encoding.UTF8.GetString(response);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BPC_ProjetX_Launcher.BPC.Common
{
    class Manager
    {
        bool serverStatus = false;
        BPC.Wamp.Manager wampManager = null;
        BPC.Arma3Configs.Manager configManager = null;
        BPC.Arma3.Manager arma3Manager = null;
        MainWindow mainWindow = null;
        static Manager singleton = null;

        const String urlToCheckStatus = "http://projetx.nordri.fr/api/v1/launcher/getStatus";

        static public Manager getInstance()
        {
            return Manager.singleton;
        }

        public Manager()
        {
            Manager.singleton = this;
            String errorMessage = "";
            errorMessage = this.CheckServerStatut();
            this.configManager = new Arma3Configs.Manager();
            this.arma3Manager = new BPC.Arma3.Manager(this.configManager);
            if (this.serverStatus == true)
            {
                this.wampManager = new BPC.Wamp.Manager();
            }
            else
            {
                //Error Message : Récupération du message d'erreur

            }
           
        }

        public void setMainWindow(MainWindow mw)
        {
            this.mainWindow = mw;
        }

        public MainWindow getMainWindow()
        {
            return this.mainWindow;
        }

        public BPC.Arma3Configs.Manager getConfigManager()
        {
            return this.configManager;
        }

        private String CheckServerStatut(){
            this.serverStatus = false;
            try
            {
                using (WebClient client = new WebClient())
                {

                    byte[] response =
                    client.UploadValues("http://projetx.nordri.fr/api/v1/updater/getinfos", new NameValueCollection()
                {
                    { "pass", "" }
                });

                    string result = System.Text.Encoding.UTF8.GetString(response);
                }
            }
            catch (Exception e)
            {
                this.serverStatus = false;
                return "Impossible de Vérifier l'état du Serveur. Veuillez nous excuser du désagremment.";
            }
            return "";
        }

        public void StartArma3Vanilla()
        {
            this.arma3Manager.startArma3Vanilla();
        }

    }
}

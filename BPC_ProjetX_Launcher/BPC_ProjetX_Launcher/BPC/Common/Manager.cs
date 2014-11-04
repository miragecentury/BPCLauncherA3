using System;
using System.Collections.Generic;
using System.Linq;
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
            return "Impossible de Vérifier l'état du Serveur. Veuillez nous excuser du désagremment.";
        }

        public void StartArma3Vanilla()
        {
            this.arma3Manager.startArma3Vanilla();
        }

    }
}

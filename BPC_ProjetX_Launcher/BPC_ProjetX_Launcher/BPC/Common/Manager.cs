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
        MainWindow mainWindow = null;


        public Manager(MainWindow mainWindow)
        {
            String errorMessage = "";
            this.mainWindow = mainWindow;
            errorMessage = this.CheckServerStatut();
            this.configManager = new Arma3Configs.Manager();
            if (this.serverStatus == true)
            {
                this.wampManager = new BPC.Wamp.Manager();
            }
            else
            {
                //Error Message : Récupération du message d'erreur

            }
           
        }

        private String CheckServerStatut(){
            this.serverStatus = false;
            return "Impossible de Vérifier l'état du Serveur. Veuillez nous excuser du désagremment.";
        }

    }
}

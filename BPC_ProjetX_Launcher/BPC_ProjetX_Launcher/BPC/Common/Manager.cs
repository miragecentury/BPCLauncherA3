using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Dynamic;
using System.Web.Script.Serialization;
using BPC.Common;

namespace BPC_ProjetX_Launcher.BPC.Common
{
    public class Manager
    {
        bool serverStatus = false;
        BPC.Wamp.Manager wampManager = null;
        BPC.Arma3Configs.Manager configManager = null;
        BPC.Arma3.Manager arma3Manager = null;
        MainWindow mainWindow = null;
        static Manager singleton = null;

        const String urlToCheckStatus = "http://projetx.nordri.fr/api/launcher/statut";

        static public Manager getInstance()
        {
            return Manager.singleton;
        }

        public Manager()
        {
            Manager.singleton = this;
            this.CheckServerStatut();
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
            if (this.serverStatus)
            {
                this.mainWindow.setStatusServerStatus(true);
                this.wampManager.Connect();
                if (this.wampManager.IsConnected())
                {
                    this.mainWindow.setStatusServerConnectionStatus(true);
                    this.StartLogin();
                }
            }
        }

        public void StartLogin()
        {
            Login lgWindow = new Login(this);
            lgWindow.Show();
            this.mainWindow.Hide();
        }

        public MainWindow getMainWindow()
        {
            return this.mainWindow;
        }

        public BPC.Arma3Configs.Manager getConfigManager()
        {
            return this.configManager;
        }

        private void CheckServerStatut(){
            this.serverStatus = false;
            try
            {
                using (WebClient client = new WebClient())
                {

                    byte[] response =
                    client.UploadValues(Manager.urlToCheckStatus, new NameValueCollection()
                {
                    { "pass", "" }
                });

                    string result = System.Text.Encoding.UTF8.GetString(response);
                    var serializer = new JavaScriptSerializer();
                    serializer.RegisterConverters(new[] { new DynamicJsonConverter() });

                    dynamic obj = serializer.Deserialize(result, typeof(object));
                    Console.WriteLine(obj);
                    Console.WriteLine(obj.ok);
                    if (obj.ok == true)
                    {
                        this.serverStatus = true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.serverStatus = false;
                //return "Impossible de Vérifier l'état du Serveur. Veuillez nous excuser du désagremment.";
            }
           
        }

        public void StartArma3Vanilla()
        {
            this.arma3Manager.startArma3Vanilla();
        }

        public Boolean Authenticate(String email, String password)
        {
            if (this.wampManager.Authenticate(email, password))
            {
                //OK
                this.mainWindow.setStatusServeurAuthentification(true);
                return true;
            }
            else
            {
                //PAS OK
                return false;
            }
        }
    }
}

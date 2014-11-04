using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPC_ProjetX_Launcher.BPC.Arma3
{
    class Manager
    {

        String pathToExeArma3 = "";
        Instance arma3Instance = null;
        Arma3Configs.Manager configManager = null;

        public Manager(Arma3Configs.Manager manager)
        {
            this.configManager = manager;
            this.getAutoPathToExeArma3();
        }

        public void getAutoPathToExeArma3()
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\bohemia interactive\arma 3");
                String test = (String)rk.GetValue("main");
                this.pathToExeArma3 = test + @"/arma3.exe";
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
        }

        public Boolean startArma3Vanilla()
        {
            if(this.arma3Instance == null){
                this.arma3Instance = new Instance(this);
                this.arma3Instance.Launch();
                return true;
            }else{
                return false;
            }
        }

        public Boolean startArma3ProjetX()
        {
            return false;
        }

        public String getPathToExeArma3()
        {
            return this.pathToExeArma3;
        }
    }
}

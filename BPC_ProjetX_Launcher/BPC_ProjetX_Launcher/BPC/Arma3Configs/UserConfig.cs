using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Westwind.Utilities.Configuration;

namespace BPC_ProjetX_Launcher.BPC.Arma3Configs
{
    class Userconfig : AppConfiguration
    {
        public Boolean arma3Config_noStartScreen { get; set; }
        public Boolean arma3Config_noPause { get; set; }
        public Boolean arma3Config_emptyStartWorld { get; set; }
        public Boolean arma3Config_showScriptError { get; set; }
        public Boolean arma3Config_stopMultiCore { get; set; }
        public Boolean arma3Config_onlyPbo { get; set; }
        public Boolean arma3Config_noLog { get; set; }
        public Int32 arma3Config_extraThread { get; set; }
        public Int32 arma3Config_extraThread_index { get; set; }
        public Boolean arma3Config_hyperThreading { get; set; }
        public Int32 arma3Config_maxmem { get; set; }
        public Int32 arma3Config_maxvideomam { get; set; }
        public Int32 arma3Config_nbproc { get; set; }
        //
        public DateTime updater_lastCheck { get; set; }

        public Userconfig()
        {
            this.arma3Config_noStartScreen = false;
            this.arma3Config_noPause = false;
            this.arma3Config_emptyStartWorld = false;
            this.arma3Config_showScriptError = false;
            this.arma3Config_stopMultiCore = false;
            this.arma3Config_onlyPbo = false;
            this.arma3Config_noLog = false;
            this.arma3Config_extraThread = 0;
            this.arma3Config_extraThread_index = 0;
            this.arma3Config_hyperThreading = false;
            //
            this.updater_lastCheck = new DateTime();
        }

        protected override IConfigurationProvider OnCreateDefaultProvider(string sectionName, object configData)
        {
            ConfigurationFileConfigurationProvider<Userconfig> provider = new ConfigurationFileConfigurationProvider<Userconfig>()
            {
                ConfigurationFile = System.AppDomain.CurrentDomain.BaseDirectory + @"\arma3.config",
                ConfigurationSection = sectionName,
            };

            return provider;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Westwind.Utilities.Configuration;

namespace BPCLauncherA3.Tools
{
    class Userconfigs : AppConfiguration
    {
        public Boolean noStartScreen { get; set; }
        public Boolean noPause { get; set; }
        public Boolean emptyStartWorld { get; set; }
        public Boolean showScriptError { get; set; }
        public Boolean stopMultiCore { get; set; }
        public Boolean onlyPbo{ get; set; }
        public Boolean noLog { get; set; }
        public UInt32 ExtraThread { get; set; }
        public Boolean HyperThreading { get; set; }

        public Userconfigs()
        {
            this.noStartScreen = false;
            this.noPause = false;
            this.emptyStartWorld = false;
            this.showScriptError = false;
            this.stopMultiCore = false;
            this.onlyPbo = false;
            this.noLog = false;
            this.ExtraThread = 0;
            this.HyperThreading = false;
        }

        protected override IConfigurationProvider OnCreateDefaultProvider(string sectionName, object configData)
        {
            ConfigurationFileConfigurationProvider<Userconfigs> provider = new ConfigurationFileConfigurationProvider<Userconfigs>()
            {
                ConfigurationFile = System.AppDomain.CurrentDomain.BaseDirectory + @"\arma3launch.config",
                ConfigurationSection = sectionName,
            };

            return provider;
        }   
    }
}

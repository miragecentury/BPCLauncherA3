using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Westwind.Utilities.Configuration;

namespace BPCLauncherA3.Tools
{
    class ModsList : AppConfiguration
    {
        //public ICollection<String> mods { get; set; }
        public String urlTo { get; set; }
        public String user { get; set; }
        public String password { get; set; }

        public ModsList()
        {

        }

        protected override IConfigurationProvider OnCreateDefaultProvider(string sectionName, object configData)
        {
            ConfigurationFileConfigurationProvider<Userconfigs> provider = new ConfigurationFileConfigurationProvider<Userconfigs>()
            {
                ConfigurationFile = System.AppDomain.CurrentDomain.BaseDirectory + @"\modlist.config",
                ConfigurationSection = sectionName,
                EncryptionKey = "6251a0f048e9a93e3c70eb7fd6da641d",
                PropertiesToEncrypt = "urlTo,user,password",
            };

            return provider;
        }
    }
}
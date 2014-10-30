using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPC_ProjetX_Launcher.BPC.Arma3Configs
{
    class Manager
    {

        Userconfig userConfig = null;

        public Manager()
        {
            this.userConfig = new Userconfig();
            this.userConfig.Initialize();
            this.userConfig.Read();
            this.userConfig.Write();
        }
    }
}

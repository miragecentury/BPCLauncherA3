using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WampSharp.V1;

namespace BPC_ProjetX_Launcher.BPC.Wamp
{
    class Manager
    {
        Boolean ServeurStatus = false;
        Boolean ServeurIsConnected = false;
        Boolean ServeurIsAuthentified = false;

        IWampChannel<JToken> serverws = null;

        const String wsUrl = "ws://projetx.nordri.fr:8080/";

        public Manager()
        {


        }

        public void Connect()
        {
            DefaultWampChannelFactory channelFactory = new DefaultWampChannelFactory();
            serverws = channelFactory.CreateChannel(Manager.wsUrl);
            try
            {
                serverws.Open();
                this.ServeurIsConnected = true;
            }
            catch (Exception e)
            {
                this.ServeurIsConnected = false;
            }
        }


    }
}

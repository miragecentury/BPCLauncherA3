using BPC.Common;
using BPC_ProjetX_Launcher.BPC.Wamp.Topic.Common.User;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using WampSharp.V1;

namespace BPC_ProjetX_Launcher.BPC.Wamp
{
    public class Manager
    {
        Boolean ServeurStatus = false;
        Boolean ServeurIsConnected = false;
        Boolean ServeurIsAuthentified = false;
        String ServeurAuthToken = "";

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
                Console.WriteLine(e.Message);
                this.ServeurIsConnected = false;
            }
        }

        public Boolean Authenticate(String email, String Password)
        {
            try
            {
                Login login = this.serverws.GetRpcProxy<Login>();
                var serializer = new JavaScriptSerializer();
                serializer.RegisterConverters(new[] { new DynamicJsonConverter() });
                dynamic json = login.Login(email, Password);
                dynamic res = serializer.Deserialize(json.ToString(), typeof(object));
                if (res.token == null)
                {
                    return false;
                }
                else
                {
                    this.ServeurAuthToken = res.token;
                    this.ServeurIsAuthentified = true;
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public Boolean IsConnected()
        {
            return this.ServeurIsConnected;
        }

        public String getToken()
        {
            return this.ServeurAuthToken;
        }

    }
}

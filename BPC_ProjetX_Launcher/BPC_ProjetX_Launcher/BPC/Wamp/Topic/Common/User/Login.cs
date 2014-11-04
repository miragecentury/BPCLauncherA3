using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WampSharp.V1.Rpc;

namespace BPC_ProjetX_Launcher.BPC.Wamp.Topic.Common.User
{
    public interface Login
    {
        [WampRpcMethod("ws.projetx.common.user.login")]
        dynamic Login(String email, String Password,int TypeLogin = 2);
    }
}

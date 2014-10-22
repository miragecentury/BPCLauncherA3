using BPCLauncherA3.Wamp.Topic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using WampSharp.V1;

namespace BPCLauncherA3.Wamp
{
    class Client
    {
        public Client()
        {
            DefaultWampChannelFactory channelFactory = new DefaultWampChannelFactory();
            IWampChannel<JToken> channel = channelFactory.CreateChannel("ws://projetx.nordri.fr:8080/");
            channel.Open();

            // PubSub subscription:
            ISubject<CommonUserLogin> subject = channel.GetSubject<CommonUserLogin>("ws.projetx.common.user.login");
            IDisposable subscription = subject.Subscribe(x => Console.WriteLine("Received " + x));

            CommonUserLogin cul = new CommonUserLogin()
                        {
                            topic="ws.projetx",
                            data = new CommonUserLoginData() {TimeStamp=0,UserEmail="victorien.vanroye",UserId=0,Username="miragecentury"},
                        };
            Console.Write(JsonConvert.SerializeObject(cul));
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPCLauncherA3.Wamp.Topic
{
    class CommonUserLoginData
    {
        [JsonProperty("TimeStamp")]
        public int TimeStamp { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("User.Id")]
        public string UserId { get; set; }

        [JsonProperty("User.Email")]
        public string UserEmail { get; set; }

        public override string ToString()
        {
            return string.Format("Username: {0}, User.Id: {1}, User.Email: {2}, TimeStamp: {3}", Username, UserId, UserEmail, TimeStamp);
        }
    }

    class CommonUserLogin
    {
        
        [JsonProperty("topic")]
        public string topic { get; set; }

        [JsonProperty("data")]
        public CommonUserLoginData data { get; set; }

        public override string ToString()
        {
            return string.Format("topic: {0}, data: {1}", topic, data.ToString());
        }
        
    }
}

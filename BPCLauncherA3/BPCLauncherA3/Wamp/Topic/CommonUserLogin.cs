using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPCLauncherA3.Wamp.Topic
{
    [JsonObject]
    class CommonUserLoginData
    {

        [JsonProperty("UserId")]
        public int UserId { get; set; }

        [JsonProperty("UserEmail")]
        public string UserEmail { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("TimeStamp")]
        public int TimeStamp { get; set; }

        [JsonProperty("TypeLogin")]
        public int TypeLogin { get; set; }

        public override string ToString()
        {
            return string.Format("Username: {0}, UserId: {1}, UserEmail: {2}, TimeStamp: {3}, TypeLogin: {4}", Username, UserId, UserEmail, TimeStamp,TypeLogin);
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

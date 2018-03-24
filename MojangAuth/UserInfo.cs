using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojangAuth
{
    public class UserInfo
    {

        private string username;
        private string accessToken;
        private string uuid;

        public UserInfo(string username, string accessToken, string uuid)
        {
            this.username = username;
            this.accessToken = accessToken;
            this.uuid = uuid;
        }

        public string getUsername() { return username; }
        public string getAccessToken() { return accessToken; }
        public string getUUID() { return uuid; }
    }
}

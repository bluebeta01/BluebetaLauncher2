using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MojangAuth
{
    public class Authinticator
    {
        /// <summary>
        /// Sends login info to Mojang and returns the response in a UserInfo object. Returns null if the authintication fails.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static UserInfo authinticate(string email, string password)
        {

            try
            {
                string payload = "{\"agent\":{\"name\":\"Minecraft\",\"version\":1}, \"username\":\"$email\",\"password\":\"$password\",\"clientToken\":\"000\",\"requestUser\":true}";
                payload = payload.Replace("$email", email);
                payload = payload.Replace("$password", password);

                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://authserver.mojang.com/authenticate");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {

                    streamWriter.Write(payload);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string result;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

                JObject jsonResponseObj = JObject.Parse(result);
                JObject jsonSelectedProfileObj = JObject.Parse(jsonResponseObj.GetValue("selectedProfile").ToString());

                UserInfo info = new UserInfo((string)jsonSelectedProfileObj.Property("name"), (string)jsonResponseObj.Property("accessToken"), (string)jsonSelectedProfileObj.Property("id"));
                return info;
            }
            catch
            {
                return null;
            }


        }
    }
}

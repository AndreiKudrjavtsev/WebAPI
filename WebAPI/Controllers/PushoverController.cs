using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PushoverController : Controller
    {
        // POST pushover message
        /// <summary>
        /// Method is used to send push notification to connected devices with given params
        /// </summary>
        /// <param name="appToken">Application token, this API registered in Pushover with token a5zicigr5hidd6qnkbb8nwpzjhih9h</param>
        /// <param name="userKey">User key, used to send notifications to connected devices of given user; To connect with author use upfg93o4j9wowoa5m3uyy4xfehisy5 token</param>
        /// <param name="message">Text of notification, which is being send</param>
        [HttpPost]
        public void Post(string appToken, string userKey, string message)
        {
            var parameters = new NameValueCollection {
                { "token", appToken },
                { "user", userKey },
                { "message", message }
            };

            using (var client = new WebClient())
            {
                client.UploadValues("https://api.pushover.net/1/messages.json", parameters);
            }
        }
    }
}

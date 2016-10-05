using Extreme.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramTools
{
    class LikePhoto
    {
        public static string Like(CookieDictionary Cookie, string Url)
        {
            //Потом доделаю
            using (var request = new HttpRequest())
            {
                string CSRF = null;
                Cookie.TryGetValue("csrftoken", out CSRF);

                request.Cookies = Cookie;
                request.Referer = Url;

                request.UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 8_0 like Mac OS X) AppleWebKit/600.1.3 (KHTML, like Gecko) Version/8.0 Mobile Safari/600.1.4";

                request.AddHeader("X-CSRFToken", CSRF)
                       .AddHeader("X-Instagram-AJAX", "1")
                       .AddHeader("X-Requested-With", "XMLHttpRequest");

                var response = request.Post(Url);

                return response.ToString();
            }
        }
    }
}

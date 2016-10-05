using Extreme.Net;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

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
                //Парсим ответ хмл
                HtmlDocument doc = new HtmlDocument();

                doc.LoadHtml(response.ToString());
                //Как-то блять находим там нужный нам айди поста
                string metaid = doc.DocumentNode.SelectSingleNode("/html/head/meta[18]").OuterHtml.Remove(0, 58).Remove(19, 2);

                request.AddHeader("X-CSRFToken", CSRF)
                       .AddHeader("X-Instagram-AJAX", "1")
                       .AddHeader("X-Requested-With", "XMLHttpRequest");
                //Луйкаем
                 response = request.Post("https://www.instagram.com/web/likes/" + metaid + "/like/");

                return response.ToString();
            }
        }
    }
}

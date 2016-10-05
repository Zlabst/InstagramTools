using Extreme.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramTools
{
    class Registration
    {
        public static string Reg()
        {
            using (var request = new HttpRequest())
            {
                string CSRF = GetCSRFToken.GetCSRF();
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36";

                request.AddHeader("X-CSRFToken", CSRF)
                       .AddHeader("X-Instagram-AJAX", "1")
                       .AddHeader("X-Requested-With", "XMLHttpRequest");

                request.Referer = "https://www.instagram.com/";

                request.Cookies = new CookieDictionary()
                {
                    {"csrftoken", CSRF},
                    {"mid", GetCSRFToken.midtoken},
                    {"ig_prn", "1"},
                    {"ig_vw", "1920"},
                    {"s_network", ""}
                };

                request.AddParam("email", GetEmail.RandomEmail)
                       .AddParam("password", "StasPidoras")
                       .AddParam("username", "Stoos34164124455")
                       .AddParam("first_name", GetFirstName.RandomFirstName);
                Thread.Sleep(300);

                var response = request.Post("https://www.instagram.com/accounts/web_create_ajax/attempt/");

                Thread.Sleep(300);
                request.AddHeader("X-CSRFToken", CSRF)
                       .AddHeader("X-Instagram-AJAX", "1")
                       .AddHeader("X-Requested-With", "XMLHttpRequest");

                request.AddParam("email", GetEmail.RandomEmail)
                       .AddParam("password", "StasPidoras")
                       .AddParam("username", "Stoos34164124455")
                       .AddParam("first_name", GetFirstName.RandomFirstName);

                request.Cookies = new CookieDictionary()
                {
                    {"csrftoken", CSRF},
                    {"mid", GetCSRFToken.midtoken},
                    {"ig_prn", "1"},
                    {"ig_vw", "706"},
                    {"s_network", ""}
                };

                response = request.Post("https://www.instagram.com/accounts/web_create_ajax/");

                //JsonConvert.DeserializeObject<IsAuthenticated>(response.ToString());

                //if (IsAuthenticated.Client_Authenticated == true)
                //{
                //    return response;
                //}
                //else return null;
                return response.ToString();
            }
        }
    }
}

using Extreme.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramTools
{
    class Program
    {
        public static string CSRFToken { get { return GetCSRFAndMID();} }


        static void Main(string[] args)
        {
            Console.WriteLine(Login().ToString());
            Console.ReadKey();
        }
        static string GetCSRFAndMID()
        {
            using (var request = new HttpRequest())
            {
                string Token = null;
                var response = request.Post("https://www.instagram.com/");
                response.Cookies.TryGetValue("csrftoken", out Token);
                return Token;
            }
        }

        static string Login()
        {
            string Login = "TheBottleCode";
            string Password = "F1NPidor";
            using (var request = new HttpRequest())
            {
                string CSRF = CSRFToken;
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36";

                request.AddHeader("X-CSRFToken", CSRF)
                       .AddHeader("X-Instagram-AJAX", "1")
                       .AddHeader("X-Requested-With", "XMLHttpRequest")
                       .AddParam("username", Login)
                       .AddParam("password", Password);
                request.Referer = "https://www.instagram.com/";

                request.Cookies = new CookieDictionary()
                {
                    {"csrftoken", CSRF},
                    {"ig_prn", "1"},
                    {"ig_vw", "766"},
                    {"s_network", ""}
                };

                HttpResponse response = request.Post("https://www.instagram.com/accounts/login/ajax/");

                return response.ToString();

            }
        }
    }
}

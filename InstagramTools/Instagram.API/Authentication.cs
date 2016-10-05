using Extreme.Net;

namespace InstagramTools
{
    class Authorization
    {
        public static string Login(string login, string password)
        {
            using (var request = new HttpRequest())
            {
                string CSRF = GetCSRFToken.GetCSRF();
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36";

                request.AddHeader("X-CSRFToken", CSRF)
                       .AddHeader("X-Instagram-AJAX", "1")
                       .AddHeader("X-Requested-With", "XMLHttpRequest")
                       .AddParam("username", login)
                       .AddParam("password", password);

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

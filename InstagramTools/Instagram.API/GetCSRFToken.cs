using Extreme.Net;
using System;
using System.Text;

namespace InstagramTools
{
    class GetCSRFToken
    {
        public static string midtoken { get; set; } 
        public static string GetCSRF()
        {
            using (var request = new HttpRequest())
            {
                string Mid = null;
                string Token = null;
                var response = request.Post("https://www.instagram.com/");
                response.Cookies.TryGetValue("csrftoken", out Token);
                response.Cookies.TryGetValue("mid", out Mid);
                midtoken = Mid;
                return Token;
            }
        }
    }
}

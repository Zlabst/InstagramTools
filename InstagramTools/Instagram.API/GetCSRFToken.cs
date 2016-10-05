using Extreme.Net;

namespace InstagramTools
{
    class GetCSRFToken
    {
        public static string GetCSRF()
        {
            using (var request = new HttpRequest())
            {
                string Token = null;
                var response = request.Post("https://www.instagram.com/");
                response.Cookies.TryGetValue("csrftoken", out Token);
                return Token;
            }
        }
    }
}

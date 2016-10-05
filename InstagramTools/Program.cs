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
        static void Main(string[] args)
        {
            var Auth = Authorization.Login("TheBottleCode", "F1NPidor");
            if (Auth != null)
            {
                Console.WriteLine("Успешно авторизировались");
                //Потом доделаю
                Console.WriteLine(LikePhoto.Like(Auth.Cookies, "https://www.instagram.com/p/BLG0X6Cj8Ha/"));
            }
            else Console.WriteLine("Логин или пароль введен не правильно");
                
            Console.ReadKey();
        } 
    }
}

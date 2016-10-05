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
            if (Authorization.Login("TheBottleCode", "F1NPidor") != null)
            {
                Console.WriteLine("Успешно авторизировались");
            }
            else Console.WriteLine("Логин или пароль введен не правильно");
                
            Console.ReadKey();
        } 
    }
}

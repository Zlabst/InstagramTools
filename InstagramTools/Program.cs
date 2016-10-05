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
            Console.WriteLine(Authorization.Login("TheBottleCode", "F1NPidor"));
            Console.ReadKey();
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramTools
{
    class GetEmail
    {
        public static string RandomEmail
        {
            get
            {
                return GenerateEmailAddress();
            }
        }

        static string GenerateEmailAddress()
        {
            string[] Names = { "Alexander", "Ivan", "Matvey", "Stas", "Makss", "Nikitos", "Danka", "Artom", "Ivan", "Dima", "Kirill" };
            string[] SecondNames = { "Boykov", "Makarov", "Matveev", "Gandibanov", "Reksov", "Aperturov", "Finskiy", "Polskiy", "Dolbaebskiy", "Stanislovich", "Ivnovin" };
            string[] Domains = { "@gmail.com", "@hotmail.com", "@yandex.ru", "@ya.ru", "@yandex.by"};

            return Names[new Random().Next(0, Names.Length)] + "." + SecondNames[new Random().Next(0, SecondNames.Length)] + GetRandomNumber() + Domains[new Random().Next(0, Domains.Length)];
        }

        static int GetRandomNumber()
        {
            return new Random().Next(1000, 100000);
        }
    }
}

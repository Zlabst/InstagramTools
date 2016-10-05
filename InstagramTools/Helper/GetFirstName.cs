using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramTools
{
    class GetFirstName
    {
        public static string RandomFirstName
        {
            get
            {
                string[] Names = { "Александр", "Иван", "Матвей", "Станислав", "Максим", "Никита", "Даниил", "Артем", "Иван", "Дмитрий", "Кирилл"};

                return Names[new Random().Next(0, Names.Length)];
            }
        }
    }
}

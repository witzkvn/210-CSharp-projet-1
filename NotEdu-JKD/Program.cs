using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class Program
    {
        static void Main(string[] args)
        {
            Campus campus = Serveur.DeserializeJSON();

            Menu.MenuPrincipal(campus);

            Serveur.SerializeAndWriteInJSON(campus);  // à utiliser pour actualiser le campus dans le JSON
            Console.ReadLine();
        }
    }
}

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
            Campus campus;
            if (args.Length > 0)
            {
                campus = Serveur.DeserializeJSON(args[0]);
            }
            else
            {
                campus = Serveur.DeserializeJSON(null);
            }

            Menu.MenuPrincipal(campus);

        }
    }
}

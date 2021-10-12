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
            if(campus is null)
            {
                campus = new Campus();
            }


            Eleve mario = new Eleve("BROS", "Mario", DateTime.Parse("11/11/2001"));
            campus.ListeEleves.AjouterEleveDansListe(mario);
            campus.ListeEleves.AfficherListeEleves();

            Console.ReadLine();
        }
    }
}

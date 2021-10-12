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
            Eleve kevin = new Eleve("Witz", "Kévin", new DateTime(1995, 08, 01));
            Eleve naim = new Eleve("El Moudni", "Naïm", new DateTime(1992, 10, 17));
            ListeEleves.AjouterEleveDansListe(kevin);
            ListeEleves.AjouterEleveDansListe(naim);
            ListeCours.AjouterCours();
            kevin.ListeNotes.Add(new Note(0, "Maths", 17, "Très bien"));
            naim.ListeNotes.Add(new Note(0, "Maths", 13, " Bien"));
            ListeCours.SuppressionCours();

            Console.ReadLine();
        }
    }
}

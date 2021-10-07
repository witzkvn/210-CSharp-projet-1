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
            ListeEleves campus = new ListeEleves();
            ListeCours programme = new ListeCours();
            Eleve kevin = new Eleve("Witz", "Kévin", new DateTime(1995, 08, 01));
            Eleve naim = new Eleve("El Moudni", "Naïm", new DateTime(1992, 10, 17));
            campus.AjouterEleveDansListe(kevin);
            campus.AjouterEleveDansListe(naim);
            programme.AjouterCours(new Cours("Maths"));
            kevin.ListeNotes.Add(new Note(programme.ListeDesCours[0], 13, "Bien" ));
            naim.ListeNotes.Add(new Note(programme.ListeDesCours[0], 17, "Très bien"));
            programme.SuppressionCours(campus);

            Console.ReadLine();
        }
    }
}

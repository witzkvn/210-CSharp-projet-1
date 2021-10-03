using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class ListeCours
    {
        public static Dictionary<int, Cours> ListeDesCours { get; }
        static ListeCours()
        {
            ListeDesCours = new Dictionary<int, Cours>();
        }
        public static void AjouterCours(Cours nouveauCours)
        {
            if (ListeDesCours.ContainsKey(nouveauCours.Id))
            {
                Console.WriteLine($"Le cours {nouveauCours.Titre} existe déjà, veuillez réessayer avec un autre cours.");
            }
            else
            {
                ListeDesCours.Add(nouveauCours.Id, nouveauCours);
                Console.WriteLine($"Ajout du cours {nouveauCours.Titre} réussi.");
            }
        }

        /*Suppression de toutes les occurences d'un cours.*/
        public static void SuppressionCours(int coursId)
        {
            if (!ListeDesCours.ContainsKey(coursId))
            {
                Console.WriteLine("Ce cours n'existe pas, veuillez entrer un cours valide.");
                return;
            }
            Cours coursASupprimer = ListeDesCours[coursId];
            Console.Write("/!\\ La suppression d'un cours entraîne la suppression de toutes les notes " +
                "et appréciations qui lui sont liées. \n" +
                $"Voulez-vous vraiment supprimer le cours {coursASupprimer.Titre}? (Oui/Non) ");
            string reponseSuppression = Console.ReadLine().ToLower();

            if (reponseSuppression == "oui")
            {
                /* Loop à travers tout les élèves, dans toutes leurs notes pour trouver l'ID correspondant*/
                ListeDesCours.Remove(coursId);
            }
            else
            {
                Console.WriteLine("Annulation de la suppression du cours.");
            }
        }
        public static void AfficherToutLesCours()
        {
            Console.WriteLine("\tListe de tout les cours disponibles : \n");
            foreach (KeyValuePair<int, Cours> cours in ListeDesCours)
            {
                Console.WriteLine($"\t Cours : {cours.Value.Titre} ; ID : {cours.Value.Id}");
            }
        }
        public static void AfficherNotesCours(Cours cours)
        {
            /* Loop dans la liste des élèves pour trouver les notes correspondants au cours */
        }
    }
}

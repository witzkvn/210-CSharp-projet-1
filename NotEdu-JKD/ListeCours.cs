using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    static class ListeCours
    {
        private static Dictionary<int, Cours> _listeDesCours = new Dictionary<int, Cours>();

        public static Cours GetCoursById(int idCours)
        {
            return _listeDesCours[idCours];
        }
        public static void AjouterCours(Cours nouveauCours)
        {
            if (_listeDesCours.ContainsKey(nouveauCours.Id))
            {
                Console.WriteLine($"Le cours {nouveauCours.Titre} existe déjà, veuillez réessayer avec un autre cours.");
            }
            else
            {
                _listeDesCours.Add(nouveauCours.Id, nouveauCours);
                Console.WriteLine($"Ajout du cours {nouveauCours.Titre} réussi.");
            }
        }
        public static void AfficherTousLesCours()
        {
            Console.WriteLine("Liste de tous les cours disponibles : \n");
            foreach (KeyValuePair<int, Cours> cours in _listeDesCours)
            {
                Console.WriteLine($" ID : {cours.Value.Id} | Cours : {cours.Value.Titre}\n");
            }
        }

        /*Suppression de toutes les occurences d'un cours.*/
        public static void SuppressionCours()
        {
            AfficherTousLesCours();
            Console.Write("Entrez l'ID du cours à supprimer : ");
            int coursId = int.Parse(Console.ReadLine());
            if (!_listeDesCours.ContainsKey(coursId))
            {
                Console.WriteLine("Ce cours n'existe pas, veuillez entrer un cours valide.");
                return;
            }
            Cours coursASupprimer = _listeDesCours[coursId];
            Console.Write("/!\\ La suppression d'un cours entraîne la suppression de touses les notes " +
                "et appréciations qui lui sont liées. \n" +
                $"Voulez-vous vraiment supprimer le cours {coursASupprimer.Titre}? (Oui/Non) ");
            string reponseSuppression = Console.ReadLine().ToLower();

            if (reponseSuppression == "oui")
            {
                /* Loop à travers tout les élèves, dans toutes leurs notes pour trouver l'ID correspondant*/
                _listeDesCours.Remove(coursId);
            }
            else
            {
                Console.WriteLine("Annulation de la suppression du cours.");
            }
        }
        public static void AfficherNotesCours()
        {
            AfficherTousLesCours();
            Console.Write("Entrez l'ID du cours à afficher : ");
            int coursId = int.Parse(Console.ReadLine());
            /* Loop dans la liste des élèves pour trouver les notes correspondants au cours */
        }
    }
}
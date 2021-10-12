using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    static class ListeCours
    {
        private static Dictionary<int, string> _listeDesCours = new Dictionary<int, string>(); 
        // TODO dans le futur, implémenter une fonction qui retourne un dict depuis le json
        private static int _idGlobalCours = _listeDesCours.Count == 0 ? 0 : _listeDesCours.Keys.Max();

        public static void AjouterCours()
        {
            Console.WriteLine("Quel est le titre du cours que vous voulez ajouter ?");
            string titreNouveauCours = Console.ReadLine();
            while (_listeDesCours.ContainsValue(titreNouveauCours))
            {
                Console.WriteLine("Un cours avec ce titre existe déjà, veuillez entrer un autre titre.");
                titreNouveauCours = Console.ReadLine();
            }
            _listeDesCours.Add(_idGlobalCours, titreNouveauCours);
            Console.WriteLine($"Ajout du cours {titreNouveauCours} réussi.");
            _idGlobalCours++;
        }
        public static void AfficherTousLesCours()
        {
            // TODO retour menu si liste de cours vide
            Console.WriteLine("Liste de tous les cours disponibles (ID --- Nom du cours) : \n");
            foreach (KeyValuePair<int, string> cours in _listeDesCours)
            {
                Console.WriteLine($"{cours.Key} --- {cours.Value}");
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
                SuppressionCours();
            }
            string coursASupprimer = _listeDesCours[coursId];
            Console.Write("/!\\ La suppression d'un cours entraîne la suppression de touses les notes et appréciations qui lui sont liées.");
            Console.WriteLine($"Voulez-vous vraiment supprimer le cours {coursASupprimer}? (Oui/Non) ");
            string reponseSuppression = Console.ReadLine().ToLower();

            if (reponseSuppression == "oui")
            {
                /* Loop à travers tout les élèves, dans toutes leurs notes pour trouver l'ID correspondant*/
                ListeEleves.SupprimerCours(coursId);
                _listeDesCours.Remove(coursId);
                Console.WriteLine($"Le cours {coursASupprimer} à bien été supprimé.");
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

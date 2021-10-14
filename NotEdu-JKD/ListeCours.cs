using System;
using System.Collections.Generic;

namespace NotEdu_JKD
{
    class ListeCours
    {
        public  Dictionary<int, string> ListeDesCours { get; }
        public int IdGlobalCours { get; private set; }

        public ListeCours()
        {
            ListeDesCours = new Dictionary<int, string>();
            IdGlobalCours = 0;
        }

        public  void AjouterCours()
        {
            Console.WriteLine("Quel est le titre du cours que vous voulez ajouter ?");
            string titreNouveauCours = Console.ReadLine();
            while (ListeDesCours.ContainsValue(titreNouveauCours))
            {
                Console.WriteLine("Un cours avec ce titre existe déjà, veuillez entrer un autre titre.");
                titreNouveauCours = Console.ReadLine();
            }
            ListeDesCours.Add(IdGlobalCours, titreNouveauCours);
            Console.WriteLine($"Ajout du cours {titreNouveauCours} réussi.");
            IdGlobalCours++;
        }
        public void AfficherTousLesCours(Campus campus)
        {
            if(ListeDesCours.Count == 0)
            {
                Console.WriteLine("Aucun cours disponible.");
                Utilitaire.RetourMenuApresDelais(campus, 3);
                
            }
            Console.WriteLine("Liste de tous les cours disponibles (ID --- Nom du cours) : \n");
            foreach (KeyValuePair<int, string> cours in ListeDesCours)
            {
                Console.WriteLine($"{cours.Key} --- {cours.Value}");
            }
        }

        /*Suppression de toutes les occurences d'un cours.*/
        public void SuppressionCours(Campus campus)
        {
            AfficherTousLesCours(campus);
            Console.Write("Entrez l'ID du cours à supprimer : ");
            int coursId = int.Parse(Console.ReadLine());
            if (!ListeDesCours.ContainsKey(coursId))
            {
                Console.WriteLine("Ce cours n'existe pas, veuillez entrer un cours valide.");
                SuppressionCours(campus);
            }
            string coursASupprimer = ListeDesCours[coursId];
            Console.Write("/!\\ La suppression d'un cours entraîne la suppression de touses les notes et appréciations qui lui sont liées.");
            Console.WriteLine($"Voulez-vous vraiment supprimer le cours {coursASupprimer}? (Oui/Non) ");
            string reponseSuppression = Console.ReadLine().ToLower();

            if (reponseSuppression == "oui")
            {
                /* Loop à travers tout les élèves, dans toutes leurs notes pour trouver l'ID correspondant*/
                campus.ListeEleves.SupprimerCours(campus, coursId);
                ListeDesCours.Remove(coursId);
                Console.WriteLine($"Le cours {coursASupprimer} à bien été supprimé.");
            }
            else
            {
                Console.WriteLine("Annulation de la suppression du cours.");
            }
        }
        public void AfficherNotesCours(Campus campus)
        {
            AfficherTousLesCours(campus);
            Console.Write("Entrez l'ID du cours à afficher : ");
            int coursId = int.Parse(Console.ReadLine());
            /* Loop dans la liste des élèves pour trouver les notes correspondants au cours */
        }
    }
}

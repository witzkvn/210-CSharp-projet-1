using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace NotEdu_JKD
{
    class ListeCours
    {
        [JsonProperty]
        public  Dictionary<int, string> ListeDesCours { get; }
        [JsonProperty]
        public int IdGlobalCours { get; private set; }

        public ListeCours()
        {
            ListeDesCours = new Dictionary<int, string>();
            IdGlobalCours = 0;
        }

        public  void AjouterCours(Campus campus)
        {
            Console.Write("     Quel est le titre du cours que vous voulez ajouter ?");
            string titreNouveauCours = Console.ReadLine();
            while (ListeDesCours.ContainsValue(titreNouveauCours))
            {
                Console.Write("      Un cours avec ce titre existe déjà, veuillez entrer un autre titre.");
                titreNouveauCours = Console.ReadLine();
            }
            while (!Utilitaire.VerifUniquementLettres(titreNouveauCours))
            {
                Console.WriteLine("     Le titre ne doit contenir que des lettres. Réessayez. ");
                titreNouveauCours = Console.ReadLine();
            }
            if (titreNouveauCours.ToLower() == "retour")
            {
                Utilitaire.RetourMenuApresDelais(campus, 3);
            }
            ListeDesCours.Add(IdGlobalCours, titreNouveauCours);
            Console.WriteLine($"      Ajout du cours {titreNouveauCours} réussi.");
            IdGlobalCours++;
        }
        public void AfficherTousLesCours(Campus campus)
        {
            if(ListeDesCours.Count == 0)
            {
                Console.WriteLine("     Aucun cours disponible.");
                Utilitaire.RetourMenuApresDelais(campus, 3);
                
            }
            Console.WriteLine("      Liste de tous les cours disponibles (ID --- Nom du cours) : \n");
            foreach (KeyValuePair<int, string> cours in ListeDesCours)
            {
                Console.WriteLine($"     {cours.Key} --- {cours.Value}");
            }
            Console.ReadLine();
        }

        /*Suppression de toutes les occurences d'un cours.*/
        public void SuppressionCours(Campus campus)
        {
            AfficherTousLesCours(campus);
            Console.Write("     Entrez l'ID du cours à supprimer : ");
            string input = Console.ReadLine();
            
            while (true)
            {
                if (input.ToLower() == "retour")
                {
                    Console.WriteLine("     Retour au menu précédent.");
                    Utilitaire.RetourMenuApresDelais(campus, 3);
                }
                else if (!Utilitaire.VerifUniquementEntiers(input))
                {
                    Console.Write("     L'ID doit être un entier. Réessayez.");
                    input = Console.ReadLine();
                    continue;
                }
                

                int idCours = int.Parse(input);
                if (!ListeDesCours.ContainsKey(idCours))
                {
                    Console.Write("     Ce cours n'existe pas. Réessayez.");
                    input = Console.ReadLine();
                    continue;
                }
                else { break; }
            }
            int coursId = int.Parse(input);
            string coursASupprimer = ListeDesCours[coursId];
            Console.Write("     /!\\ La suppression d'un cours entraîne la suppression de touses les notes et appréciations qui lui sont liées.");
            Console.WriteLine($"Voulez-vous vraiment supprimer le cours {coursASupprimer}? (Oui/Non) ");
            string reponseSuppression = Console.ReadLine().ToLower();

            if (reponseSuppression == "oui")
            {
                campus.ListeEleves.SupprimerCours(coursId);
                ListeDesCours.Remove(coursId);
                Console.WriteLine($"     Le cours {coursASupprimer} à bien été supprimé.");
                Utilitaire.RetourMenuApresDelais(campus, 3);
            }
            else
            {
                Console.WriteLine("     Annulation de la suppression du cours.");
                Utilitaire.RetourMenuApresDelais(campus, 3);
            }
        }
    }
}

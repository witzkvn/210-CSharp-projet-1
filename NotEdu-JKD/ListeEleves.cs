using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class ListeEleves
    {
        public static List<Eleve> listeEleves = new List<Eleve>();
        public ListeEleves()
        {
            // récupérer liste du JSON et la mettre dans listeEleves à la première init
        }

        public static void AjouterEleveDansListe(Eleve nouvelEleve)
        {
            listeEleves.Add(nouvelEleve);
            ActualiserListeJSON();
        }

        public static void SupprimerEleveDansListe(int eleveID)
        {
            Eleve eleveASupprimer = listeEleves[eleveID];
            if(eleveASupprimer == null)
            {
                Console.WriteLine("Désolé, aucun cours avec cet identifiant n'a été trouvé dans la liste.");
            } else
            {
                Console.Write("/!\\ La suppression d'un élève entraîne la suppression de toutes les notes " +
                    "et appréciations qui lui sont liées. \n" +
                    $"Voulez-vous vraiment supprimer l'élève {eleveASupprimer.Nom} {eleveASupprimer.Prenom}? (Oui/Non) ");
                string reponseSuppression = Console.ReadLine().ToLower();

                if (reponseSuppression == "oui")
                {
                    /* Loop à travers les notes de l'élève et les supprimer toutes avant suppression élève */
                    listeEleves = listeEleves.Where(eleve => eleve.ID != eleveID).ToList();
                }
                else
                {
                    Console.WriteLine("Annulation de la suppression de l'élève.");
                    return;
                }

            }
            ActualiserListeJSON();
        }

        private static void ActualiserListeJSON()
        {
            // actualiser la listeEleves dans le JSON
        }
    }
}

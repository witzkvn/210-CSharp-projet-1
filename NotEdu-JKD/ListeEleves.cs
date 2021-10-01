using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class ListeEleves
    {
        static Dictionary<int, Eleve> _listeDesEleves;
        public ListeEleves()
        {
            // récupérer liste du JSON et la mettre dans listeEleves à la première init
            _listeDesEleves = new Dictionary<int, Eleve>();
        }

        public static void AjouterEleveDansListe(Eleve nouvelEleve)
        {
            _listeDesEleves.Add(nouvelEleve.ID, nouvelEleve);
            ActualiserListeJSON();
        }

        public static void SupprimerEleveDansListe(int eleveID)
        {
            Eleve eleveASupprimer = _listeDesEleves[eleveID];
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
                    _listeDesEleves.Remove(eleveID);
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

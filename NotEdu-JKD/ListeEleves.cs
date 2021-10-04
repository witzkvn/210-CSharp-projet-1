using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class ListeEleves
    {
        private Dictionary<int, Eleve> _listeDesEleves;
        public ListeEleves()
        {
            // récupérer liste du JSON et la mettre dans listeEleves à la première init
            _listeDesEleves = new Dictionary<int, Eleve>();
        }

        public void AjouterEleveDansListe(Eleve nouvelEleve)
        {
            if (_listeDesEleves.ContainsKey(nouvelEleve.ID))
            {
                Console.WriteLine($"L'ID {nouvelEleve.ID} est déjà attribué à un autre élève. Merci de réessayer en créant un nouvel élève.");
            }
            else
            {
                _listeDesEleves.Add(nouvelEleve.ID, nouvelEleve);
                Console.WriteLine($"Ajout de l'élève {nouvelEleve.Nom} {nouvelEleve.Prenom} réussi.");
                ActualiserListeJSON();
            }
        }

        public void SupprimerEleveDansListe(int eleveID)
        {
            Eleve eleveASupprimer = _listeDesEleves[eleveID];
            if(eleveASupprimer == null)
            {
                Console.WriteLine("Désolé, aucun élève avec cet identifiant n'a été trouvé dans la liste.");
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

        private void ActualiserListeJSON()
        {
            // actualiser la listeEleves dans le JSON
        }

        public void AfficherListeEleves()
        {
            if(_listeDesEleves.Count == 0)
            {
                Console.WriteLine("Aucun élève répertorié pour le moment.");
            } else
            {
                Console.WriteLine("Liste des élèves du campus (ID --- NOM Prénom) : ");
                Console.WriteLine();
                foreach (KeyValuePair<int, Eleve> eleve in _listeDesEleves)
                {
                    Console.WriteLine($"{eleve.Key} --- {eleve.Value.Nom.ToUpper()} {Utilitaire.PremiereLettreMajuscule(eleve.Value.Prenom)}");
                }
            }
        }
    }
}

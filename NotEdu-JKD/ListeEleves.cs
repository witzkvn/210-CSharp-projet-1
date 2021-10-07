using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    static class ListeEleves
    {
        static private Dictionary<int, Eleve> _listeDesEleves = _listeDesEleves = new Dictionary<int, Eleve>();
        // TODO récupérer liste des élèves du JSON et la mettre dans _listeEleves
        private static int _idGlobalEleve = _listeDesEleves.Count == 0 ? 0 : _listeDesEleves.Keys.Max();


        static public void AjouterEleveDansListe(Eleve nouvelEleve)
        {
            _idGlobalEleve++;
            _listeDesEleves.Add(_idGlobalEleve, nouvelEleve);
            Console.WriteLine($"Ajout de l'élève {nouvelEleve.Nom} {nouvelEleve.Prenom} réussi.");
            ActualiserListeJSON();
            // ajouter appel méthode retour au menu
        }

        static public void SupprimerEleveDansListe(int eleveID)
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

        static private void ActualiserListeJSON()
        {
            // actualiser la listeEleves dans le JSON
        }

        static public void AfficherListeEleves()
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

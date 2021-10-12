﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class ListeEleves
    {
        public Dictionary<int, Eleve> ListeDesEleves;
        
        // TODO récupérer liste des élèves du JSON et la mettre dans _listeEleves
        private int _idGlobalEleve;

        public ListeEleves()
        {
            ListeDesEleves = new Dictionary<int, Eleve>();
            _idGlobalEleve = ListeDesEleves.Count == 0 ? 0 : ListeDesEleves.Keys.Max();
        }

        public void AjouterEleveDansListe(Eleve nouvelEleve)
        {
            _idGlobalEleve++;
            ListeDesEleves.Add(_idGlobalEleve, nouvelEleve);
            Console.WriteLine($"Ajout de l'élève {nouvelEleve.Nom} {nouvelEleve.Prenom} réussi.");
            ActualiserListeJSON();
            // ajouter appel méthode retour au menu
        }

        public void CreerNouvelEleve()
        {
            string nom = "";
            string prenom = "";
            string dateNaissance = "";

            while (!Utilitaire.VerifUniquementLettres(nom) || nom == "")
            {
                Console.Write("Quel est le nom du nouvel élève ? (lettres uniquement -- 'retour' pour quitter) : ");
                nom = Console.ReadLine().ToLower();
                if (nom == "retour")
                {
                    // appeler méthode de menu pour revenir au menu principal
                    break;
                }
            }

            while (!Utilitaire.VerifUniquementLettres(prenom) || prenom == "")
            {
                Console.Write("Quel est le prénom du nouvel élève ? (lettres uniquement -- 'retour' pour quitter) : ");
                prenom = Console.ReadLine().ToLower();
                if (prenom == "retour")
                {
                    // appeler méthode de menu pour revenir au menu principal
                    break;
                }
            }

            while (!Utilitaire.VerifFormatDate(dateNaissance) || dateNaissance == "")
            {
                Console.Write("Quel est la date de naissance du nouvel élève ? (format JJ/MM/AAAA -- 'retour' pour quitter) : ");
                dateNaissance = Console.ReadLine().ToLower();
                if (dateNaissance == "retour")
                {
                    // appeler méthode de menu pour revenir au menu principal
                    break;
                }
            }

            DateTime dateNaissanceValideEleve = Utilitaire.StringToDate(dateNaissance);
            Eleve nouvelEleve = new Eleve(nom.ToUpper(), Utilitaire.PremiereLettreMajuscule(prenom), dateNaissanceValideEleve);

            string choixAction;
            do
            {
                Console.Clear();
                Console.WriteLine("Voici le récapitulatif des informations saisies... ");
                Console.WriteLine();
                nouvelEleve.AfficherInfoEleve();
                Console.WriteLine();
                Console.WriteLine("Que souhaitez-vous faire ? (choisir l'action par son numéro)");
                Console.WriteLine();
                Console.WriteLine("1 - Valider la saisie et ajouter l'élève au campus");
                Console.WriteLine("2 - Recommencer la saisie du nouvel élève depuis le début");
                Console.WriteLine("3 - Annuler la saisie et revenir au menu principal");
                Console.WriteLine();
                Console.Write("Votre choix : ");
                choixAction = Console.ReadLine();
            } while (choixAction != "1" && choixAction != "2" && choixAction != "3");

            Console.WriteLine();
            if (choixAction == "1")
            {
                this.AjouterEleveDansListe(nouvelEleve);
            }
            else if (choixAction == "2")
            {
                Console.Clear();
                CreerNouvelEleve();
            }
            else
            {
                // appeler méthode de menu pour revenir au menu principal
                Console.WriteLine("Retour menu principal");
            }
        }

        public void SupprimerEleveDansListe()
        {
            Console.Clear();
            Console.WriteLine("Suppression d'un élève");
            Console.WriteLine();
            AfficherListeEleves();

            if (ListeDesEleves.Count == 0)
            {
                Console.WriteLine("La liste des élèves étant vide, vous ne pouvez pas en supprimer.");
                // ajouter appel méthode retour au menu
                return;
            }
            Console.WriteLine();

            int idEleveASupprimer;
            string saisieUtilisateur;
            do
            {
                Console.Write("Quel élève souhaitez-vous supprimer ? (donner son ID ou taper 'retour' pour revenir au menu principal) : ");
                saisieUtilisateur = Console.ReadLine().ToLower();
            } while((!Int32.TryParse(saisieUtilisateur, out idEleveASupprimer) || !ListeDesEleves.ContainsKey(idEleveASupprimer)) && saisieUtilisateur != "retour");

            if (saisieUtilisateur == "retour")
            {
                // appeler méthode de menu pour revenir au menu principal
                Console.WriteLine("Retour au menu principal");
                return;
            }
            else
            {
                Eleve eleveASupprimer = ListeDesEleves[idEleveASupprimer];
                Console.Clear();
                Console.WriteLine("Elève sélectionné : ");
                eleveASupprimer.AfficherInfoEleve();
                Console.WriteLine();

                Console.WriteLine("/!\\ La suppression d'un élève entraîne la suppression de toutes les notes " +
                "et appréciations qui lui sont liées.");
                Console.Write($"Voulez-vous vraiment supprimer l'élève {eleveASupprimer.Nom} {eleveASupprimer.Prenom}? (Oui/Non) : ");
                string reponseSuppression = Console.ReadLine().ToLower();

                if (reponseSuppression == "oui")
                {
                    ListeDesEleves.Remove(idEleveASupprimer);
                    Console.WriteLine("Suppression de l'élève réussie.");
                    ActualiserListeJSON();
                }
                else
                {
                    Console.WriteLine("Annulation de la suppression de l'élève.");
                }
            }
            SupprimerEleveDansListe();
        }

        private void ActualiserListeJSON()
        {
            // actualiser la listeEleves dans le JSON
        }

        public void AfficherListeEleves()
        {
            if(ListeDesEleves.Count == 0)
            {
                Console.WriteLine("Aucun élève répertorié pour le moment.");
            } else
            {
                Console.WriteLine("Liste des élèves du campus (ID --- NOM Prénom) : ");
                Console.WriteLine();
                foreach (KeyValuePair<int, Eleve> eleve in ListeDesEleves)
                {
                    Console.WriteLine($"{eleve.Key} --- {eleve.Value.Nom.ToUpper()} {Utilitaire.PremiereLettreMajuscule(eleve.Value.Prenom)}");
                }
            }
        }

        public void SupprimerCours(int coursId)
        {
            foreach (KeyValuePair<int, Eleve> eleve in ListeDesEleves)
            {
                eleve.Value.SupprimerCours(coursId);
            }
        }
    }
}

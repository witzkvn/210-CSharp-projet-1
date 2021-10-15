using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class ListeEleves
    {
        [JsonProperty]
        public Dictionary<int, Eleve> ListeDesEleves { get; }

        [JsonProperty]
        public int IdGlobalEleve { get; private set; }

        public ListeEleves()
        {
            ListeDesEleves = new Dictionary<int, Eleve>();
            IdGlobalEleve = 0;
        }

        public void AjouterEleveDansListe(Eleve nouvelEleve)
        {
            IdGlobalEleve++;
            ListeDesEleves.Add(IdGlobalEleve, nouvelEleve);
            Console.WriteLine($"Ajout de l'élève {nouvelEleve.Nom} {nouvelEleve.Prenom} réussi.");
        }

        public void CreerNouvelEleve(Campus campus)
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
                    Utilitaire.RetourMenuApresDelais(campus, 2);
                    break;
                }
            }

            while (!Utilitaire.VerifUniquementLettres(prenom) || prenom == "")
            {
                Console.Write("Quel est le prénom du nouvel élève ? (lettres uniquement -- 'retour' pour quitter) : ");
                prenom = Console.ReadLine().ToLower();
                if (prenom == "retour")
                {
                    Utilitaire.RetourMenuApresDelais(campus, 2);
                    break;
                }
            }

            while (!Utilitaire.VerifFormatDate(dateNaissance) || dateNaissance == "")
            {
                Console.Write("Quel est la date de naissance du nouvel élève ? (format JJ/MM/AAAA -- 'retour' pour quitter) : ");
                dateNaissance = Console.ReadLine().ToLower();
                if (dateNaissance == "retour")
                {
                    Utilitaire.RetourMenuApresDelais(campus, 2);
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
                Serveur.SerializeAndWriteInJSON(campus);
                Console.WriteLine("     Vous allez être redirigé automatiquement...");
                Utilitaire.RetourMenuApresDelais(campus, 2);
            }
            else if (choixAction == "2")
            {
                Console.Clear();
                CreerNouvelEleve(campus);
            }
            else
            {
                Menu.MenuPrincipal(campus);
            }
        }

        public void SupprimerEleveDansListe(Campus campus)
        {
            Console.Clear();
            Console.WriteLine("Suppression d'un élève");
            Console.WriteLine();
            AfficherListeEleves(campus);

            if (ListeDesEleves.Count == 0)
            {
                Console.WriteLine("La liste des élèves étant vide, vous ne pouvez pas en supprimer.");
                Console.WriteLine("Vous allez être redirigé automatiquement...");
                Utilitaire.RetourMenuApresDelais(campus, 2);
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
                Menu.MenuPrincipal(campus);
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
                }
                else
                {
                    Console.WriteLine("     Annulation de la suppression de l'élève.");
                    Console.WriteLine("     Vous allez être redirigé automatiquement...");
                    Utilitaire.RetourMenuApresDelais(campus, 2);
                }
            }
            SupprimerEleveDansListe(campus);
        }

        public void AfficherListeEleves(Campus campus)
        {
            if(ListeDesEleves.Count == 0)
            {
                Console.WriteLine("Aucun élève répertorié pour le moment.");
                Utilitaire.RetourMenuApresDelais(campus, 2);
            } else
            {
                Console.WriteLine("Liste des élèves du campus (ID --- NOM Prénom) : ");
                Console.WriteLine();
                foreach (KeyValuePair<int, Eleve> eleve in ListeDesEleves)
                {
                    Console.WriteLine($"{eleve.Key} --- {eleve.Value.Nom.ToUpper()} {Utilitaire.PremiereLettreMajuscule(eleve.Value.Prenom)}");
                }
            }
            Console.WriteLine();
        }

        public void SupprimerCours(int coursId)
        {
            foreach (KeyValuePair<int, Eleve> eleve in ListeDesEleves)
            {
                eleve.Value.SupprimerCours(coursId);
            }
        }
        public void AfficherUnEleve(Campus campus)
        {
            AfficherListeEleves(campus);
            Console.WriteLine("     Entrez l'ID de l'élève à afficher : ");
            string input = Console.ReadLine();
            if (input.ToLower() == "retour")
            {
                Utilitaire.RetourMenuApresDelais(campus, 2);
            }
            if (!Utilitaire.VerifUniquementEntiers(input))
            {
                Console.WriteLine("     L'ID doit être un entier. Retour au menu précédent.");
                Utilitaire.RetourMenuApresDelais(campus, 2);
            }
            int idEleve = int.Parse(input);
            if (!ListeDesEleves.ContainsKey(idEleve))
            {
                Console.WriteLine("     L'ID n'existe pas. Retour au menu précédent.");
                Utilitaire.RetourMenuApresDelais(campus, 2);
            }
            ListeDesEleves[idEleve].AfficherInfoEleve();
        }

        public void AjouterNoteEtAppreciationEleve(Campus campus)
        {
            AfficherListeEleves(campus);
            int idEleve;
            string saisieUtilisateurIDEleve;
            do
            {
                Console.WriteLine("     A quel élève voulez-vous ajouter une note ? (donner son ID ou taper 'retour' pour revenir au menu principal) : ");
                saisieUtilisateurIDEleve = Console.ReadLine().ToLower();
            } while ((!Int32.TryParse(saisieUtilisateurIDEleve, out idEleve) || !ListeDesEleves.ContainsKey(idEleve)) && saisieUtilisateurIDEleve != "retour");

            if (saisieUtilisateurIDEleve == "retour")
            {
                Menu.MenuEleves(campus);
                return;
            }
            Eleve eleveSelectionne = ListeDesEleves[idEleve];

            Console.WriteLine();
            campus.ListeCours.AfficherTousLesCours(campus);
            int idCours;
            string saisieUtilisateurIDCours;
            do
            {
                Console.WriteLine("     A quelle matière voulez-vous ajouter cette note ? (donner son ID ou taper 'retour' pour revenir au menu principal) : ");
                saisieUtilisateurIDCours = Console.ReadLine().ToLower();
            } while ((!Int32.TryParse(saisieUtilisateurIDCours, out idCours) || !campus.ListeCours.ListeDesCours.ContainsKey(idCours)) && saisieUtilisateurIDCours != "retour");
            if (saisieUtilisateurIDCours == "retour")
            {
                Menu.MenuEleves(campus);
                return;
            }
            string coursSelectionne = campus.ListeCours.ListeDesCours[idCours];

            if(eleveSelectionne.ListeNotes.Any(noteEleve => noteEleve.IdCoursLie == idCours))
            {
                Console.WriteLine("Attention, une note pour cette matière a déjà été trouvée... ");
                Console.WriteLine("Vous ne pouvez plus ajouter de note pour cette matière.");
                Console.WriteLine("Vous allez être automatiquement redirigé...");
                AjouterNoteEtAppreciationEleve(campus);
            }

            Console.WriteLine();
            double note;
            string saisieUtilisateurNote;
            do
            {
                Console.WriteLine("     Quelle est la valeur de la note ? (valeur chiffrée ou 'retour' pour revenir au menu principal) : ");
                saisieUtilisateurNote = Console.ReadLine().ToLower();
                saisieUtilisateurNote = saisieUtilisateurNote.Replace('.', ',');
            } while ((!Double.TryParse(saisieUtilisateurNote, out note) || (note < 0.0 || note > 20.0)) && saisieUtilisateurIDCours != "retour");
            if (saisieUtilisateurNote == "retour")
            {
                Menu.MenuEleves(campus);
                return;
            }
            note = Utilitaire.ArrondirNote(note);

            Console.WriteLine();
            string appreciation;
            Console.Write("     Quelle est l'appréciation ? (facultatif, touche Entree pour continuer ou 'retour' pour revenir au menu principal) : ");
            appreciation = Console.ReadLine().ToLower();
            
            if (appreciation == "retour")
            {
                Menu.MenuEleves(campus);
                return;
            }

            Console.WriteLine("Récapitulatif de la saisie : ");
            Console.WriteLine($"Nom de l'élève : {eleveSelectionne.Nom} {eleveSelectionne.Prenom}");
            Console.WriteLine("Cours de la note : " + coursSelectionne);
            Console.WriteLine("Valeur de la note : " + Utilitaire.FormatterNoteSurVingt(note));
            Console.WriteLine("Appréciation : " + appreciation);
            Console.WriteLine();
            Console.Write("La saisie est-elle correcte ? (Oui/Non) ");
            string reponse = Console.ReadLine().ToLower();
            if (reponse == "oui")
            {
                eleveSelectionne.ListeNotes.Add(new Note(idCours, coursSelectionne, note, appreciation));
                Serveur.SerializeAndWriteInJSON(campus);
                Console.WriteLine("     Ajout de la note à l'élève réussie.");
                Console.WriteLine("     Vous allez être redirigé automatiquement...");
                Utilitaire.RetourMenuApresDelais(campus, 2);
            }
            else
            {
                AjouterNoteEtAppreciationEleve(campus);
            }
        }
    }
}

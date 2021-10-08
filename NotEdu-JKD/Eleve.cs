using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class Eleve
    {
        public string Nom { get; private set; }
        public string Prenom { get; private set; }
        public DateTime DateNaissance { get; private set; }
        public List<Note> ListeNotes { get; set; }

        public Eleve(string nom, string prenom, DateTime dateNaissance)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.DateNaissance = dateNaissance;
        }

        static public void CreerNouvelEleve()
        {
            string nom = "";
            string prenom = "";
            string dateNaissance = "";

            while (!Utilitaire.VerifUniquementLettres(nom) || nom == "")
            {
                Console.Write("Quel est le nom du nouvel élève ? (lettres uniquement -- 'retour' pour quitter) : ");
                nom = Console.ReadLine().ToLower();
                if (nom == "retour") break;
            }
            if(nom == "retour")
            {
                // appeler méthode de menu pour revenir au menu principal
                Console.WriteLine("Retour menu principal");
            }

            while (!Utilitaire.VerifUniquementLettres(prenom) || prenom == "")
            {
                Console.Write("Quel est le prénom du nouvel élève ? (lettres uniquement -- 'retour' pour quitter) : ");
                prenom = Console.ReadLine().ToLower();
                if (prenom == "retour") break;
            }
            if (prenom == "retour")
            {
                // appeler méthode de menu pour revenir au menu principal
                Console.WriteLine("Retour menu principal");
            }

            while (!Utilitaire.VerifFormatDate(dateNaissance) || dateNaissance == "")
            {
                Console.Write("Quel est la date de naissance du nouvel élève ? (format JJ/MM/AAAA -- 'retour' pour quitter) : ");
                dateNaissance = Console.ReadLine().ToLower();
                if (dateNaissance == "retour") break;
            }
            if (dateNaissance == "retour")
            {
                // appeler méthode de menu pour revenir au menu principal
                Console.WriteLine("Retour menu principal");
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
                ListeEleves.AjouterEleveDansListe(nouvelEleve);
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

        public void AfficherInfoEleve()
        {
            Console.WriteLine("Informations sur l'élève :");
            Console.WriteLine();
            Console.WriteLine("Nom               : " + this.Nom);
            Console.WriteLine("Prénom            : " + this.Prenom);
            Console.WriteLine("Date de naissance : " + Utilitaire.FormatterDateCourteString(this.DateNaissance));
        }

        public void AfficherListeNotesEleve()
        {
            Console.WriteLine("Résultats scolaires :");
            Console.WriteLine();
            if(ListeNotes.Count == 0)
            {
                Console.WriteLine("Aucune note attribuée pour le moment.");
            } else
            {
                foreach (var note in ListeNotes)
                {
                    Console.WriteLine("     Cours : "); // récupérer un cours par le id spécifié dans la note
                    Console.WriteLine("         Note : " + Utilitaire.FormatterNoteSurVingt(note.ValeurNote));
                    Console.WriteLine("         Appréciation : " + note.Appreciation);
                    Console.WriteLine();
                }
            }
        }

        public void AfficherMoyenneEleve() {
            if (ListeNotes.Count == 0)
            {
                Console.WriteLine("Aucune note attribuée pour le moment, calcul de moyenne impossible.");
            }
            else
            {
                double sommeNotes = 0;
                foreach (var note in ListeNotes)
                {
                    sommeNotes += note.ValeurNote;
                }
                Console.WriteLine("    Moyenne : " + Utilitaire.FormatterNoteSurVingt(sommeNotes / ListeNotes.Count));
            }
        }    
    }
}

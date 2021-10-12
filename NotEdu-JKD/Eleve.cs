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
            ListeNotes = new List<Note>();
        }

        public void AfficherInfoEleve()
        {
            Console.WriteLine("Informations sur l'élève :");
            Console.WriteLine();
            Console.WriteLine("Nom               : " + this.Nom);
            Console.WriteLine("Prénom            : " + this.Prenom);
            Console.WriteLine("Date de naissance : " + Utilitaire.FormatterDateCourteString(this.DateNaissance));
        }

        public void AjouterNote(ListeCours programme)
        {
            programme.AfficherTousLesCours();
            try
            {
                Console.Write("Quel est l'ID du cours de la note ? ");
                int idCours = int.Parse(Console.ReadLine());
                (int id, string titre) coursIdTitre = programme.GetCoursById(idCours);
                Console.Write("Quelle est la valeur de la note ? ");
                double valeurNote = double.Parse(Console.ReadLine());
                //!valeurNote.IsDouble ? AjouterNote();
                valeurNote = valeurNote < 0 ? 0 : valeurNote;
                valeurNote = valeurNote > 20 ? 20 : valeurNote;
                Console.WriteLine("Quelle est l'appréciation ? (Touche Entrée si vide) ");
                string appreciationNote = Console.ReadLine();
                ListeNotes.Add(new Note(coursIdTitre.id, coursIdTitre.titre, valeurNote, appreciationNote));

                Console.WriteLine("Récapitulatif de la saisie : ");
                Console.WriteLine($"Nom de l'élève : {Nom} {Prenom}");
                Console.WriteLine("Cours de la note : " + coursIdTitre.titre);
                Console.WriteLine("Valeur de la note : " + valeurNote);
                Console.WriteLine("Appréciation : " + appreciationNote);

            }
            catch
            {
                Console.WriteLine("Erreur lors de la saisie de la note.\nVeuillez réessayer.");
                AjouterNote(programme);
            }
            Console.Write("La saisie est-elle correcte ? (Oui/Non) ");
            string reponse = Console.ReadLine().ToLower();
            if (reponse == "oui")
            {
                return;
            }
            else
            {
                AjouterNote(programme);
            }
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
        
        public void SupprimerCours(int coursId)
        {
            ListeNotes.RemoveAll(note => note.IdCoursLie == coursId);
        }
    }
}

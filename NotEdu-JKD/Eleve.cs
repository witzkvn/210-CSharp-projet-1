using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class Eleve
    {
        private static int elevesCount; // au lancement du programme, regarder le id le plus haut des élèves déjà ajoutés et initialiser à cette valeur
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public List<Note> ListeNotes { get; set; }

        public Eleve(string nom, string prenom, DateTime dateNaissance)
        {
            elevesCount++;
            this.Nom = nom;
            this.Prenom = prenom;
            this.DateNaissance = dateNaissance;
            this.ID = elevesCount;
            ListeNotes =  new List<Note>();
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
        
        public void SupprimerCours(int coursId)
        {
            ListeNotes.RemoveAll(note => note.IdCoursLie == coursId);
        }
    }
}

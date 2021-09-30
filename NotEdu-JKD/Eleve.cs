using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class Eleve
    {
<<<<<<< HEAD
        private static int elevesCount; // au lancement du programme, regarder le id le plus haut des élèves déjà ajoutés et initialiser à cette valeur
=======
        private static int elevesCount { get; set; } // au lancement du programme, regarder le id le plus haut des élèves déjà ajoutés et initialiser à cette valeur
>>>>>>> 98cd79ed0f8dccfd252791182ffdad27da1000ca
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
        }
    }
}

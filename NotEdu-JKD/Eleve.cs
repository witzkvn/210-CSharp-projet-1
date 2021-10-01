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
        }
    }
}

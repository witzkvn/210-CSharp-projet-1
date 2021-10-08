using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class Note
    {
        /* Implémenter dans la classe Eleve une methode pour ajouter une note dans la liste de Note
           Ainsi une note n'a pas besoin de l'ID de l'Eleve car il en fait partie
         */

        public int IdCoursLie { get; }
        public string CoursTitreLie { get; }
        public double ValeurNote { get; }
        public string Appreciation { get; }

        public Note(int idCoursLie, string titreCoursLie, double valeurNote, string appreciation = "") // String vide comme valeur par défaut si aucune appréciation rentrée
        {
            IdCoursLie = idCoursLie;
            CoursTitreLie = titreCoursLie;
            ValeurNote = valeurNote;
            Appreciation = appreciation;
        }
    }
}
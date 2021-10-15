using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class Note
    {
        public int IdCoursLie { get; }
        public string CoursTitreLie { get; }
        public double ValeurNote { get; }
        public string Appreciation { get; }

        public Note(int idCoursLie, string titreCoursLie, double valeurNote, string appreciation = "")
        {
            IdCoursLie = idCoursLie;
            CoursTitreLie = titreCoursLie;
            ValeurNote = valeurNote;
            Appreciation = appreciation;
        }
    }
}
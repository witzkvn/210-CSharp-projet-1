using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class Note
    {
        public int CoursID { get; set; }
        public double ValeurNote { get; set; }
        public string Appreciation { get; }

        public Note(Eleve eleve, Cours cours, double note, string appreciation)
        {
            this.CoursID = cours.ID;
            this.ValeurNote = note;
            this.Appreciation = appreciation;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class Cours
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public Cours()
        {

        }

        public Cours(int id, string nom)
        {
            this.ID = id;
            this.Nom = nom;
        }
    }
}

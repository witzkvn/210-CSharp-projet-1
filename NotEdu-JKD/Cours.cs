using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class Cours
    {
        static private int _idGlobal = 0; // ID global partagé entre toutes les instances de Cours
        public int Id { get; }            // ID unique d'une instance de Cours avec un get
        public string Titre { get; }            // Titre d'une instance d'un Cours

        /*Constructeur de la classe Cours. Prend un string Titre en paramètre. 
         * Assigne un ID unique puis incrémente ID global */
        public Cours(string titre)
        {
            Titre = titre;
            Id = _idGlobal;
            _idGlobal++;
        }
    }
}

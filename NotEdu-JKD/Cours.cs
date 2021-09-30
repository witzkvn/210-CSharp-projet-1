using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class Cours
    {
<<<<<<< HEAD
        public int ID { get; set; }
        public string Nom { get; set; }
        public Cours()
        {

        }

        public Cours(int id, string nom)
        {
            this.ID = id;
            this.Nom = nom;
=======
        static private int _idGlobal = 0; // ID global partagé entre toutes les instances de Cours
        public int Id { get; }            // ID unique d'une instance de Cours avec un get
        private string _titre;            // Titre d'une instance d'un Cours

        /*Constructeur de la classe Cours. Prend un string Titre en paramètre. 
         * Assigne un ID unique puis incrémente ID global */
        public Cours(string titre)
        {
            _titre = titre;
            Id = _idGlobal;
            _idGlobal++;
        } 

        /*Suppression de toutes les occurences d'un cours.*/
        public static void SuppressionCours(Cours cours)
        {
            Console.Write("/!\\ La suppression d'un cours entraîne la suppression de toutes les notes " +
                "et appréciations qui lui sont liées. \n" +
                $"Voulez-vous vraiment supprimer le cours {cours._titre}? (Oui/Non) ");
            string reponseSuppression = Console.ReadLine().ToLower();

            if (reponseSuppression == "oui")
            {
                int id = cours.Id;
                /* Loop à travers tout les élèves, dans toutes leurs notes pour trouver l'ID correspondant*/
            }
            else
            {
                Console.WriteLine("Annulation de la suppression du cours.");
                return;
            }
>>>>>>> ecbf229b017c9250b951d70153dd6d54e6184214
        }
    }
}

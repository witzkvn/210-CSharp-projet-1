using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class ListeCours
    {
        private List<Cours> _listeDesCours = new List<Cours>();
        public List<Cours> ListeDesCours { get { return _listeDesCours; } }
        public ListeCours()
        {
        }
        public void AjouterCours(Cours nouveauCours)
        {
            _listeDesCours.Add(nouveauCours);
        }

        /*Suppression de toutes les occurences d'un cours.*/
        public void SuppressionCours(Cours cours)
        {
            Console.Write("/!\\ La suppression d'un cours entraîne la suppression de toutes les notes " +
                "et appréciations qui lui sont liées. \n" +
                $"Voulez-vous vraiment supprimer le cours {cours.Titre}? (Oui/Non) ");
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
        }
    }
}

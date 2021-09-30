using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class ListeCours
    {
        private Dictionary<int, Cours> _listeDesCours = new Dictionary<int, Cours>();
        public Dictionary<int, Cours> ListeDesCours { get { return _listeDesCours; } }
        public ListeCours()
        {
        }
        public void AjouterCours(Cours nouveauCours)
        {
            _listeDesCours.Add(nouveauCours.Id, nouveauCours);
        }

        /*Suppression de toutes les occurences d'un cours.*/
        public void SuppressionCours(int coursId)
        {
            Cours coursASupprimer = _listeDesCours[coursId];
            Console.Write("/!\\ La suppression d'un cours entraîne la suppression de toutes les notes " +
                "et appréciations qui lui sont liées. \n" +
                $"Voulez-vous vraiment supprimer le cours {coursASupprimer.Titre}? (Oui/Non) ");
            string reponseSuppression = Console.ReadLine().ToLower();

            if (reponseSuppression == "oui")
            {
                /* Loop à travers tout les élèves, dans toutes leurs notes pour trouver l'ID correspondant*/
                _listeDesCours.Remove(coursId);
            }
            else
            {
                Console.WriteLine("Annulation de la suppression du cours.");
                return;
            }
        }
    }
}

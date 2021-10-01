using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NotEdu_JKD
{
    class Menu
    {
        static string jsonString;
        static JsonSerializer serialiser;

        //----------------------------Classe Eleve temporaire----------------------------------------//
        class Eleve
        {
            public int ID { get; private set; }
            public string Nom { get; private set; }
            public string Prenom { get; private set; }


            public Eleve(int ID, string Nom, string Prenom)
            {
                this.ID = ID;
                this.Nom = Nom;
                this.Prenom = Prenom;

            }
 //          internal void Add(string nom)
 //           {
 //               throw new NotImplementedException();
 //           }
        }

        //----------------------------FIN Classe Eleve temporaire----------------------------------------//

        public Menu()
        {

        }

/*        public void AfficherListe(List<string> liste) // Permet d'afficher la liste d'élève
        {
            for (int i=0; i<3; i++)
            {
                Console.WriteLine(liste[i]);
            }

        }*/

        public void ListeEleve()
        {
            var nomEleves = new List<string>();
            while(true)
            {
                Console.WriteLine("Rentrez le nom de l'élève à ajouter à la liste : ");
                string nom = Console.ReadLine();
                if (nom=="")
                {
                    break;
                }
                nomEleves.Add(nom);
            }
            //AfficherListe(nomEleves);
            //Serveur eleve=new Serveur();
            //eleve.Serialiser(nomEleves);

/*          jsonString = JsonConvert.SerializeObject(nomEleves, Formatting.Indented); //Serialisation JSON
            Console.WriteLine(jsonString);*/

        }

        public void NoteEtAppreciation()
        {
            Console.WriteLine("Rentrez la matière :");
            string matiere = Console.ReadLine();
            Console.WriteLine("Rentrez l'ID de l'élève concerné :");
            int ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Note de lélève : ");
            double note = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Appreciation de lélève : ");
            string appreciation = Console.ReadLine();

            Cours lie = new Cours(matiere);

            Note noteEtAppreciation = new Note(lie,note,appreciation);

        }

        public void MenuPrincipal()
        {
            Console.WriteLine("----------Menu----------\n");
            Console.WriteLine("1-Elèves\n2-Cours\n");
            Console.WriteLine("Effectuer votre choix\n");
            int choix = int.Parse(Console.ReadLine());
            int resultat = 0;


            switch (choix)
            {
                case 1:
                    MenuEleves();//Si le choix = 1 alors on se rend dans le menu élève
                    break;

                case 2:
                    MenuCours();//Si le choix=2 alors on se rend dans le menu cours
                    break;
            }


        }

        //-----------------MENU ELEVES------------------------------------------------------

        public void MenuEleves()
        {

                Console.WriteLine("----------Menu des élèves----------\n");
                Console.WriteLine("1-Lister les élèves\n2-Créer un nouvel élève\n3-Consulter un élève existant\n4-Ajouter une note et une appréciation pour un cours\n5-Revenir au menu Principal\n");
                Console.WriteLine("Que voulez-vous faire ?\n");
                int choix = int.Parse(Console.ReadLine());
                int resultat = 0;

                switch (choix)
                {
                    case 1:
                        //Lister des élèves
                    break;

                    case 2:
                    ListeEleve();
                    break;

                    case 3:
                        //Consulter un élève existant
                    break;

                    case 4:
                    NoteEtAppreciation();  //Ajouter une note et une appréciation pour un cours
                    break;

                    case 5:
                    MenuPrincipal();//Retour au menu principal
                    break;

                }
        }


        //----------------FIN MENU ELEVES---------------------------------------------------


        //----------------MENU COURS--------------------------------------------------------
        public void MenuCours()
        {
            Console.WriteLine("----------Menu des cours----------\n");
            Console.WriteLine("1-Lister les cours existant\n2-Ajouter un nouveau cours au programme\n3-Supprimer un cours par son identifiant\n4-Revenir au menu Principal\n");
            Console.WriteLine("Que voulez-vous faire ?\n");
            int choix = int.Parse(Console.ReadLine());
            int resultat = 0;


            switch (choix)
            {
                case 1:
                    //Lister les cours existant
                    break;

                case 2:
                    //Ajouter un nouveau cours au programme
                    break;

                case 3:
                    //Supprimer un cours par son identifiant
                    break;

                case 4:
                    MenuPrincipal();//Retour au menu principal
                    break;

            }
        }
        //----------------FIN MENU COURS----------------------------------------------------



    }
}

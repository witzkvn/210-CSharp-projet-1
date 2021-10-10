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
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("     Rentrez le nom de l'élève à ajouter à la liste : ");


                string nom = Console.ReadLine();
                if (nom == "")
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     Rentrez la matière :");
            string matiere = Console.ReadLine();
            Console.WriteLine("     Rentrez l'ID de l'élève concerné :");
            int ID = int.Parse(Console.ReadLine());
            Console.WriteLine("     Note de lélève : ");
            double note = Double.Parse(Console.ReadLine());
            Console.WriteLine("     Appreciation de lélève : ");
            string appreciation = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;


            //Cours lie = new Cours(matiere);

            //Note noteEtAppreciation = new Note(lie, note, appreciation);

        }

        public void RetourMenuPrincipal(string NomDuCours)
        {

            if (NomDuCours.ToLower() == "retour")
            {
                Console.Clear();
                MenuCours();
            }

        }
        public void MenuPrincipal()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\n     - - - - - - - - - -MENU- - - - - - - - - -\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("     1-Elèves\n\n\n");
            Console.WriteLine("     2-Cours\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     Effectuer votre choix\n\n\n");
            int choix = int.Parse(Console.ReadLine());
            Console.Clear();


            switch (choix)
            {
                case 1:
                    MenuEleves();//Si le choix = 1 alors on se rend dans le menu élève
                    break;

                case 2:
                    MenuCours();//Si le choix=2 alors on se rend dans le menu cours
                    break;
                default :
                    MenuPrincipal();
                    break;
            }


        }

        //-----------------MENU ELEVES------------------------------------------------------

        public void MenuEleves()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\n      - - - - - - - - - -MENU DES ELEVES- - - - - - - - - -\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("     1-Lister les élèves\n\n\n");
            Console.WriteLine("     2 -Créer un nouvel élève\n\n\n");
            Console.WriteLine("     3-Consulter un élève existant\n\n\n");
            Console.WriteLine("     4-Ajouter une note et une appréciation pour un cours\n\n\n");
            Console.WriteLine("     5-Revenir au menu Principal\n\n\n\n\n");
           
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("     Que voulez-vous faire ?");
            int choix = int.Parse(Console.ReadLine());
            Console.Clear();

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
                default:
                    MenuEleves();
                    break;

            }
        }


        //----------------FIN MENU ELEVES---------------------------------------------------


        //----------------MENU COURS--------------------------------------------------------
        public void MenuCours()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\n     - - - - - - - - - -MENU DES COURS- - - - - - - - - -\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("     1-Lister les cours existant\n\n\n");
            Console.WriteLine("     2-Ajouter un nouveau cours au programme\n\n\n");
            Console.WriteLine("     3-Supprimer un cours par son identifiant\n\n\n");
            Console.WriteLine("     4-Revenir au menu Principal\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     Que voulez-vous faire ?\n\n\n");

            int choix = int.Parse(Console.ReadLine());
            Console.Clear();


            switch (choix)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                                                       (Retour : 'retour' + Entree)");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    ListeCours.AfficherTousLesCours();
                    string NomDuCours1 = Console.ReadLine();
                    RetourMenuPrincipal(NomDuCours1);
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                                                       (Retour : 'retour' + Entree)");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\n\n     Entrer le nom du cours à ajouter : ");
                    string NomDuCours2 = Console.ReadLine();
                    RetourMenuPrincipal(NomDuCours2);
                    ListeCours.AjouterCours();//new Cours(NomDuCours2));


                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                                                       (Retour : 'retour' + Entree)");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    ListeCours.SuppressionCours();
                    string NomDuCours3 = Console.ReadLine();
                    RetourMenuPrincipal(NomDuCours3);
                    break;

                case 4:
                    MenuPrincipal();//Retour au menu principal
                    break;
                default:
                    MenuCours();
                    break;

            }
        }
        //----------------FIN MENU COURS----------------------------------------------------

    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NotEdu_JKD
{
    static class Menu
    {
        public static void RetourMenuPrincipal(Campus campus, string NomDuCours)
        {

            if (NomDuCours.ToLower() == "retour")
            {
                Console.Clear();
                MenuCours(campus);
            }

        }
        public static void MenuPrincipal(Campus campus)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\n     - - - - - - - - - -MENU- - - - - - - - - -\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("     1-Elèves\n\n\n");
            Console.WriteLine("     2-Cours\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     Effectuer votre choix\n\n\n");
            string choixLettre = Console.ReadLine();
            Console.Clear();

            if (choixLettre == "1" || choixLettre == "2") { }
            else if (choixLettre == "q")
                Environment.Exit(1);
            else
                MenuPrincipal(campus);


            int choix = int.Parse(choixLettre);

            switch (choix)
            {
                case 1:
                    MenuEleves(campus);//Si le choix = 1 alors on se rend dans le menu élève
                    break;

                case 2:
                    MenuCours(campus);//Si le choix=2 alors on se rend dans le menu cours
                    break;
                default :
                    MenuPrincipal(campus);
                    break;
            }


        }

        //-----------------MENU ELEVES------------------------------------------------------

        public static void MenuEleves(Campus campus)
        {
            Console.Clear();
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
                    campus.ListeEleves.AfficherListeEleves(campus);
                    Console.WriteLine("Touche Entrée pour retour");
                    Console.ReadLine();
                    MenuEleves(campus);
                    break;

                case 2:
                    campus.ListeEleves.CreerNouvelEleve(campus);
                    break;

                case 3:
                    campus.ListeEleves.AfficherUnEleve(campus);
                    break;

                case 4:
                    campus.ListeEleves.AjouterNoteEtAppreciationEleve(campus);
                    break;

                case 5:
                    MenuPrincipal(campus);
                    break;
                default:
                    MenuEleves(campus);
                    break;

            }
        }


        //----------------FIN MENU ELEVES---------------------------------------------------


        //----------------MENU COURS--------------------------------------------------------
        public static void MenuCours(Campus campus)
        {
            Console.Clear();
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
                    campus.ListeCours.AfficherTousLesCours(campus);
                    Console.WriteLine("Touche Entrée pour retour");
                    Console.ReadLine();
                    MenuPrincipal(campus);
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                                                       (Retour : 'retour' + Entree)");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\n\n     Entrer le nom du cours à ajouter : ");
                    string NomDuCours2 = Console.ReadLine();
                    RetourMenuPrincipal(campus, NomDuCours2);
                    campus.ListeCours.AjouterCours(campus);//new Cours(NomDuCours2));


                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                                                       (Retour : 'retour' + Entree)");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    campus.ListeCours.SuppressionCours(campus);
                    string NomDuCours3 = Console.ReadLine();
                    RetourMenuPrincipal(campus, NomDuCours3);
                    break;

                case 4:
                    MenuPrincipal(campus);//Retour au menu principal
                    break;
                default:
                    MenuCours(campus);
                    break;

            }
        }
        //----------------FIN MENU COURS----------------------------------------------------

    }
}

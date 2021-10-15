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
        public static void MenuPrincipal(Campus campus)
        {
            while (true)
            {
                Serveur.AddLog("Accès Menu Principal");
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\n\n     __________________________________________");
                Console.WriteLine("     - - - - - - - - - -MENU- - - - - - - - - -");
                Console.WriteLine("     __________________________________________\n\n\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("     1-Elèves");
                Console.WriteLine("     __________________________________________\n\n\n");
                Console.WriteLine("     2-Cours");
                Console.WriteLine("     __________________________________________\n\n\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("     Effectuer votre choix :\n\n\n");
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
            Serveur.AddLog("Accès Menu Elèves");
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\n      _____________________________________________________");
            Console.WriteLine("      - - - - - - - - - -MENU DES ELEVES- - - - - - - - - -");
            Console.WriteLine("      _____________________________________________________\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("     1-Lister les élèves");
            Console.WriteLine("      _____________________________________________________\n\n");
            Console.WriteLine("     2-Créer un nouvel élève");
            Console.WriteLine("      _____________________________________________________\n\n");
            Console.WriteLine("     3-Consulter un élève existant");
            Console.WriteLine("      _____________________________________________________\n\n");
            Console.WriteLine("     4-Ajouter une note et une appréciation pour un cours");
            Console.WriteLine("      _____________________________________________________\n\n");
            Console.WriteLine("     5-Revenir au menu Principal");
            Console.WriteLine("      _____________________________________________________\n\n\n\n\n");

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("     Que voulez-vous faire ?");
            string input = Console.ReadLine();
            while (!Utilitaire.VerifUniquementEntiers(input))
            {
                Console.WriteLine("     Choix du menu incorrect.");
                input = Console.ReadLine();
            }
            int choix = int.Parse(input);
            Console.Clear();

            switch (choix)
            {
                case 1:
                    campus.ListeEleves.AfficherListeEleves(campus);
                    Console.WriteLine("   Touche Entrée pour quitter");
                    Console.ReadLine();
                    MenuEleves(campus);
                    break;

                case 2:
                    campus.ListeEleves.CreerNouvelEleve(campus);
                    Utilitaire.RetourMenuApresDelais(campus, 2);
                    break;

                case 3:
                    campus.ListeEleves.AfficherUnEleve(campus);
                    Utilitaire.RetourMenuApresDelais(campus, 2);
                    break;

                case 4:
                    campus.ListeEleves.AjouterNoteEtAppreciationEleve(campus);  //Ajouter une note et une appréciation pour un cours
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
            Serveur.AddLog("Accès Menu Cours");
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\n      _____________________________________________________");
            Console.WriteLine("      - - - - - - - - - -MENU DES COURS- - - - - - - - - -");
            Console.WriteLine("      _____________________________________________________\n\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("     1-Lister les cours existant");
            Console.WriteLine("      _____________________________________________________\n\n");
            Console.WriteLine("     2-Ajouter un nouveau cours au programme");
            Console.WriteLine("      _____________________________________________________\n\n");
            Console.WriteLine("     3-Supprimer un cours par son identifiant");
            Console.WriteLine("      _____________________________________________________\n\n");
            Console.WriteLine("     4-Revenir au menu Principal");
            Console.WriteLine("      _____________________________________________________\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     Que voulez-vous faire ?\n");

            string input = Console.ReadLine();
            while (!Utilitaire.VerifUniquementEntiers(input))
            {
                input = Console.ReadLine();
            }
            int choix = int.Parse(input);
            Console.Clear();


            switch (choix)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    campus.ListeCours.AfficherTousLesCours(campus);
                    Console.WriteLine("Touche Entrée pour retour");
                    Console.ReadLine();
                    MenuPrincipal(campus);

                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    campus.ListeCours.AjouterCours(campus);
                    Utilitaire.RetourMenuApresDelais(campus, 3);
                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    campus.ListeCours.SuppressionCours(campus);
                    Utilitaire.RetourMenuApresDelais(campus, 3);
                    break;

                case 4:
                    Serveur.AddLog("Retour au Menu Principal");
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

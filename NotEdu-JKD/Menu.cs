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
        /*        public void AfficherListe(List<string> liste) // Permet d'afficher la liste d'élève
                {
                    for (int i=0; i<3; i++)
                    {
                        Console.WriteLine(liste[i]);
                    }

                }*/

        public static void ListeEleve()
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

        public static void NoteEtAppreciation()
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

            Serveur.AddLog($"Ajout d'une note en {matiere} et d'une appréciation");

        }

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
                    Serveur.AddLog("Menu Elèves");
                    MenuEleves(campus);//Si le choix = 1 alors on se rend dans le menu élève
                    break;

                case 2:
                    Serveur.AddLog("Menu Cours");
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
                    Serveur.AddLog("Consultation de la liste des élèves");
                    Utilitaire.RetourMenuApresDelais(campus, 2);
                    break;

                case 2:
                    campus.ListeEleves.CreerNouvelEleve(campus);
                    Serveur.AddLog("Création d'un nouvelle élève");
                    Utilitaire.RetourMenuApresDelais(campus, 2);
                    break;

                case 3:
                    campus.ListeEleves.AfficherUnEleve(campus);
                    Serveur.AddLog("Consultation de la liste des élèves");
                    Utilitaire.RetourMenuApresDelais(campus, 2);
                    break;

                case 4:
                    campus.ListeEleves.AfficherListeEleves(campus);
                    NoteEtAppreciation();  //Ajouter une note et une appréciation pour un cours
                    Serveur.AddLog("Retour au Menu Principal");
                    Utilitaire.RetourMenuApresDelais(campus, 2);
                    break;

                case 5:
                    Serveur.AddLog("Retour au Menu Principal");
                    MenuPrincipal(campus);//Retour au menu principal
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
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    campus.ListeCours.AfficherTousLesCours(campus);
                    string NomDuCours1 = Console.ReadLine();
                    Serveur.AddLog("Affichage de la liste des cours disponible");
                    RetourMenuPrincipal(campus, NomDuCours1);
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    campus.ListeCours.AjouterCours(campus);
                    Utilitaire.RetourMenuApresDelais(campus, 3);
                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    campus.ListeCours.AfficherTousLesCours(campus);
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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class Program
    {

        static void Main(string[] args)
        {
            /*Serveur.EcrireLog("ouaou c'est top");*/

            Menu menu = new Menu();

            menu.MenuPrincipal();

/*          Serveur serveur = new Serveur();
            serialiser = new JsonSerializer();
            while (true)
            {

                var input = Console.ReadLine();

                switch (input)
                {
                    case "serialiser":
                        serveur.Serialiser();
                        break;
                    case "deserialiser":
                        serveur.Deserialiser();
                        break;
                    case "exporter":
                        serveur.Exporter(serialiser, jsonString) ;
                        break;
                    case "importer":
                        serveur.Importer(serialiser);
                        break;
                    default:
                        break;
                }
            }*/




        }



    }
}

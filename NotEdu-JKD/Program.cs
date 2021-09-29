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

        static string jsonString;
        static JsonSerializer serialiser;

        static void Main(string[] args)
        {

            serialiser = new JsonSerializer();
            while (true)
            {

                var input = Console.ReadLine();

                switch (input)
                {
                    case "serialiser":
                        Serialiser();
                        break;
                    case "deserialiser":
                        Deserialiser();
                        break;
                    case "exporter":
                        Exporter();
                        break;
                    case "importer":
                        Importer();
                        break;
                    default:
                        break;
                }
            }



        }

        static  void Serialiser()
        {
            Serveur eleve = new Serveur
            {
                nom = "Toto",
                prenom = "Titi",
                dateCreation = DateTime.Now,
            };
            jsonString = JsonConvert.SerializeObject(eleve, Formatting.Indented);
            Console.WriteLine(jsonString);


        }

        static void Deserialiser()
        {
            Serveur eleve = JsonConvert.DeserializeObject<Serveur>(jsonString);
            Console.WriteLine(eleve.ToString());

        }

        static void Exporter()
        { 
            using (var streamWriter = new StreamWriter("donnees.json"))
            {
                using (var jsonWriter = new JsonTextWriter(streamWriter))
                {
                    jsonWriter.Formatting = Formatting.Indented;
                    serialiser.Serialize(jsonWriter, JsonConvert.DeserializeObject(jsonString));
                    Console.WriteLine("Export OK");
                }
            }
        }

        static void Importer()
        {
            using(var streamReader=new StreamReader("donnees.json"))
            {
                using(var jsonReader=new JsonTextReader(streamReader))
                {
                    var eleve = serialiser.Deserialize<Serveur>(jsonReader);
                    Console.WriteLine(eleve.ToString());
                }
            }
        }
    }
}

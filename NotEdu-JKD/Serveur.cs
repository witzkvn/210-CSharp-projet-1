using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    public class Serveur
    {

        public string nom;
        public string prenom;
        public DateTime dateCreation;
        static string jsonString;






        public override string ToString()
        {
            return $"Nom:{nom}\n" +
                $"Prenom:{prenom}\n" +
                $"Nom:{dateCreation}\n";
        }

        public void EcrireLog(string message)
        {

            string chemin = ConfigurationManager.AppSettings["logPath"];

            using (StreamWriter writer = new StreamWriter(chemin, true))
            {

                writer.WriteLine($"{DateTime.Now}:{message}");
            }

        }

        /*        public void Serialiser(*//*"Mettre la liste à créer en JSON"*//*)
                {
                    jsonString = JsonConvert.SerializeObject(*//*"Mettre la liste à créer en JSON"*//*, Formatting.Indented);
                    Console.WriteLine(jsonString);
                }*/

        public void Serialiser()
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

        public void Deserialiser()
        {
            Serveur eleve = JsonConvert.DeserializeObject<Serveur>(jsonString);
            Console.WriteLine(eleve.ToString());

        }
        public void Exporter(JsonSerializer serialiser,string b)
        {

            using (var streamWriter = new StreamWriter("donnees.json"))
            {
                using (var jsonWriter = new JsonTextWriter(streamWriter))
                {
                    jsonWriter.Formatting = Formatting.Indented;
                    serialiser.Serialize(jsonWriter, JsonConvert.DeserializeObject(b));
                    Console.WriteLine("Export OK");
                }
            }
        }

        public void Importer(JsonSerializer serialiser)
        {
            using (var streamReader = new StreamReader("donnees.json"))
            {
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    var eleve = serialiser.Deserialize<Serveur>(jsonReader);
                    Console.WriteLine(eleve.ToString());
                }
            }
        }


    }
}

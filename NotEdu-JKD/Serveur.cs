using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class Serveur
    {
        private static string _jsonDBPath { get; set; }
        static string GetAndVerifyDBDirectory()
        {
            string path = "DB";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Serveur.AddLog($"Création du répertoire de la DB");
            }
            return path;
        }
        static string GetFilePath(string fileName)
        {
            string path = GetAndVerifyDBDirectory();
            string combinedPath = Path.Combine(path, fileName);
            return combinedPath;
        }

        public static void AddLog(string logMessage)
        {
            string logFilePath = GetFilePath("campusDB.log");
            File.AppendAllText(logFilePath, $"{DateTime.Now:[dd/MM/yyyy --- HH:mm:ss]} : {logMessage}\n");
        }

        public static void SerializeAndWriteInJSON(Campus campus)
        {
            if (String.IsNullOrEmpty(_jsonDBPath))
            {
                _jsonDBPath = GetFilePath("campusDB.json");
            } 
            
            if (!File.Exists(_jsonDBPath))
            {
                File.Create(_jsonDBPath);
                Serveur.AddLog($"Création du fichier de la DB au chemin d'accès : {_jsonDBPath}");
            }
            string campusJSON = JsonConvert.SerializeObject(campus);
            File.WriteAllText(_jsonDBPath, campusJSON);
            Serveur.AddLog($"Ecriture de la DB au chemin d'accès : {_jsonDBPath}");
        }

        public static Campus DeserializeJSON(string jsonFilePath)
        {
            if(String.IsNullOrEmpty(jsonFilePath))
            {
                _jsonDBPath = GetFilePath("campusDB.json");
            } else
            {
                _jsonDBPath = jsonFilePath;
            }

            if (!File.Exists(_jsonDBPath))
            {
                return new Campus();
            } else
            {
                string jsonDB = File.ReadAllText(_jsonDBPath);
                Serveur.AddLog($"Récupération du contenu de la DB au chemin d'accès : {_jsonDBPath}");
                if (String.IsNullOrEmpty(jsonDB))
                {
                    return new Campus();
                } else
                {
                    Campus campus = JsonConvert.DeserializeObject<Campus>(jsonDB);
                    Serveur.AddLog("Déserialisation du contenu de la DB");
                    return campus;
                }
            }
        }
    }
}

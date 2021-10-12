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
        static string GetAndVerifyDBDirectory()
        {
            string path = "DB";
            Console.WriteLine(Directory.GetCurrentDirectory());

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }
        static string GetFilePath(string fileName)
        {
            string path = GetAndVerifyDBDirectory();
            return Path.Combine(path, fileName);
        }

        public static void AddLog(string logMessage)
        {
            string logFilePath = GetFilePath("campusDB.log");
            File.AppendAllText(logFilePath, $"{DateTime.Now:[dd/MM/yyyy --- HH:mm:ss]} : {logMessage}\n");
        }

        public static void SerializeAndWriteInJSON(Campus campus)
        {
            string jsonFilePath = GetFilePath("campusDB.json");
            if (!File.Exists(jsonFilePath))
            {
                File.Create(jsonFilePath);
            }
            string campusJSON = JsonConvert.SerializeObject(campus);
            File.WriteAllText(jsonFilePath, campusJSON);
        }
    }
}

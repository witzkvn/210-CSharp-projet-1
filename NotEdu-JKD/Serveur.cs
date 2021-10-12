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
                Console.WriteLine("call");
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
            DateTime.Now.ToString("['dd' - 'MM' - 'yyyy' --- 'HH':'mm':'ss']");
            File.AppendAllText(logFilePath, $"{DateTime.Now:[dd/MM/yyyy --- HH:mm:ss]} : {logMessage}\n");
        }
    }
}

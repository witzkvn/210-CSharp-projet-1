using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

namespace NotEdu_JKD
{
    class Utilitaire
    {
        public static bool VerifFormatDate(string dateString)
        {
            var formats = new[] { "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MM/yyyy" };
            DateTime dateVerifiee;
            return DateTime.TryParseExact(dateString, formats, null, DateTimeStyles.None, out dateVerifiee) && dateVerifiee < DateTime.Now;
        }

        public static DateTime StringToDate(string dateString)
        {
            var formats = new[] { "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MM/yyyy" };
            DateTime dateVerifiee;
            DateTime.TryParseExact(dateString, formats, null, DateTimeStyles.None, out dateVerifiee);
            return dateVerifiee;
        }
        public static bool VerifUniquementLettres(string verificationLettres)
        {
            Regex regexLettres = new Regex(@"[^a-zA-ZÜ-ü ]");
            return !regexLettres.IsMatch(verificationLettres);
        }
        public static bool VerifUniquementEntiers(string verificationEntiers)
        {
            Regex regexEntiers = new Regex(@"[^\d]");
            return !regexEntiers.IsMatch(verificationEntiers);
        }
        public static bool VerifUniquementDecimaux(string verificationDecimaux)
        {
            Regex regexDecimaux = new Regex(@"^\d{1,2}(.\d{1,2})?$");
            return regexDecimaux.IsMatch(verificationDecimaux);
        }
        public static string FormatterNoteSurVingt(double note)
        {
            return $"{note}/20";
        }

        public static string FormatterDateCourteString(DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }

        public static string PremiereLettreMajuscule(string mot)
        {
            if (mot.Length == 0)
            {
                return mot;
            } else if (mot.Length == 1)
            {
                return "" + char.ToUpper(mot[0]);
            } else
            {
                return char.ToUpper(mot[0]) + mot.Substring(1);
            }  
        }

        public static void RetourMenuApresDelais(Campus campus, int choixMenu)
        {
            
            Thread.Sleep(3000);
            if (choixMenu == 1)
                Menu.MenuPrincipal(campus);
            else if (choixMenu == 2)
                Menu.MenuEleves(campus);
            else if (choixMenu == 3)
                Menu.MenuCours(campus);
            Console.Clear();
        }

        public static double ArrondirNote(double note)
        {
            int integerPart = (int)Math.Round(note, 1);
            double restToRound = note - integerPart;
            if (restToRound < 0.3)
            {
                restToRound = 0;
            }
            else if (restToRound <= 0.5)
            {
                restToRound = 0.5;
            }
            else
            {
                restToRound = 1;
            }
            double noteArrondie = integerPart + restToRound;
            Serveur.AddLog($"La note de {note} a été arrondie à {noteArrondie}");
            return noteArrondie;
        }
    }
}

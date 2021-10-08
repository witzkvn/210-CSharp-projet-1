using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class Utilitaire
    {
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

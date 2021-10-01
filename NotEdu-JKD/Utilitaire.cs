﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class Utilitaire
    {
        public string FormatterNoteSurVingt(double note)
        {
            return $"{note}/20";
        }

        public string FormatterDateCourteString(DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }
    }
}
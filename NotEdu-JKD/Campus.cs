using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class Campus
    {
        public  ListeEleves ListeEleves { get; }
        public  ListeCours ListeCours { get; }

        public Campus()
        {
            ListeEleves = new ListeEleves();
            ListeCours = new ListeCours();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEdu_JKD
{
    class Campus
    {
        public  ListeEleves Promotion { get; }
        public  ListeCours Programme { get; }

        public Campus()
        {
            Promotion = new ListeEleves();
            Programme = new ListeCours();
        }
    }
}

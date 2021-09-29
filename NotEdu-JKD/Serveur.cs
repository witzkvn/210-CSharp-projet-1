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




        public override string ToString()
        {
            return $"Nom:{nom}\n" +
                $"Prenom:{prenom}\n" +
                $"Nom:{dateCreation}\n";
        }


    }
}

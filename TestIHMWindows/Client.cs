using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIHMWindows
{
    class Client
    {
        private String nom;

        public String Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        private String prenom;

        public String Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }
        private String motDePasse;

        public String MotDePasse
        {
            get { return motDePasse; }
            set { motDePasse = value; }
        }

    }
}

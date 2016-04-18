using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Tri
{
    class Voiture : IComparable<Voiture>
    {
        public String Modele { get; set; }
        public String Marque { get; set; }
        public int Kilometrage { get; set; }

        private Decimal prix;
        public decimal Prix
        {
            get
            {
                return this.prix + 10;
            }
        }

        public string Description
        {
            get
            {
                return "Belle audi RS6";
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", this.Marque, this.Modele, this.Kilometrage);
        }

        //Mise en place de la méthode CompareTo pour pouvoir trier des Voitures
        //Propose une solution pour le tri par défaut
        public int CompareTo(Voiture uneAutreVoiture)
        {
            return this.Marque.CompareTo(uneAutreVoiture.Marque);
            //return this.Kilometrage.CompareTo(uneAutreVoiture.Kilometrage);
            //return this.Kilometrage - uneAutreVoiture.Kilometrage;
        }

        public void Encherir()
        {
            this.prix += 100;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Test.Tri
{
    class Voiture : IComparable<Voiture>, INotifyPropertyChanged
    {
        /*
        public String Modele { get; set; }
        public String Marque { get; set; }
        public int Kilometrage { get; set; }
        */
        private Decimal prix;

        private string modele;
        private string marque;
        private int kilometrage;

        public string Modele
        {
            get { return modele; }
            set
            {
                modele = value;
                this.onPropertyChanged("Modele");
            }
        }


        public string Marque
        {
            get { return marque; }
            set
            {
                marque = value;
                this.onPropertyChanged();
            }
        }


        public int Kilometrage
        {
            get { return kilometrage; }
            set
            {
                kilometrage = value;
                this.onPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        //créer une methode permttant de leve l'evenement
        //La convention veut que l'on crée un methode "OnXXX" ou XXX est le nom de l'évènement
        protected void onPropertyChanged([CallerMemberName]string propertyName=null)
        {
            //permet de faire l'appel à toutes les methodes qui se sont abonnées à l'evenement PropertyChanged 
            //en faisant uneVoiture.PropertyChanged += uneMethode
            //if(this.PropertyChanged!=null)
            //{this.PropertyChanged(this, null);}

            //Par convention, il vaut mieux ecrire ceci:
            PropertyChangedEventHandler handler = this.PropertyChanged;

            PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);

            if (handler!=null)
            {
                //handler(this, null);
                handler(this, e);
            }
        }

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

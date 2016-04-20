using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Evenements
{
    class Animal
    {
        public string Nom { get; set; }
        public string Race { get; set; }

        //Evenement
        public event EventHandler leve;
        public event EventHandler<OrdreDonneEventArgs> ordreDonne;

        //Les methodes qui vont lever les evenements
        //methodes accessible uniquemnt pas la classe et les sous-classes
        protected void onLeve()
        {
            //Je recupere dans une variable locale les abonnés a l'evenement
            EventHandler handler = leve;
            //J'apelle tous les abonnés
            if (handler!=null)
            {
                handler(this, new EventArgs());
            }
        }

        protected void onOrdreDonne(string ordreDonne)
        {
            EventHandler<OrdreDonneEventArgs> handler = this.ordreDonne;
            if (handler!=null)
            {
                handler(this, new OrdreDonneEventArgs() { OrdreDonne = ordreDonne });
            }
        }


        public void debout()
        {
            this.onLeve();
        }

        public void donnerUnOrdre(string ordre)
        {
            this.onOrdreDonne(ordre);
        }
    }
}

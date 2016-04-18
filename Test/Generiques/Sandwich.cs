using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Generiques
{
    class Sandwich<V,L,S>   where V: viande
                            where L : legume
                            where S : Sauce
    {
        private V viande;
        private L legume;
        private S sauce;

        public V Viande
        {
            get
            {
                return viande;
            }

            set
            {
                viande = value;
            }
        }

        public L Legume
        {
            get
            {
                return legume;
            }

            set
            {
                legume = value;
            }
        }

        public S Sauce
        {
            get
            {
                return sauce;
            }

            set
            {
                sauce = value;
            }
        }


        public Sandwich(V viande, L legume, S sauce)
        {
            this.Viande = viande;
            this.Legume = legume;
            this.Sauce = sauce;
        }

    }
}

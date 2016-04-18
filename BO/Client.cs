using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmployes.BO
{
    public class Client:Personne
    {
        public override string Affichage(bool avecAge)
        {
            return base.Affichage(false) + " Je ne vous donne pas mon âge !!";
        }
    }
}

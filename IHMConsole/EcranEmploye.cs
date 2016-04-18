using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmployes.IHMConsole
{
    class EcranEmploye
    {
        internal ConsoleKeyInfo Afficher()
        {
            Console.Clear();
            Console.WriteLine("Ecran Employe en cours de construction");
            Console.WriteLine("Appuyer sur une touche pour continuer");
            return Console.ReadKey(true);
        }
    }
}

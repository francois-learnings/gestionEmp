using GestionEmployes.BLL;
using GestionEmployes.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmployes.IHMConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Animal animalAAfficher = BLLAnimal.getPremierAnimal();
            Console.WriteLine("Voici l'animal retourné:");
            Console.WriteLine("Race: {0}, Espèce: {1}",
                                animalAAfficher.getRace(),
                                animalAAfficher.Espece);
            Console.ReadKey();*/
            EcranPrincipal ep = new EcranPrincipal();
            ep.Afficher();
        }
    }
}

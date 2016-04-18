using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmployes.IHMConsole
{
    class EcranPrincipal
    {
        private EcranService ecranService;
        private EcranEmploye ecranEmploye;

        public EcranPrincipal()
        {
            this.ecranService = new EcranService();
            this.ecranEmploye = new EcranEmploye();
        }
        internal void Afficher()
        {
            //Menu principal
            ConsoleKeyInfo k = new ConsoleKeyInfo();
            do
            {
                Console.Clear();
                Console.WriteLine("--- MENU PRINCIPAL ---");
                Console.WriteLine();
                Console.WriteLine("1. Gestion des services");
                Console.WriteLine("2. Gestion des employés");
                Console.WriteLine();
                Console.WriteLine("Esc. Quitter");
                k = Console.ReadKey(true);
                switch (k.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        k = this.ecranService.Afficher(); //Appeler EcranService
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        k = this.ecranEmploye.Afficher(); //Appeler EcranEmploye
                        break;
                }
            } while (!(k.Key == ConsoleKey.Escape));
        }
    }
}

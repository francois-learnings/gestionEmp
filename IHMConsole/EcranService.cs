using GestionEmployes.BLL;
using GestionEmployes.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmployes.IHMConsole
{
    class EcranService
    {
        internal ConsoleKeyInfo Afficher()
        {
            ConsoleKeyInfo tempsm1 = new ConsoleKeyInfo();
            do
            {
                Console.Clear();
                Console.WriteLine("--- Gestion Des Services ---");
                Console.WriteLine();
                //Console.WriteLine("1. Sous-Sous-menu");
                listeService();
                Console.WriteLine();
                Console.WriteLine("--- Menu ---");
                Console.WriteLine("Edition: (A)jouter - (M)odifier... ToDo");
                Console.WriteLine("Navigation: Menu (P)rincipal - Esc. Quitter");
                tempsm1 = Console.ReadKey(true);
                switch (tempsm1.Key)
                {
                    case ConsoleKey.A:
                        //tempsm1 = ssm(); //Appeler sous-sous-menu
                        AjouterService();
                        break;
                }
            } while (!(tempsm1.Key == ConsoleKey.Escape || tempsm1.Key == ConsoleKey.P));

            return tempsm1;
        }

/*
        public delegate void TrucAVerifier(string var);

        public static void code(string codeAVerifier)
        {
            Console.WriteLine("Code A Verifier" + codeAVerifier);
        }

        private static void Verifier(TrucAVerifier truc)
        {
            //bonjour.Invoke();
            truc();
        }
*/


        private void AjouterService()
        {
            Console.Clear();
            string codeAVerifier;
            string libelleAVerifier;
            do
                {
                Console.WriteLine("Entrez le code du nouveau service (5 caratères, \"A\" pour annuler :");
                codeAVerifier = Console.ReadLine();
                Console.WriteLine("Entrez le libellé du nouveau service :");
                libelleAVerifier = Console.ReadLine();

                try
                {
                    MgrService.getInstance().AjouterService(codeAVerifier, libelleAVerifier);
                    break;
                }
                catch (ApplicationException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (!(codeAVerifier=="A" || libelleAVerifier=="A"));
        }
        
        //TODO : tri de la liste
        private void listeService()
        {
            MgrService mgr = MgrService.getInstance();
            List<Service> liste = mgr.Serviceslist;
            for (int i = 0; i < liste.Count; i++)
            {
                Console.WriteLine(i+1 + ": " + liste[i]);
            }
        }

        public static ConsoleKeyInfo ssm()
        {
            ConsoleKeyInfo tempssm = new ConsoleKeyInfo();
            string message = "";
            do
            {
                Console.Clear();
                Console.WriteLine("--- Sous-Sous-Menu  ---");
                Console.WriteLine(message);
                Console.WriteLine();
                Console.WriteLine("x. une option");
                Console.WriteLine();
                Console.WriteLine("R. Retour au sous menu précédent");
                Console.WriteLine("P. Menu principal");
                Console.WriteLine("Esc. Quitter");
                tempssm = Console.ReadKey(true);
                switch (tempssm.KeyChar)
                {
                    case 'x':
                        message = "J'ai fait un truc";
                        break;
                }
            } while (!(tempssm.Key == ConsoleKey.Escape || tempssm.Key == ConsoleKey.P || tempssm.Key == ConsoleKey.R));
            return tempssm;
        }
    }
}

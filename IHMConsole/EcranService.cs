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
        private ConsoleColor couleurNormale = ConsoleColor.Gray;
        private ConsoleColor couleurErreur = ConsoleColor.Red;
        private ConsoleColor couleurInfo= ConsoleColor.Yellow;

        internal ConsoleKeyInfo Afficher()
        {
            ConsoleKeyInfo tempsm1 = new ConsoleKeyInfo();
            do
            {
                Console.Clear();
                Console.WriteLine("--- Gestion Des Services ---");
                Console.WriteLine();
                ListeService();
                Console.WriteLine();
                Console.WriteLine("--- Menu ---");
                Console.WriteLine("Edition: (A)jouter - (S)upprimer - (V)ider - (M)odifier");
                Console.WriteLine("Navigation: Menu (P)rincipal - Esc. Quitter");
                tempsm1 = Console.ReadKey(true);
                switch (tempsm1.Key)
                {
                    case ConsoleKey.A:
                        //tempsm1 = ssm(); //Appeler sous-sous-menu
                        AjouterService();
                        break;
                    case ConsoleKey.S:
                        tempsm1 = SupprimerService();
                        break;
                    case ConsoleKey.V:
                        tempsm1 = ViderServices();
                        break;
                    case ConsoleKey.M:
                        tempsm1 = ModifierService();
                        break;
                }
            } while (!(tempsm1.Key == ConsoleKey.Escape || tempsm1.Key == ConsoleKey.P));

            return tempsm1;
        }

        private ConsoleKeyInfo ModifierService()
        {
            ConsoleKeyInfo tempms = new ConsoleKeyInfo();

            Console.WriteLine();
            Console.WriteLine("Entrez le numero de la ligne à modifier: ");
            List<Service> liste = MgrService.getInstance().Serviceslist;
            tempms = Console.ReadKey();
            liste.Sort();
            int index = (int)(char.GetNumericValue(tempms.KeyChar)) - 1;
            Console.WriteLine("service selectionné: " + liste[index]);
            Console.ReadKey();

            return tempms;
        }

        private ConsoleKeyInfo ViderServices()
        {
            ConsoleKeyInfo tempvs = new ConsoleKeyInfo();
            Console.WriteLine("Voulez-vous vraiment supprimer tous les services ? (Y/N)");
            ConsoleKeyInfo reponse = Console.ReadKey();
            if (reponse.Key == ConsoleKey.Y)
            {
                while (MgrService.getInstance().Serviceslist.Count != 0)
                {
                   MgrService.getInstance().SupprimerService(0);
                }

            }

            return tempvs;
        }

        private ConsoleKeyInfo SupprimerService()
        {
            ConsoleKeyInfo tempssm = new ConsoleKeyInfo();
            do
            {
                Console.Clear();
                Console.WriteLine("--- Quel service voulez-vous supprimer  ---");
                Console.WriteLine();
                ListeService();
                Console.WriteLine();
                Console.WriteLine("------");
                Console.WriteLine("R. Retour au sous menu précédent");
                Console.WriteLine("P. Menu principal");
                Console.WriteLine("Esc. Quitter");
                Console.WriteLine("------");
                Console.WriteLine("Entrez le numero du service a supprimer: ");
                tempssm = Console.ReadKey(true);

                try
                {
                    List<Service> liste = MgrService.getInstance().Serviceslist;
                    liste.Sort();
                    int index = (int)(char.GetNumericValue(tempssm.KeyChar)) - 1;
                    Console.WriteLine("Vous allez supprimer " + liste[index]);
                    Console.WriteLine("Etes-vous sûr(e) ? (Y/N)");
                    ConsoleKeyInfo reponse = Console.ReadKey();
                    if (reponse.Key == ConsoleKey.Y)
                    {
                        MgrService.getInstance().SupprimerService(liste[index]);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (!(tempssm.Key == ConsoleKey.Escape || tempssm.Key == ConsoleKey.P || tempssm.Key == ConsoleKey.R));
            return tempssm;
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


        //TODO: Factoriser methodes de verification via un délégué
        private void AjouterService()
        {
            Console.Clear();
            string codeAVerifier;
            string libelleAVerifier;
            bool saisieOK;
            Console.WriteLine("--- Ajout d'un nouveau service ---" + System.Environment.NewLine);
            do
            {
                saisieOK = true;
                Console.WriteLine("Entrez le code du nouveau service (5 caratères):");
                codeAVerifier = Console.ReadLine();
                try
                {
                    MgrService.getInstance().VerfifierCode(codeAVerifier);

                }
                catch (ApplicationException e)
                {
                    AfficherErreur(e.Message);
                    saisieOK = false;
                }
            } while (!(codeAVerifier == "A" || saisieOK));
            do
            {
                saisieOK = true;
                Console.WriteLine("Entrez le libellé du nouveau service :");
                libelleAVerifier = Console.ReadLine();
                try
                {
                    MgrService.getInstance().VerifierLibelle(libelleAVerifier);
                }
                catch (ApplicationException e)
                {
                    AfficherErreur(e.Message);
                    saisieOK = false;
                }
            } while (!(saisieOK));

            MgrService.getInstance().AjouterService(codeAVerifier, libelleAVerifier);
            Console.WriteLine("Le nouveau service a été ajouté");
            Console.WriteLine("Voulez-vous ajouter un nouveau service (O/N)?");
            if (Console.ReadKey(true).Key == ConsoleKey.O)
            {
                this.AjouterService();
            }
        }

        private void AfficherErreur(string message)
        {
            Console.ForegroundColor = this.couleurErreur;
            Console.WriteLine(message);
            Console.ForegroundColor = this.couleurNormale;
        }

        private void ListeService()
        {
            MgrService mgr = MgrService.getInstance();
            List<Service> liste = mgr.Serviceslist;
            liste.Sort();
            if (liste.Count == 0)
            {
                Console.WriteLine(">>> Liste vide <<<");
            }
            else
            {
                for (int i = 0; i < liste.Count; i++)
                {
                    Console.WriteLine(i+1 + ": " + liste[i]);
                }
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

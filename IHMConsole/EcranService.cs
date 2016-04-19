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
                Console.WriteLine("Edition: (A)jouter - (S)upprimer - (V)ider - (M)odifier - (T)rier");
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
                    case ConsoleKey.T:
                        TrierService();
                        break;
                }
            } while (!(tempsm1.Key == ConsoleKey.Escape || tempsm1.Key == ConsoleKey.P));

            return tempsm1;
        }

        /// <summary>
        /// Tri les services en fonction du code ou du libelle
        /// </summary>
        private void TrierService()
        {
            Console.WriteLine();
            Console.WriteLine("Choisissez une option de tri (0-Par code, 1-Par libelle):");
            ConsoleKeyInfo reponse = Console.ReadKey();

            if (reponse.Key == ConsoleKey.NumPad0 || reponse.Key == ConsoleKey.D0 || reponse.Key == ConsoleKey.NumPad1 || reponse.Key == ConsoleKey.D1 )
            {
                if (reponse.Key == ConsoleKey.NumPad0 || reponse.Key == ConsoleKey.D0)
                {
                    MgrService.getInstance().Serviceslist.Sort((Service x, Service y) => x.Code.CompareTo(y.Code));
                }
                if (reponse.Key == ConsoleKey.NumPad1 || reponse.Key == ConsoleKey.D1)
                {
                    MgrService.getInstance().Serviceslist.Sort();
                }

            }
            else
            {
                AfficherErreur("Choix non valide");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Permet de modifier le code et/ou le libelle d'un service
        /// </summary>
        /// <returns></returns>
        private ConsoleKeyInfo ModifierService()
        {
            ConsoleKeyInfo tempms = new ConsoleKeyInfo();

            Console.WriteLine();
            Console.WriteLine("Entrez le numero de la ligne à modifier: ");
            List<Service> liste = MgrService.getInstance().Serviceslist;
            tempms = Console.ReadKey(true);
            liste.Sort();

            if (char.GetNumericValue(tempms.KeyChar) > 0 && char.GetNumericValue(tempms.KeyChar) <= MgrService.getInstance().Serviceslist.Count)
            {
                Console.Clear();
                int index = (int)(char.GetNumericValue(tempms.KeyChar)) - 1;

                AfficherInfo("Service courant: " + liste[index] + System.Environment.NewLine);

                string nouveauCode = ModifierCode(liste[index]);
                string nouveauLibelle = ModifierLibelle(liste[index]);

                MgrService.getInstance().ModifierService(liste[index], nouveauLibelle, nouveauCode);
            }
            else
            {
                AfficherErreur("Numero de ligne invalide - Appuyer sur un touche pour continuer...");
            }
            return tempms;
        }

        /// <summary>
        /// methode utilisée par ModifierService() afin de valider la saisie du libelle
        /// </summary>
        /// <param name="s">Service</param>
        /// <returns></returns>
        private string ModifierLibelle(Service s)
        {
            string nouveauLibelle;
            bool saisieOK;
            do
            {
                saisieOK = true;
                Console.WriteLine("Entrez le nouveau libelle (\"I\" pour ignorer la modification de cette valeur):");
                nouveauLibelle = Console.ReadLine();
                if (nouveauLibelle == "I")
                {
                    nouveauLibelle = s.Libelle;
                    saisieOK = true;
                }
                else
                {
                    try
                    {
                        MgrService.getInstance().VerifierLibelle(nouveauLibelle);
                    }
                    catch (ApplicationException e)
                    {
                        AfficherErreur(e.Message);
                        saisieOK = false;
                    }
                }
            } while (!saisieOK);

            return nouveauLibelle;
        }

        /// <summary>
        /// Methode utilisée par ModifierService afin de valider la saisie du code
        /// </summary>
        /// <param name="s">Service</param>
        /// <returns string> nouveauCode</returns>
        private string ModifierCode(Service s)
        {
            bool saisieOK;
            string nouveauCode;
            do
            {
                saisieOK = true;
                Console.WriteLine("Entrez le nouveau code (\"I\" pour ignorer la modification de cette valeur):");
                nouveauCode = Console.ReadLine();
                if (nouveauCode == "I")
                {
                    nouveauCode = s.Code;
                    saisieOK = true;
                }
                else
                {
                    try
                    {
                        MgrService.getInstance().VerifierCode(nouveauCode);
                    }
                    catch (ApplicationException e)
                    {
                        AfficherErreur(e.Message);
                        saisieOK = false;
                    }
                }
            } while (!saisieOK);

            return nouveauCode;
        }

        /// <summary>
        /// Methode supprimant tous les services de la liste
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Methode permettant de supprimer un service
        /// </summary>
        /// <returns></returns>
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


        #region Debut Refacto verif avec delegué
        /*
        public delegate void Verif(string var);

        public static void verifierCode(string codeAVerifier)
        {
            Console.WriteLine("Code A Verifier" + codeAVerifier);
        }

        public String saisie(String invite, Verif verif)
        {
            Console.WriteLine(invite);
            String retour = Console.ReadLine();
            try
            {
                verif(retour);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return retour;
        }
        */
        #endregion

        /// <summary>
        /// Metode permettant d'ajouter un service à la liste
        /// </summary>
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
                    MgrService.getInstance().VerifierCode(codeAVerifier);

                }
                catch (ApplicationException e)
                {
                    AfficherErreur(e.Message);
                    saisieOK = false;
                }
            } while (!(codeAVerifier == "A" || saisieOK));
            
            //this.saisie("veuillez saisir le code", MgrService.getInstance().VerifierCode);
            
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
            
            //this.saisie("veuillez saisir le code", MgrService.getInstance().VerifierLibelle);

            MgrService.getInstance().AjouterService(codeAVerifier, libelleAVerifier);
            Console.WriteLine("Le nouveau service a été ajouté");
            Console.WriteLine("Voulez-vous ajouter un nouveau service (O/N)?");
            if (Console.ReadKey(true).Key == ConsoleKey.O)
            {
                this.AjouterService();
            }
        }

        /// <summary>
        /// Methode d'affichage des erreurs (format, couleur)
        /// </summary>
        /// <param name="message"></param>
        private void AfficherErreur(string message)
        {
            Console.ForegroundColor = this.couleurErreur;
            Console.WriteLine(message);
            Console.ForegroundColor = this.couleurNormale;
        }

        /// <summary>
        /// Methode d'affichage des info (format, couleur)
        /// </summary>
        /// <param name="message"></param>
        private void AfficherInfo(string message)
        {
            Console.ForegroundColor = this.couleurInfo;
            Console.WriteLine(message);
            Console.ForegroundColor = this.couleurNormale;
        }

        /// <summary>
        /// Methode qui liste et affiche les services
        /// </summary>
        private void ListeService()
        {
            MgrService mgr = MgrService.getInstance();
            List<Service> liste = mgr.Serviceslist;

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

    }
}

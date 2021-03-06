﻿using EniEcole.Outils;
using GestionEmployes.BLL;
using GestionEmployes.BO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Generiques;
using Test.Tri;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Semaine1
            //testPersonne();
            /*
            try
            {
                testReglesMetier();
            }
            catch (Exception e)
            {
                Console.WriteLine("Je gère encore l'erreur");
                Console.WriteLine(e.Message);
                // Permettrait de remonter l'exception a une couche superieure
                //throw;
            }
            */
            //testAffichage();
            //testMethodesStatiques();
            //testAnneeDiff();
            //testHeritage();
            /*
            testService();
            separateur();
            testEmploye();
            separateur();
            testEmployeAffichage();
            //TODO testdate()
            */
            /* Cours jour 4 */
            //transtypage();
            //testSingleton();
            //testlist();
            //testgenerique();
            /*Test TP2*/
            //testsingleton();
            //testlisteservices();
            //separateur();
            //testajouterservice();
            //testobtenirservice();
            //testsupprimerservice_index();
            //testsupprimerservice_service();
            //testsupprimerservice_code();
            //testmodifierservice();
            /* Cours */
            //testtri(); // Non Implementé
            //testTriService();

            //TODO permettre de trier la liste de service:
            //  -Par defaut sur le libelle
            //  -Par choix sur le code
            //  Bonus: délégué puis expression lambda(RI page 196)
            #endregion
            /*s2j1*/
            //testTriParDelegue();
            //testTriParExpressionLambda();
            //testCreationEtUsageDelegue();
            //TODO: Test TrierService(critereService) - voir version cours
            //TrierService();


            //testEvenement();
            //evenement custom
            testEvenementAnimal();

            Console.ReadKey();
        }

        private static void testEvenementAnimal()
        {
            Test.Evenements.Animal animal = new Test.Evenements.Animal() { Nom = "Toutou", Race = "Teckel" };
            animal.leve += Animal_leve;
            animal.debout();

            animal.ordreDonne += Animal_ordreDonne;
            animal.donnerUnOrdre("Assis");
        }
        private static void Animal_leve(object sender, EventArgs e)
        {
            Console.WriteLine("Super, l'animal s'est levé quand je lui ai demandé");
        }

        private static void Animal_ordreDonne(object sender, Evenements.OrdreDonneEventArgs e)
        {
            Console.WriteLine("Super, l'animal a reagis quand je lui ais donné l'ordre: " + e.OrdreDonne);
        }


        private static void testEvenement()
        {

            BindingList<Voiture> listeVoitures = new BindingList<Voiture>();
            //on considèere que l'ajout est un evenement important
            //on veut que la methode uneNouvelleVoiture est arrivée soit appelé lors de l'ajout
            listeVoitures.Add(new Voiture() { Marque = "RENAULT", Modele = "Clio", Kilometrage = 200000 });
            listeVoitures.Add(new Voiture() { Marque = "AUDI", Modele = "A6", Kilometrage = 20000 });
            listeVoitures.Add(new Voiture() { Marque = "CITROEN", Modele = "Picasso", Kilometrage = 150000 });

            //Il faut s'abonner à l'evenement
            //listeVoitures.AddingNew += ListeVoitures_AddingNew;
            listeVoitures.ListChanged += uneNouvelleVoitureEstArrivee;
            listeVoitures.ListChanged += uneNouvelleVoitureEstArrivee2;
            listeVoitures.ListChanged += uneNouvelleVoitureEstArrivee3;
            //désabonnements
            listeVoitures.ListChanged -= uneNouvelleVoitureEstArrivee2;
            listeVoitures.ListChanged -= uneNouvelleVoitureEstArrivee3;


            listeVoitures.Add(new Voiture() { Marque = "PORSCHE", Modele = "Carrera", Kilometrage = 5000 });
            listeVoitures.Add(new Voiture() { Marque = "PORSCHE", Modele = "Carrera", Kilometrage = 5000 });
            listeVoitures.Remove(listeVoitures[0]);

            Voiture porsche = new Voiture() { Marque = "PORSCHE", Modele = "Carrera", Kilometrage = 5000 };
            listeVoitures.Add(porsche);
            //tentative de  modif => pas d'evenement levé
            porsche.Modele = "911";

            // toujours pas d'evenement
            porsche.PropertyChanged += Porsche_PropertyChanged;
            //tentative de  modif
            porsche.Modele = "911";





        }

        private static void Porsche_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine("Une propriété de la porsche a été levée");
        }

        /*
        private static void ListeVoitures_ListChanged(object sender, ListChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        */


        public static void uneNouvelleVoitureEstArrivee(object sender, ListChangedEventArgs e)
        {
            Console.WriteLine("La liste a changée");

            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    Console.WriteLine("Ajout");
                    break;
                case ListChangedType.ItemDeleted:
                    Console.WriteLine("Suppression");
                    break;
                case ListChangedType.ItemChanged:
                    Console.WriteLine("Changement");
                    break;
            }
        }
        public static void uneNouvelleVoitureEstArrivee2(object sender, ListChangedEventArgs e)
        {
            Console.WriteLine("La liste a changée 2");
            
        }
        public static void uneNouvelleVoitureEstArrivee3(object sender, ListChangedEventArgs e)
        {
            Console.WriteLine("La liste a changée 3");
            
        }


        #region TP3
        private static void TrierService()
        {
            //TODO - voir version cours
            List<Service> listeServices = new List<Service>();
            listeServices.Add(new Service("aaaaa", "zzzz"));
            listeServices.Add(new Service("ccccc", "xxxx"));
            listeServices.Add(new Service("bbbbb", "yyyy"));

            MgrService.getInstance().Trier((CritereService)15);

        }
        #endregion
        #region Utilisation délégué

        //Je Declare une signature de fonction
        public delegate void DisBonjour();

        //JE crée des methodes correspondant a cette signature
        public static void bonjourAmical()
        {
            Console.WriteLine("Salut Tout le monde");
        }

        public static void bonjourHierarchique()
        {
            Console.WriteLine("Bonjour Très cher chef. J'espere que vous allez vraiment bien");
        }

        public static void testCreationEtUsageDelegue()
        {
            Console.WriteLine("Le chef arrive vers moi...");
            Parler(Program.bonjourHierarchique);
            Console.WriteLine("Les collegues arrivent vers moi...");
            Parler(Program.bonjourAmical);
        }

        private static void Parler(DisBonjour bonjour)
        {
            //bonjour.Invoke();
            bonjour();
        }
        #endregion

        #region Concept Délégué & expression lambda
        private static void testTriParExpressionLambda()
        {
            List<Voiture> listeVoitures = new List<Voiture>();
            listeVoitures.Add(new Voiture() { Marque = "RENAULT", Modele = "Clio", Kilometrage = 200000 });
            listeVoitures.Add(new Voiture() { Marque = "AUDI", Modele = "A6", Kilometrage = 20000 });
            listeVoitures.Add(new Voiture() { Marque = "CITROEN", Modele = "Picasso", Kilometrage = 150000 });
            listeVoitures.Add(new Voiture() { Marque = "PORSCHE", Modele = "Carrera", Kilometrage = 5000 });
            
            // (param1, param2) => code retournant le type de rretour du delegué
            listeVoitures.Sort((Voiture x, Voiture y) => x.Marque.CompareTo(y.Marque));
            listeVoitures.ForEach(AfficheMoiCa);
            separateur();
            listeVoitures.ForEach((Voiture v) => Console.WriteLine(v));

            separateur();
            Console.WriteLine("Tri par modele");
            listeVoitures.Sort((x, y) => x.Modele.CompareTo(y.Modele));
            listeVoitures.ForEach((Voiture v) => Console.WriteLine(v));

            //expression lambda sur plusieurs lignes
            separateur();
            Console.WriteLine("Tri par kilometrage");
            listeVoitures.Sort
            (
                (Voiture x, Voiture y) =>
                {
                    int resultatComparaison;
                    if (x==null && y==null)
                    {
                        resultatComparaison = 0;
                    }
                    else if (x==null)
                    {
                        resultatComparaison = -1;
                    }
                    else if (y==null)
                    {
                        resultatComparaison = 1;
                    }
                    else
                    {
                        resultatComparaison = x.Kilometrage - y.Kilometrage;
                    }
                    return resultatComparaison;
                }
            );

            listeVoitures.ForEach(AfficheMoiCa);
        }

        private static void testTriParDelegue()
        {
            List<Voiture> listeVoitures = new List<Voiture>();
            listeVoitures.Add(new Voiture() { Marque = "RENAULT", Modele = "Clio", Kilometrage = 200000 });
            listeVoitures.Add(new Voiture() { Marque = "AUDI", Modele = "A6", Kilometrage = 20000 });
            listeVoitures.Add(new Voiture() { Marque = "CITROEN", Modele = "Picasso", Kilometrage = 150000 });
            listeVoitures.Add(new Voiture() { Marque = "PORSCHE", Modele = "Carrera", Kilometrage = 5000 });

            listeVoitures.Sort(Program.ComparaisonParMarqueDESC);
            foreach (Voiture v in listeVoitures)
            {
                Console.WriteLine(v);
            }

            separateur();
            listeVoitures.ForEach(Program.AfficheMoiCa);


        }

        private static void AfficheMoiCa(Voiture obj)
        {
            Console.WriteLine(obj);
        }

        private static int ComparaisonParMarqueDESC(Voiture x, Voiture y)
        {
            return y.Marque.CompareTo(x.Marque);
        }
        #endregion

        #region Interface
        private static void testTriService()
        {
            List<Service> listeServices = new List<Service>();
            listeServices.Add(new Service("aaaaa", "zzzz"));
            listeServices.Add(new Service("ccccc", "xxxx"));
            listeServices.Add(new Service("bbbbb", "yyyy"));

            listeServices.Sort();

            foreach (Service s in listeServices)
            {
                Console.WriteLine(s);
            }

            separateur();
            //Tri par code
            listeServices.Sort(new GestionEmployes.BLL.ServiceTriParCode());
            foreach (Service s in listeServices)
            {
                Console.WriteLine(s);
            }
        }

        private static void testtri()
        {
            List<String> liste = new List<string>();
            liste.Add("aujourd'hui");
            liste.Add("demain");
            liste.Add("avec");
            liste.Sort();

            foreach (var chaine in liste)
            {
                Console.WriteLine(chaine);
            }

        }
        #endregion

        private static void testmodifierservice()
        {
            MgrService mgr = MgrService.getInstance();
            List<Service> liste = mgr.Serviceslist;

            mgr.AjouterService("infor", "service informatique");
            mgr.AjouterService("reshu", "RH");
            foreach (Service item in liste) { Console.WriteLine(item); }
            separateur();

            //modif libelle
            Service info = mgr.ObtenirService("infor");
            mgr.ModifierService(info, "service qui rox");
            foreach (Service item in liste) { Console.WriteLine(item); }
            separateur();

            //modif code
            info = mgr.ObtenirService("infor");
            mgr.ModifierService(info, "service qui rox", "itguy");
            foreach (Service item in liste) { Console.WriteLine(item); }
            separateur();

            //test ajout doublon code
            info = mgr.ObtenirService("itguy");
            try
            {
                mgr.ModifierService(info, "service qui rox", "reshu");
            }
            catch (ApplicationException e)
            {
                Console.WriteLine(e.Message);
            }
            foreach (Service item in liste) { Console.WriteLine(item); }
            separateur();

            //test ajout doublon libelle
            info = mgr.ObtenirService("itguy");
            try
            {
                mgr.ModifierService(info, "RH");
            }
            catch (ApplicationException e)
            {
                Console.WriteLine(e.Message);
            }
            foreach (Service item in liste) { Console.WriteLine(item); }
            separateur();

            //test Ajout mauvais nom code
            info = mgr.ObtenirService("itguy");
            try
            {
                mgr.ModifierService(info, "service qui ro", "plop");
            }
            catch (ApplicationException e)
            {
                Console.WriteLine(e.Message);
            }
            foreach (Service item in liste) { Console.WriteLine(item); }
            separateur();

        }

        private static void testsupprimerservice_code()
        {
            MgrService mgr = MgrService.getInstance();
            List<Service> liste = mgr.Serviceslist;

            mgr.AjouterService("infor", "service informatique");
            mgr.AjouterService("reshu", "RH");
            foreach (Service item in liste) { Console.WriteLine(item); }
            separateur();

            mgr.SupprimerService("infor");
            foreach (Service item in liste) { Console.WriteLine(item); }

            try
            {
                mgr.SupprimerService("test");
            }
            catch (ApplicationException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        
        private static void testsupprimerservice_service()
        {
            MgrService mgr = MgrService.getInstance();
            List<Service> liste = mgr.Serviceslist;

            mgr.AjouterService("infor", "service informatique");
            mgr.AjouterService("reshu", "RH");
            foreach (Service item in liste) { Console.WriteLine(item); }
            separateur();

            Service info = mgr.ObtenirService("infor");
            mgr.SupprimerService(info);
            foreach (Service item in liste) { Console.WriteLine(item); }


        }

        private static void testsupprimerservice_index()
        {
            MgrService mgr = MgrService.getInstance();
            List<Service> liste = mgr.Serviceslist;

            mgr.AjouterService("infor", "service informatique");
            mgr.AjouterService("reshu", "RH");
            foreach (Service item in liste) { Console.WriteLine(item); }

            separateur();
            mgr.SupprimerService(1);
            foreach (Service item in liste) { Console.WriteLine(item); }

            separateur();

            //Test Erreurs

            try
            {
                mgr.SupprimerService(5);
            }
            catch (Exception)
            {
                Console.WriteLine("Index Non valide");

            }
        }

        private static void testobtenirservice()
        {
            MgrService mgr = MgrService.getInstance();
            List<Service> liste = mgr.Serviceslist;

            mgr.AjouterService("infor", "service informatique");
            mgr.AjouterService("reshu", "RH");

            //test obtenirService(int index)
            Console.WriteLine("Indice 0: " + mgr.ObtenirService(0));
            //test erreur
            try
            {
                Console.WriteLine("Indice 5: " + mgr.ObtenirService(5));
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de la recuperation du service: " + e.Message);
            }

            separateur();
            //test obtenirService(string code
            Console.WriteLine("Service avec le code infor: " + mgr.ObtenirService("infor") );
            //test erreur
            Console.WriteLine("Service avec un mauvais code: " + mgr.ObtenirService("test") );
        }

        private static void testajouterservice()
        {
            MgrService mgr = MgrService.getInstance();
            List<Service> liste = mgr.Serviceslist;

            mgr.AjouterService("infor", "service informatique");
            mgr.AjouterService("reshu", "RH");
            foreach (Service item in liste) { Console.WriteLine(item); }

            //gestion erreurs
            Console.WriteLine("Test Erreurs ajout service");

            try
            {
                mgr.AjouterService("eshu", "RH");
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de la creation du service: " + e.Message);
            }
            foreach (Service item in liste) { Console.WriteLine(item); }

            try
            {
                mgr.AjouterService("reshu", "");
            }
            catch (Exception e2)
            {
                Console.WriteLine("Erreur lors de la creation du service: " + e2.Message);
            }
            foreach (Service item in liste) { Console.WriteLine(item); }

            //test ajout doublon
            try
            {
                mgr.AjouterService("INFOR", "test");
            }
            catch (ApplicationException e3)
            {
                Console.WriteLine("Erreur lors de la creation du service: " + e3.Message);
            }
            foreach (Service item in liste) { Console.WriteLine(item); }
        }

        private static void testlisteservices()
        {
            MgrService mgr = MgrService.getInstance();
            List<Service> liste = mgr.Serviceslist;
            Console.WriteLine(liste);
        }


        private static void testgenerique()
        {
            //Sandwich<String, DateTime, int> s = new Sandwich<string, DateTime, int>("jambon", DateTime.Now, 14);
            //idealement, il faudrait declarer les classes viande, legume, sauce comme abstraite car sinon on peut creer un sandwich viande, legume, sauce
            Sandwich<poulet, salade, Moutarde> spsm = new Sandwich<poulet, salade, Moutarde>(new poulet(), new salade(), new Moutarde());
        }

        private static void testlist()
        {
            ArrayList al = new ArrayList();
            al.Add(new Service("INFOR", "Informatique"));
            al.Add(new Service("RESHU", "RH"));
            al.Add(new Service("DIRGE", "Direction Generale"));
            al.Add(new Employe() {Nom="Haddock", Prenom="Archibald" });
            al.Add(150);
            al.Add("Bonjour");
            
            foreach (object o in al)
            {
                Console.WriteLine(o);
            }

            List<Service> listeDeService = new List<Service>();
            listeDeService.Add(new Service("INFOR", "Informatique"));
            listeDeService.Add(new Service("RESHU", "RH"));
            //listeDeService.Add(10); //Pas possible, le compilateur refuse car ce n'est pas un service

            foreach (Service s in listeDeService)
            {
                //Ici il n'y a pas de cast et en plus on est sur de n'avoir que des services
                Console.WriteLine("Service: " + s);
            }

            List<Employe> listeEmployes = new List<Employe>();
            listeEmployes.Add(new Employe() { Nom = "Haddock", Prenom = "Archibald" });
        }

        private static void testSingleton()
        {
            MgrService mgrService = MgrService.getInstance();
            MgrService mgrService2 = MgrService.getInstance();
            if (mgrService==mgrService2)
            {
                Console.WriteLine("Je n'ai qu'un mgrService en memoire");
            }
            else
            {
                Console.WriteLine("J'ai 2 mgrService en memoire");
            }
        }


        private static void transtypage()
        {
            Employe e = new Employe();
            Client c = new Client();


            afficherPersonne(e);
            afficherPersonne(c);
        }

        private static void afficherPersonne(Personne p)
        {
            Console.WriteLine(p.ToString());
            Console.WriteLine(p.Affichage());

            if(p is Employe)
            {
                Employe emp = (Employe)p;
                Console.WriteLine(emp.Salaire);
            }
        }

        private static void testEmployeAffichage()
        {
            Employe e4 = new Employe(Guid.NewGuid(), "testNom", "testPrenom", new DateTime(1981, 2, 18), 
                3000, new DateTime(2010,2,2));
            Console.WriteLine(e4.affichage());

            separateur();
            //Test affichage(param)
            //Console.WriteLine(OptionsAffichageEmploye.OptionsAffichage.Simple);
            Console.WriteLine(e4.affichage(OptionsAffichageEmploye.Simple));
            separateur();
            Console.WriteLine(e4.affichage(OptionsAffichageEmploye.AvecAge));
            separateur();
            Console.WriteLine(e4.affichage(OptionsAffichageEmploye.AvecAnciennete));
            separateur();
            Console.WriteLine(e4.affichage(OptionsAffichageEmploye.AvecSalaire));
            separateur();
            Console.WriteLine(e4.affichage(OptionsAffichageEmploye.Tout));

        }

        private static void testEmploye()
        {
            Console.WriteLine("Test de la classe Employe" + System.Environment.NewLine);

            /*
            //test constructeur sans parametres et attributs
            Console.WriteLine("-Test constructeur sans param et accès aux attributs");
            Employe e = new Employe();
            e.Salaire = 2000;
            e.DateEmbauche = new DateTime(2014, 4, 13);
            Console.WriteLine(e.Anciennete);

            //Test constructeur avec Arguments
            Console.WriteLine("-Test constructeur avec arguments");
            Employe e2 = new Employe(Guid.NewGuid(), "testNom", "testPrenom", new DateTime(1981, 2, 18), 
                3000, DateTime.Today);
            Console.WriteLine("Creation d'un employé avec les attributs suivants:");
            Console.WriteLine("GUID: " + e2.Identifiant);
            Console.WriteLine("Nom: " + e2.Nom);
            Console.WriteLine("Prenom: " + e2.Prenom);
            Console.WriteLine("Date de Naissance: " + e2.Ddn);
            Console.WriteLine("Salaire: " + e2.Salaire);
            Console.WriteLine("Date d'embauche: " + e2.DateEmbauche);
            */

            //test verifSalaire
            Console.WriteLine("-Test methode verifSalaire");
            try
            {
            Employe e3 = new Employe(Guid.NewGuid(), "testNom", "testPrenom", new DateTime(1981, 2, 18), 
                -3000, DateTime.Today);
            }
            catch (ApplicationException e3)
            {
                Console.WriteLine(e3.Message);
            }


            //Tests verifDate - dateembaucge > today
            Console.WriteLine("-Test de la methode verifDate");

            try
            {
            Employe e4 = new Employe(Guid.NewGuid(), "testNom", "testPrenom", new DateTime(1981, 2, 18), 
                3000, new DateTime(2016,4,28));
            }
            catch (ApplicationException ae4)
            {
                Console.WriteLine(ae4.Message);
            }

            //Tests verifDate - employe > 18 ans
            try
            {
            Employe e5 = new Employe(Guid.NewGuid(), "testNom", "testPrenom", new DateTime(2010, 2, 18), 
                3000, new DateTime(2014,4,13));
            }
            catch (ApplicationException ae5)
            {
                Console.WriteLine(ae5.Message);
            }
        }

        private static void separateur()
        {
            Console.WriteLine("==============================================================");
        }

        private static void testService()
        {
            Console.WriteLine("Test de la classe Service" +System.Environment.NewLine);
            //Service s = new Service();

            //Faire un try lors de l'instanciation d'un service
            Service s2 = new Service("code1", "libelle");
            //Console.WriteLine(s2.Code + " - "  s2.Libelle);
            Console.WriteLine(s2.ToString());

            Service s3 = new Service("code2", "service info");
            Console.WriteLine(s3.ToString());

        }
        
        /*
        private static void testHeritage()
        {
            Personne p = new Employe("Haddock", "archibald", DateTime.Today, 2000);
            Console.WriteLine(  p.ToString() );

            Employe e = new Employe();
            e.Nom = "Tournesol";
            e.Prenom = "Tryphon";
            Console.WriteLine(e.Affichage());
            Console.WriteLine(e.Affichage(true));

            Client c = new Client();
            c.Nom = "Castafiore";
            c.Prenom = "Bianca";
            Console.WriteLine(c.Affichage());
            Console.WriteLine(c.Affichage(true));
        }

        private static void testAnneeDiff()
        {
            Console.WriteLine(EniEcole.Outils.UtilDate.AnneeDiff(new DateTime(2015, 4, 1), new DateTime(2016, 4, 12)));
            Console.WriteLine(EniEcole.Outils.UtilDate.AnneeDiff(new DateTime(2015, 4, 20), new DateTime(2016, 4, 12)));

            DateTime date1 = new DateTime(2015, 4, 10);
            DateTime date2 = DateTime.Today;
            int resultat = EniEcole.Outils.UtilDate.AnneeDiff(date2, date1);
            Console.WriteLine("Je veux 1 et le resultat est " + resultat);

            date1 = new DateTime(2015, 4, 20);
            date2 = DateTime.Today;
            resultat = EniEcole.Outils.UtilDate.AnneeDiff(date1, date2);
            Console.WriteLine("Je veux 0 et le resultat est " + resultat);

            date1 = new DateTime(2014, 4, 12);
            date2 = DateTime.Today;
            resultat = EniEcole.Outils.UtilDate.AnneeDiff(date1, date2);
            Console.WriteLine("Je veux 2 et le resultat est " + resultat);

            String prenom = "jEan-baptiste";
            prenom = prenom.premiereLettreEnMajuscule('-');
            Console.WriteLine(prenom);

            String prenom2 = "jEan";
            Console.WriteLine(prenom2.premiereLettreEnMajuscule('-'));

            String prenom3 = "";
            Console.WriteLine(prenom3.premiereLettreEnMajuscule('-'));

            Console.WriteLine("-J-Jean-Baptiste-".premiereLettreEnMajuscule('-'));
        }

        private static void testMethodesStatiques()
        {
            Personne p = new Personne(Guid.NewGuid(), "Haddock", "Capitaine", new DateTime(1960, 4, 21));
            Personne p2 = new Personne(Guid.NewGuid(), "Haddock", "Capitaine", new DateTime(1960, 4, 21));
            Personne p3 = new Personne(Guid.NewGuid(), "Haddock", "Capitaine", new DateTime(1960, 4, 21));
            Console.WriteLine(Personne.Compteur);

            p = null;
            GC.Collect();
            System.Threading.Thread.Sleep(1);
            Console.WriteLine(Personne.Compteur);

        }

        private static void testAffichage()
        {
            Personne p = new Personne(Guid.NewGuid(), "Haddock", "Capitaine", new DateTime(1960, 4, 21));
            Console.WriteLine( p.Affichage());
            Console.WriteLine( p.Affichage(true));
            Console.WriteLine( p.Affichage(false));
        }

        private static void testReglesMetier()
        {
            try
            {
                Personne p = new Personne(null, "Archibald", new DateTime(1906, 7, 23));
                Console.WriteLine("L'objet {0} est créé", p.Nom);
            }
            //Il faut mettre le bloc ApplicationException avant le bloc Exception, sinon, 
            //(applicationException etant un type d'Exception) il ne sera jamais executé
            catch (ApplicationException e)
            {
                Console.WriteLine("Une exception applicative est survenue");
                Console.WriteLine(e.Message);
            }
            catch (Exception e) // ici je gère les eventuelles exceptions
            {
                Console.WriteLine("Il y a eu un probleme !");
                Console.WriteLine(e.Message);
            }
        }

        private static void testPersonne()
        {
            Personne p = null;

            p = new Personne("Haddock", "Capitaine", new DateTime(1923,02,12));

            Console.WriteLine(p.ToString());
            Console.WriteLine("{0} {1} est né le {2} - son identifiant est {3}", 
                p.Nom, p.Prenom, p.Ddn.ToShortDateString(), p.Identifiant);

            Personne p2 = new Personne();
            p.Nom = "TOURNESOL";
            p.Prenom = "TRYPHON";
            p.Ddn = new DateTime(1906,7,23);
            

            //Lancement du Garbage Collector
            //Fait manellement ici mais a eviter
            p = null;
            Console.WriteLine("Demarrage du GC");
            
            GC.Collect();
            Console.WriteLine("Fin du programme");
            Console.ReadKey();
        }
        */
    }
}

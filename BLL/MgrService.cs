using GestionEmployes.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmployes.BLL
{
    public class MgrService
    {
        #region Singleton
        //contructeur privé empèche de creer une intance de la classe depuis l'exterieur
        private MgrService()
        {
            this.listeServices = new List<Service>();
            // simuler l'acces a une base de donnees pour charger les services existant
            this.AjouterService("Infor", "informatique");
            this.AjouterService("reshu", "RH");
            this.AjouterService("compt", "Comptabilité");
        }

        //Mise en place d'une methode statique pour pouvoir entrer dans la classe et utiliser le contructeur privé
        // methode statique permet d'accéder a une classe meme sans qu'il y ait d'instance de la classe
        public static MgrService getInstance()
        {
            if (MgrService.instance==null)
            {
                //Le contructeur est accessible
                MgrService.instance = new MgrService();
            }
            return MgrService.instance;
        }

        //Mettre en place une variable statique (pour qu'elle soit partagée) qui contient l'objet s'il a deja été créé
        private static MgrService instance;
        #endregion

        private List<Service> listeServices;

        public List<Service> Serviceslist
        {
            get
            {
                return this.listeServices;
            }
        }

        #region Ajout
        public void AjouterService(string code, string libelle)
        {
            Service serviceAAjouter = new Service(code, libelle);
            /*
            foreach (Service s in this.Serviceslist)
            {
                //Autre possibilité;
                //if(s.Code.Equals(code,StringgComparison.OrdianlIgnoreCase)) 
                if (s.Code==serviceAAjouter.Code || s.Libelle==serviceAAjouter.Libelle)
                {
                    throw new ApplicationException(string.Format("Un Service identique existe deja: {0}", s));
                }

            }
            Service newService = new Service(code, libelle);
            */
            // Idem mais avec expression lamda
            // Si le service existe deja -> lance erreur, sinon ajoute la valeur
            Service serviceExistant = this.Serviceslist.Find((Service s) => s.Code == serviceAAjouter.Code || s.Libelle == serviceAAjouter.Libelle);
            if (serviceExistant != null)
            {
                    throw new ApplicationException(string.Format("Un Service identique existe deja: {0}", serviceExistant));
            }

            //ou
            if(this.Serviceslist.Exists((Service s) => s.Code == serviceAAjouter.Code || s.Libelle == serviceAAjouter.Libelle))
            {
                    throw new ApplicationException(string.Format("Un Service identique existe deja"));
            }


            this.listeServices.Add(serviceAAjouter);
        }
        #endregion

        #region Suppression
        //erreur?
        public void SupprimerService(int position)
        {
           SupprimerService(ObtenirService(position));

        }

        public void SupprimerService(Service s)
        {
             if (s != null)
            {
                if (! this.Serviceslist.Remove(s))
                {
                    throw new ApplicationException("Service Inexistant");
                }
            }
            else
            {
                throw new ApplicationException("Service inexistant - Impossible de le supprimer" );
            }
           //this.listeServices.Remove(s);


        }

        public void SupprimerService(string code)
        {
            /*
            Service serviceASupprimer = null;
            foreach (Service s in listeServices)
            {
                if (s.Code==code.ToUpper())
                {
                    serviceASupprimer = s;
                }
            }
            this.listeServices.Remove(serviceASupprimer);
            */
            SupprimerService(ObtenirService(code));
        }
        #endregion

        #region Obtention
        public Service ObtenirService(int position)
        {
            Service serviceResultat = null;

            if (position >= 0 && position < this.Serviceslist.Count)
            {
                serviceResultat = this.Serviceslist[position]; 
            }

            return serviceResultat;
        }

        public Service ObtenirService(string code)
        {
            Service service = null;
            foreach (Service item in this.Serviceslist)
            {
                if (item.Code == code.ToUpper())
                {
                    service = item;
                }
            }
            return service;
        }
        #endregion

        #region Modification
        public void ModifierService(Service service, string libelle, string code=null)
        {

                if (code != null)
                {
                    code = code.ToUpper();
                }
            
            foreach (Service s in Serviceslist)
            {
                if (s!=service && s.Code==code)
                {
                    throw new ApplicationException("Ce code de service existe deja: " + s);
                }
                else if (s!=service && s.Libelle==libelle.premiereLettreEnMajuscule(' '))
                {
                    throw new ApplicationException("Ce libelle de service existe deja: " + s);
                }
            }

            if (code!=null)
            {
                service.Code = code;
            }
            service.Libelle = libelle;
        }
        #endregion

        /// <summary>
        /// S'assurer que le code respecte les regles de saisie
        /// et que le code n'est pas deja pris
        /// </summary>
        /// <param name="codeAVerifier"></param>
        /// <exception cref="ApplicationException"></exception>
        public void VerifierCode(string codeAVerifier)
        {
            Service.verifCode(codeAVerifier);
            if (this.ObtenirService(codeAVerifier) != null)
            {
                throw new ApplicationException("Un service possède déjà ce code !");
            }
        }

        /// <summary>
        /// S'assurer que le libellé respecte les règles de saisie
        /// et que le libellé n'est pas déjà pris
        /// </summary>
        /// <param name="nouveauLibelle"></param>
        /// <exception cref="ApplicationException"></exception>
        public void VerifierLibelle(string nouveauLibelle)
        {
            Service.verifLibelle(nouveauLibelle);
            if (this.Serviceslist.Exists(
                                            (Service s) =>
                                             s.Libelle.Equals(nouveauLibelle, StringComparison.OrdinalIgnoreCase))
                                        )
            {
                throw new ApplicationException("Un service possède déjà ce libellé");
            }
        }

        #region Tri
        public void Trier(CritereService critereService)
        {
            switch (critereService)
            {
                case CritereService.Code:
                    this.listeServices.Sort((s1, s2) => s1.Code.CompareTo(s2.Code));
                    break;
                case CritereService.Libelle:
                case CritereService.Defaut:
                default:
                    this.listeServices.Sort();
                    break;
            }
        }
        #endregion

    }
}


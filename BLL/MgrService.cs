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

        private List<Service> listeServices = new List<Service>();

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

    }
}


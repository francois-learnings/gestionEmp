using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmployes.BO
{
    public class Employe : Personne
    {
        #region Attributs
        private double salaire;
        private DateTime dateEmbauche;
        #endregion

        #region Propriétés
        public double Salaire
        {
            get { return this.salaire; }
            set
            {
                verifSalaire(value);
                this.salaire = value;
            }
        }

        public DateTime DateEmbauche
        {
            get { return this.dateEmbauche; }
            set
            {
                verifDate(this.Ddn, value);
                this.dateEmbauche = value;
            }
        }

        public int Anciennete
        {
            get { return EniEcole.Outils.UtilDate.AnneeDiff(this.dateEmbauche, DateTime.Today); }
        }

        public Service Service { get; set; }


        public Employe Chef { get; set; }
        #endregion

        #region Constructeurs
        public Employe() : base()
        {

        }
        public Employe(Guid identifiant, string nom, string prenom, DateTime ddn, 
            double salaire, DateTime dateEmbauche, Service service=null) : base(identifiant, nom, prenom, ddn)
        {
            this.Salaire = salaire;
            this.DateEmbauche = dateEmbauche;
            this.Service = service;
        }
        #endregion

        #region Methodes
        private void verifSalaire(double salaireAVerifier)
        {
            if (salaireAVerifier <= 0)
            {

                throw new ApplicationException("Le salaire doit être supérieur à Zero");
            }
        }

        private void verifDate(DateTime dateDeNaissance, DateTime dateEmbauche)
        {
            //TODO Ameliorer pour la date du jour avec shortdate
            //dateEmbauche ne peut être posterieure à aujourd'hui
            if (DateTime.Compare(dateEmbauche, DateTime.Today) >= 0 )
            {

                throw new ApplicationException("La date d'embauche ne peut être posterieure à la date du jour");
            }
            //L'employé doit être majeur
            if (EniEcole.Outils.UtilDate.AnneeDiff(dateDeNaissance,dateEmbauche) < 18)
            {
                throw new ApplicationException("Il n'est pas possible d'embaucher une personne mineure");
            }
        }

        public string affichage()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Employé: ").Append(this.Prenom).Append(" ").Append(this.Nom);
            sb.AppendLine();
            sb.Append("Né le: ").Append(this.Ddn);
            sb.AppendLine();
            sb.Append("Salaire: ").Append(this.Salaire);
            sb.AppendLine();
            sb.Append("Date d'embauche: ").Append(this.dateEmbauche);
            if (Service != null)
            {
                sb.Append("Service: ").Append(Service);
            }

            return sb.ToString();
        }

        public string affichage(OptionsAffichageEmploye optionAffichage)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Employé: ").Append(this.Prenom).Append(" ").Append(this.Nom).AppendLine();
            sb.Append("Né le: ").Append(this.Ddn).AppendLine();
            
            //Console.WriteLine(optionAffichage);
            switch (optionAffichage)
            {
                case OptionsAffichageEmploye.Simple:
                    break;
                case OptionsAffichageEmploye.AvecAge:
                    sb.Append("Age: ").Append(this.Age);
                    break;
                case OptionsAffichageEmploye.AvecSalaire:
                    sb.Append("Salaire: ").Append(this.Salaire);
                    break;
                case OptionsAffichageEmploye.AvecAnciennete:
                    sb.Append("Ancienneté: ").Append(this.Anciennete);
                    break;
                case OptionsAffichageEmploye.Tout:
                    sb.Append("Age: ").Append(this.Age).AppendLine();
                    sb.Append("Salaire: ").Append(this.Salaire).AppendLine();
                    sb.Append("Ancienneté: ").Append(this.Anciennete).AppendLine();
                    //TODO add condition to append service and chef if they exist
                    break;
                case OptionsAffichageEmploye.Defaut:
                    break;
            }

            return sb.ToString();
        }
        #endregion
    }
}

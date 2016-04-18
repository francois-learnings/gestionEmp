using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmployes.BO
{
    public class Service: IComparable<Service>
    {
        #region Attributs
        private string code;

        private string libelle;
        #endregion

        #region Propriétés
        public string Code {
            get
            {
                return this.code;
            }
            set
            {
                verifCode(value);
                this.code = value.ToUpper();
            }
        }

        public string Libelle
        {
            get
            {
                return this.libelle;
            }
            set
            {
                verifLibelle(value);
                this.libelle = value.premiereLettreEnMajuscule(' ');
            }
        }
        #endregion

        #region Constructeurs
        public Service(string code, string libelle)
        {
            this.Code = code;
            this.Libelle = libelle;
        }
        #endregion

        #region Methodes
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Code: ").Append(this.Code);
            sb.Append(" - ");
            sb.Append("Service: ").Append(this.Libelle);
            return sb.ToString();
        }

        private void verifCode(string codeAVerifier)
        {
            if (String.IsNullOrWhiteSpace(codeAVerifier) || codeAVerifier.Length != 5)
            {

                throw new ApplicationException("Un code de service doit contenir 5 lettres");
            }
        }

        private void verifLibelle(string libelleAVerifier)
        {
            if (String.IsNullOrWhiteSpace(libelleAVerifier))
            {
                throw new ApplicationException("Le libelle d'un service ne doit pas être null ou vide");
            }
        }

        #endregion

        #region Methodes Interface Icomparable
        public int CompareTo(Service other)
        {
            return this.libelle.CompareTo(other.libelle);
        }
        #endregion
    }
}

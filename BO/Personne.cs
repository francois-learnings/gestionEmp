using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmployes.BO
{
    public abstract class Personne
    {

        #region Attributs
        private DateTime ddn;
        private String nom;
        private String prenom;
        #endregion

        #region Attributs Statiques
        private static int compteur;
        #endregion

        #region Propriétés
        public DateTime Ddn
        {
            get { return this.ddn; }

            set { this.ddn = value; }
        }

        /// <summary>
        /// Le nom est obligatoire, sinon une exception est levée
        /// </summary>
        /// <exception cref="ApplicationException"></exception>
        public string Nom
        {
            get
            { return this.nom; }

            set
            {
                this.verifNom(value);
                //La ligne en dessous ne sera executée que s'il n'y a pas eu d'exception
                this.nom = value.ToUpper();
            }
        }

        public string Prenom
        {
            get
            {
                return this.prenom;
            }

            set
            {
                this.prenom = value.premiereLettreEnMajuscule('-');
            }
        }

        public Guid Identifiant { get; set; }

        public int Age
        {
            get
            {
                return EniEcole.Outils.UtilDate.AnneeDiff(this.ddn, DateTime.Today);
            }
        }
        #endregion

        #region Propriétés Statiques
        public static int Compteur
        {
            get
            {
                return Personne.compteur;
            }
        }
        #endregion

        #region Constructeurs
        // Chainage de contructeurs
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nom">Obligatoire sinon une exception est levée</param>
        /// <param name="prenom"></param>
        /// <param name="ddn"></param>
        /// <exception cref="ApplicationException"></exception>
        public Personne(String nom, String prenom, DateTime ddn):this()
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Ddn = ddn;
        }

        public Personne(Guid identifiant, String nom, String prenom, 
            DateTime ddn):this(nom,prenom,ddn)
        {
            this.Identifiant = identifiant;
            /*
            this.Nom = nom;
            this.Prenom = prenom;
            this.Ddn = ddn;*/
        }

        public Personne()
        {
            this.Identifiant = Guid.NewGuid();
            Personne.compteur += 1;
        }
        #endregion

        #region Destructeur
        ~Personne()
        {
            Console.WriteLine("Je passe dans le destructeur");
            Personne.compteur -= 1;
        }
        //doit aussi etre rajouté dans le Dispose() (que je n'ai pas créé ici)
        #endregion

        #region Methodes privees
        /// <summary>
        /// Verifie si le nom est bien renseigné. Il est obligatoire le cas echeant
        /// </summary>
        /// <param name="nom"></param>
        /// <exception cref=""ApplicationException"></exception>
        private void verifNom(String nom)
        {
            if (String.IsNullOrWhiteSpace(nom))
            {
                throw new ApplicationException("Le nom est obligatoire");
            }
        }

        #endregion

        #region Methodes publiques
        public String Affichage()
        {
            return this.Nom + " - " + this.Prenom;
        }

        /// <summary>
        /// Cette methode est declarée virtuelle.
        /// Elle peut donc etre réécrite dans les classes derivant de la classe Personne
        /// </summary>
        /// <param name="avecAge"></param>
        /// <returns></returns>
        public virtual String Affichage(bool avecAge)
        {
            String resultat = this.Affichage();
            if (avecAge)
            {
                resultat += ", âge: " + this.Age + " ans";
            }
            return resultat;
        }
        #endregion

        #region Substition de methodes de la classe Mère (réécriture)
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Nom: ").Append(this.Nom).Append(", Prenom: ").Append(this.Prenom);
            sb.Append(", Date de naissante: ").Append(this.ddn);
            return sb.ToString();
        }
        #endregion
    }
}

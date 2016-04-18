using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmployes.BO
{
    /*internal*/public class Animal
    {
        #region Les attributs
        private String espece;
        private String race;
        #endregion

        #region Propriétés
        public String Espece
        {
            get
            {
                return this.espece;
            }
            set
            {
                this.espece = value;
            }
        }
        #endregion

        #region getters/setters a la mode Java
        public void setEspece(String espece)
        {
            this.espece = espece.ToUpper();
        }

        public void setRace (String race)
        {
            this.race = race;
        }

        public String getRace()
        {
            return this.race;
        }

        public String getEspece()
        {
            return this.espece;
        }
        #endregion
    }
}

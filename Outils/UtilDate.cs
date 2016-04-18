using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EniEcole.Outils
{
    public class UtilDate
    {
        /// <summary>
        /// Retourne le nombre d'années complete entre les 2 dates.
        /// Les 2 dates ne sont fournies dans aucun ordre particulier.
        /// </summary>
        /// <param name="premiereDate"></param>
        /// <param name="secondeDate"></param>
        /// <returns></returns>
        public static int AnneeDiff(DateTime premiereDate, DateTime secondeDate)
        {
            int resultat = 0;
            if (DateTime.Compare(premiereDate,secondeDate) <= 0 )
            {
                resultat = Convert.ToInt32(Math.Truncate((secondeDate - premiereDate).TotalDays /365));
                
            }
            else
            {
                resultat = Convert.ToInt32(Math.Truncate((premiereDate - secondeDate).TotalDays /365));
            }


            
            return resultat;
        }
    }
}

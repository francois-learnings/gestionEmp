using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class StringExtension
    {
        //RI page 173
        public static String premiereLettreEnMajuscule(this String chaineAFormatter,
            char separateur)
        {
            String resultat = "";
            chaineAFormatter = chaineAFormatter.ToLower();
            if (!String.IsNullOrEmpty(chaineAFormatter))
            {
                String[] words = chaineAFormatter.Split(separateur);
                for (int i = 0; i < words.Length; i++)
                {
                    char[] t_char = words[i].ToCharArray();

                    if (t_char.Length > 0)
                    {
                        t_char[0] = Char.ToUpper(t_char[0]);

                        resultat += new string(t_char);
                        if (i < words.Length - 1)
                        {
                            resultat += '-';
                        } 
                    }
                } 
            }
            //Console.WriteLine(resultat);
            return resultat;
        }

    }
}

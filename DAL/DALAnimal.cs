using GestionEmployes.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestionEmployes.DAL
{
    public class DALAnimal
    {
        public static Animal donneMoiUnAnimal()
        {
            Animal a = new Animal();
            //a.espece = "Chat";
            a.setEspece("chat");
            //utilisation du setter de C# (mot clé get et set dans la declaration de la classe)
            // = appel aux propiétés
            a.Espece = "un chat";
            //a.race = "Persan";
            a.setRace("Persan");

            return a;
        }
    }
}

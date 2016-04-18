using GestionEmployes.BO;
using GestionEmployes.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmployes.BLL
{
    public class BLLAnimal
    {
        public static Animal getPremierAnimal()
        {
            // faire des verifications metiers
            // Ex: Est ce que l'utilisateur a les authorisations d'accès
            // ...
            Animal animalARetourner = DALAnimal.donneMoiUnAnimal();

            return animalARetourner;
        }
    }
}

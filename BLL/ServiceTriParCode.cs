using GestionEmployes.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmployes.BLL
{
    public class ServiceTriParCode : IComparer<Service>
    {
        public int Compare(Service x, Service y)
        {
            return x.Code.CompareTo(y.Code);
        }
    }
}

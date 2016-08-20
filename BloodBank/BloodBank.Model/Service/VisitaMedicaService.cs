using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Indagini.Tipi;
using BloodBank.Model.Tests;

namespace BloodBank.Model.Service
{
    public class VisitaMedicaService : DataService<VisitaMedica>
    {

        private static readonly IList<VisitaMedica> Items = new List<VisitaMedica>() { 
            
            };
        public VisitaMedicaService() : base(Items)
        {
        }
    }
}

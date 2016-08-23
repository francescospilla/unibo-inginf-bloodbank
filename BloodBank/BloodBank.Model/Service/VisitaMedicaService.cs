using System.Collections.Generic;
using BloodBank.Model.Models.Tests;

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

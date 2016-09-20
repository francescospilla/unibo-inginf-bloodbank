using System;
using System.Collections.Generic;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Service;

namespace BloodBank.Mock
{
    public class SaccaSangueService : DataService<SaccaSangue>
    {
        private static readonly IList<SaccaSangue> Items = new List<SaccaSangue>(){
            new SaccaSangue(null, GruppoSanguigno.AB_Neg, ComponenteEmatico.GlobuliRossi, DateTime.Now.AddDays(-3).AddHours(2)),
            new SaccaSangue(null, GruppoSanguigno.AB_Neg, ComponenteEmatico.GlobuliRossi, DateTime.Now.AddDays(-300).AddHours(2)),
        };

        public SaccaSangueService(IList<SaccaSangue> items) : base(Items)
        {
        }

        public SaccaSangueService() : base(Items)
        {
        }
    }
}

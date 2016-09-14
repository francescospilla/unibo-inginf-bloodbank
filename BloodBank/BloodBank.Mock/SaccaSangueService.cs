using System;
using System.Collections.Generic;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Service;
using static BloodBank.Mock.DonatoreService;
using static BloodBank.Model.Models.Donazioni.TipoDonazione;

namespace BloodBank.Mock
{
    public class SaccaSangueService : DataService<SaccaSangue>
    {
        private static readonly IList<SaccaSangue> Items = new List<SaccaSangue>()
        {
           
        };

        public SaccaSangueService(IList<SaccaSangue> items) : base(Items)
        {
        }
    }
}

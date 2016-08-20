using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Donazioni;
using BloodBank.Model.Sangue;

namespace BloodBank.Model.Service
{
    public class SaccaSangueService : DataService<SaccaSangue>
    {
        private static readonly IList<SaccaSangue> Items = new List<SaccaSangue>()
        {
        };
        public SaccaSangueService() : base(Items) {
        }
    }
}

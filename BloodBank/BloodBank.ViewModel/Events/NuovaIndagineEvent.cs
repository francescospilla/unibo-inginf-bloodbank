using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;

namespace BloodBank.ViewModel.Events
{
    public class NuovaIndagineEvent
    {
        public NuovaIndagineEvent(Indagine indagine)
        {
            Indagine = indagine;
        }
        public Indagine Indagine { get; }
    }
}
